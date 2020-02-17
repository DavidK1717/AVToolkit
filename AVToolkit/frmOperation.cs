using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmOperation : Form
    {
        // lists for comboboxes
        protected string[] Codecs;
        protected string[] CodecExtensions;
        protected string[] VideoCodecs;
        protected string[] VideoCodecExtensions;
        protected string[] AudioCodecExtensions;
        protected string[] AudioCodecs;
        
        // form navigation flag        
        protected bool FileLoading = true;

        protected Operation Op;
        

        public frmOperation()
        {
            InitializeComponent();
            progressBar1.Hide();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            //try
            //{

            var result = openFileDialog1.ShowDialog();

            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(openFileDialog1.FileName)) return;

            LoadFile(openFileDialog1.FileName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error");
            //}
        }

        private void LoadFile(string fileName)
        {
            FileLoading = true;

            ResetControls();

            // display path of selected file
            txtFile.Text = fileName;

            InstantiateOperationObject();

            SetControlDefaults();

            UpdateInputDetails(Op.InputFile);

            AdditionalProcessing();

            // This will also clear the combo box, thus setting the Selected index to -1
            // so this will always trigger the SelectedIndexChanged event
            LoadFileTypesCombo();

            FileLoading = false;
        }

        protected virtual void UpdateInputDetails(InputFile inputFile)
        {
            txtFileDetails.Text = "File type: " + inputFile.Format_long_name;
            txtFileDetails.AppendText(Environment.NewLine);
            txtFileDetails.AppendText("Formats:" + inputFile.Formats);
            txtFileDetails.AppendText(Environment.NewLine);
            txtFileDetails.AppendText("Duration: " + inputFile.Formatted_duration);
            txtFileDetails.AppendText(Environment.NewLine);
            txtFileDetails.AppendText("Bit rate: " + inputFile.Formatted_bitrate);
            txtFileDetails.AppendText(Environment.NewLine);
            txtFileDetails.AppendText("Size: " + inputFile.Formatted_size);
            txtFileDetails.AppendText(Environment.NewLine);
            txtFileDetails.AppendText("Encoder: " + inputFile.Encoder);

            // load Streams combo
            cboStreams.Items.Clear();
            for (var i = 0; i < inputFile.Formatted_streams.Count; i++)
                cboStreams.Items.Add(new ComboBoxItem(inputFile.Formatted_streams[i], i));
            cboStreams.SelectedIndex = 0;
        }

        protected virtual void InstantiateOperationObject()
        {
        }

        protected virtual void SetControlDefaults()
        {
        }

        protected virtual void ResetControls()
        {
            progressBar1.Value = 0;
            progressBar1.Hide();
            lblProgress.Text = "";
        }

        protected virtual void AdditionalProcessing()
        {
        }

        protected virtual void LoadFileTypesCombo()
        {
            cboFileType.Items.Clear();

            for (var i = 0; i < Codecs.Length; i++)
                cboFileType.Items.Add(Codecs[i] + " (" + CodecExtensions[i] + ")");
            cboFileType.SelectedIndex = 0;
        }

        protected virtual void SetupOutput()
        {
            // sets the output file name and the codec to be used
            Op.AssignCodec(Codecs[cboFileType.SelectedIndex]);
            Op.OutputFile.Codec.Extension = "." + CodecExtensions[cboFileType.SelectedIndex];
            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }

        protected void UpdateFfmpegParam()
        {
            // need to check if output file exists because ffmpeg will fail if it does
            if (!File.Exists(txtOutputFileName.Text))
            {
                FfmpegParamUpdate();
            }
            else
            {
                var message = "The output file " + txtOutputFileName.Text + Environment.NewLine
                              + " already exists. Please change the proposed output file name " + Environment.NewLine
                              + "or rename or delete the existing file. ";
                MessageBox.Show(message);

                txtOutputFileName.Focus();
            }
        }

        protected virtual void FfmpegParamUpdate()
        {
            CreateParameterString();
        }

        protected void CreateParameterString()
        {
            // has the output file path changed? If so we need to tell the OutputFile object.  
            if (txtOutputFileName.Text != Op.OutputFile.Path)
                Op.OutputFile.Path = txtOutputFileName.Text;

            Op.AssignParameterString();
            txtParam.Text = Op.ParameterString;

            toolTip1.SetToolTip(txtParam, txtParam.Text);
        }

        protected bool ValidateOutputFileName()
        {
            var status = true;
            if (txtOutputFileName.Text == "")
            {
                errorProvider1.SetError(txtOutputFileName, "An output file name is required");
                status = false;
            }
            else
            {
                errorProvider1.SetError(txtOutputFileName, "");
            }
            return status;
        }

        private void cboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // does the output file name already have the file extension associated with the new codec or not?
                // when file is loading the answer is no because output file name has not yet been set.

                // legacy
                string[] extensions;

                if (CodecExtensions == null)
                    if (VideoCodecExtensions == null)
                        if (VideoCodecs == null)
                            extensions = null;
                        else
                            extensions = VideoCodecs;
                    else
                        extensions = VideoCodecExtensions;
                else
                    extensions = CodecExtensions;
                // end of legacy


                if (txtOutputFileName.Text.ToUpper() !=
                    Path.Combine(Path.GetDirectoryName(txtFile.Text),
                        Path.GetFileNameWithoutExtension(txtFile.Text)).ToUpper()
                    + "." + extensions[cboFileType.SelectedIndex].ToUpper())
                {
                    // no - this where output file name and codec are set. We need to do this every time the
                    // selected index is changed, including when file is loaded.
                    SetupOutput();

                    // these values are codec specific so need to be changed when codec is changed and when file is loaded.
                    LoadCodecSpecificControls();

                    // when the file loads we will get here and when it loads we want to run UpdateFfmpegParam() and this is where we do it
                    if (FileLoading)
                        UpdateFfmpegParam();
                }
                else
                {
                    // Need to run UpdateFfmpegParam() because the file name has not changed 
                    // (because it has already been changed by the user) so the output file name text box on change event 
                    // has not been triggered and so the parameter string has not been updated so we need to that here.
                    SetupOutput();

                    // these values are codec specific so need to be changed when codec is changed and when file is loaded.
                    LoadCodecSpecificControls();

                    UpdateFfmpegParam();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected virtual void LoadCodecSpecificControls()
        {
        }

        protected void param_entryChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }

        protected void txtOutputFileName_Validating(object sender, CancelEventArgs e)
        {
            ValidateOutputFileName();
        }

        protected virtual void cboStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStreamDetails();
        }

        protected virtual void UpdateStreamDetails()
        {
            UpdateStreamDetails(Op.InputFile);
        }

        protected void UpdateStreamDetails(InputFile inputFile)
        {
            inputFile.UpdateStreamFields(((ComboBoxItem) cboStreams.SelectedItem).HiddenValue);

            txtStreamDetails.Text = "Codec: " + inputFile.Stream_codec;
            txtStreamDetails.AppendText(Environment.NewLine);
            txtStreamDetails.AppendText("Bit rate: " + inputFile.Formatted_stream_bitrate);
            txtStreamDetails.AppendText(Environment.NewLine);

            if (inputFile.Stream_codec_type == "video")
            {
                txtStreamDetails.AppendText("Resolution: " + inputFile.Resolution);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Aspect ratio: " + inputFile.Aspect_ratio);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Pixel format: " + inputFile.Pixel_format + " | Level: " + inputFile.Level);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Number of frames: " + inputFile.Nb_frames);
            }
            else if (inputFile.Stream_codec_type == "audio")
            {
                txtStreamDetails.AppendText("Sample format: " + inputFile.Sample_format);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Sample rate: " + inputFile.Sample_rate);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Channels: " + inputFile.Channels + " | Layout: " + inputFile.Layout);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Encoder: " + inputFile.Stream_encoder);
            }
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (ParameterCheck() && OverwriteCheck())
                PerformOperation();
            else
                txtOutputFileName.Focus();
        }

        protected virtual void PerformOperation()
        {
            Op.ProgressStartedCallback = ProgressStarted;
            Op.ProgressUpdateCallback = ProgressUpdate;
            Op.ProgressFinishedCallback = ProgressFinished;
            Op.Run();
        }

        protected virtual bool ParameterCheck()
        {
            var continueFlag = true;

            if (Op.ParameterString == txtParam.Text) return continueFlag;

            var message = "The FFMPEG parameter string has changed!" + Environment.NewLine
                          + " Click on Yes to use the changed parameters: " + Environment.NewLine
                          + txtParam.Text + Environment.NewLine
                          + " Click on No to use the original parameters: " + Environment.NewLine
                          + Op.ParameterString + Environment.NewLine
                          + "or click on Cancel to abort. ";

            switch (MessageBox.Show(message,
                "Warning",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // proceed with new parameters
                    Op.ParameterString = txtParam.Text;
                    // but has output file name changed? If so the SuccessTest function will think that no output file has been created.
                    // we need to make sure the output file in the output file text box is what is created
                    // regex finds all double-quoted strings
                    Regex r = new Regex("\"([^\"]*)\"");
                    // get a collection but we only want the final match
                    MatchCollection result = r.Matches(Op.ParameterString);
                    if (result.Count > 0)
                    {
                        // if final quoted string is different from output filename then change output file name to match it
                        // will only work if output filename is final quoted string, so won't work if wildcards are used for multiple outputs
                        if (result[result.Count - 1].Value.TrimStart('"').TrimEnd('"') != txtOutputFileName.Text)
                        {
                            // remove quotes
                            txtOutputFileName.Text = result[result.Count - 1].Value.TrimStart('"').TrimEnd('"');
                        }
                    }
                    break;

                case DialogResult.No:
                    // proceed with original parameters
                    txtParam.Text = Op.ParameterString;
                    break;

                case DialogResult.Cancel:
                    continueFlag = false;
                    break;
            }

            return continueFlag;
        }

        protected virtual bool OverwriteCheck()
        {
            var continueFlag = true;

            if (Op.InputFile.Path.ToUpper() == Op.OutputFile.Path.ToUpper())
            {
                MessageBox.Show("The output and input file paths are identical. Please change the output file name.",
                    "Badger speaks!");

                continueFlag = false;
            }
            else if (File.Exists(Op.OutputFile.Path))
            {
                var message = "The output file " + txtOutputFileName.Text + Environment.NewLine
                              + " already exists. Please change the proposed output file name " + Environment.NewLine
                              + "or rename or delete the existing file. ";
                MessageBox.Show(message);

                continueFlag = false;
            }

            return continueFlag;
        }

        protected virtual void ProgressStarted()
        {
            // TODO is invoke still needed?
            Invoke(new MethodInvoker(delegate
            {
                progressBar1.Value = 0;
                progressBar1.Update();
                progressBar1.Show();

                lblProgress.Text = "";
            }));
        }

        protected virtual void ProgressFinished(string labelText)
        {
            Invoke(new MethodInvoker(delegate
            {
                progressBar1.Value = 100;
                progressBar1.Update();
                lblProgress.Text = labelText;
            }));
        }

        protected virtual void ProgressUpdate(double progPercentage)
        {
            Invoke(new MethodInvoker(delegate
            {
                progressBar1.Value = (int) progPercentage;
                progressBar1.Update();
                lblProgress.Text = $"{string.Format("{0:0.##}", progPercentage)}%";
            }));
        }

        private void txtFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void txtFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadFile(files[0]);
        }

        protected void frmOperation_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        protected void frmOperation_DragDrop(object sender, DragEventArgs e)
        {
            //txtFile.Text = e.Data.GetData(DataFormats.FileDrop).ToString();
        }

        

        // for use with windows explorer context menu
        private void frmOperation_Load(object sender, EventArgs e)
        {
            
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                LoadFile(args[1]);
            }
        }
    }
}