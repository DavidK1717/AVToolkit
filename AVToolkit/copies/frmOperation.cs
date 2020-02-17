using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DK.Util;
using Newtonsoft.Json;


namespace VD
{
    public partial class frmOperation : Form
    {
        public frmOperation()
        {
            InitializeComponent();
            progressBar1.Hide();
        }

        Conversion conversion;
        FfmpegConvertToAudio ffmpeg;

        // these are the codecs that can be selected by the user
        private readonly string[] codecs = {"libmp3lame", "libfdk_aac", "aac" };
        private readonly string[] codec_extensions = { "mp3", "aac", "aac" };   
       
        // form navigation flags
        private string bitRateEncoding=null;
        private bool fileLoading = true;                        

        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
                {
                    fileLoading = true;

                    // reset form controls
                   
                    cboStreams.Items.Clear();
                    progressBar1.Value = 0;
                    progressBar1.Hide();
                    lblProgress.Text = "";

                    // display selected file
                    txtFile.Text = openFileDialog1.FileName;

                    //inputFilePath = txtFile.Text;
                    conversion = new Conversion(txtFile.Text);
                                        
                    txtFileDetails.Text = "File type: " + conversion.InputFile.Format_long_name;
                    txtFileDetails.AppendText(Environment.NewLine);
                    txtFileDetails.AppendText("Formats:" + conversion.InputFile.Formats);
                    txtFileDetails.AppendText(Environment.NewLine);                    
                    txtFileDetails.AppendText("Duration: " + conversion.InputFile.Formatted_duration);
                    txtFileDetails.AppendText(Environment.NewLine);
                    txtFileDetails.AppendText("Bit rate: " + conversion.InputFile.Formatted_bitrate);
                    txtFileDetails.AppendText(Environment.NewLine);
                    txtFileDetails.AppendText("Size: " + conversion.InputFile.Formatted_size);
                    txtFileDetails.AppendText(Environment.NewLine);                    
                    txtFileDetails.AppendText("Encoder: " + conversion.InputFile.Encoder);

                    // load Streams combo
                    for (int i = 0; i < conversion.InputFile.Formatted_streams.Count; i++)
                    {                        
                        cboStreams.Items.Add(new ComboBoxItem(conversion.InputFile.Formatted_streams[i], i));
                    }
                    cboStreams.SelectedIndex = 0;

                    // make sure one is checked by default
                    rdoCBR.Checked = true;

                    /// This will also clear the combo box, thus setting the Selected index to -1
                    /// so this will always trigger the SelectedIndexChanged event
                    LoadFileTypesCombo();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LoadFileTypesCombo()
        {
            cboFileType.Items.Clear();

            for (int i=0; i < codecs.Count(); i++)
            {
                cboFileType.Items.Add(codecs[i] + " (" + codec_extensions[i] + ")");
            }
            cboFileType.SelectedIndex = 0;
        }

        private void SetupOutput()
        {
            // sets the output file name and the codec to be used
            conversion.OutputFile = new OutputFile(conversion.InputFile.InputFilePath, codecs[cboFileType.SelectedIndex]);
            txtOutputFileName.Text = conversion.OutputFile.OutputFilePath;
            
        }

        
        private void UpdateFfmpegParam()
        {
            //MessageBox.Show("UpdateFfmpegParam");       

            if (bitRateEncoding == null)
            {
                // should never get here!
                MessageBox.Show("Please select either VBR, ABR or CBR.");
            }
            else
            {
                string strParam = null;

                // has the output file path changed? If so we need to tell the OutputFile object.                

                if (txtOutputFileName.Text != conversion.OutputFile.OutputFilePath)
                    conversion.OutputFile.OutputFilePath = txtOutputFileName.Text;

                BitrateMode encodingMode = (BitrateMode)Enum.Parse(typeof(BitrateMode), bitRateEncoding);

                switch(encodingMode)
                {
                    case BitrateMode.CBR:
                        {
                            conversion.OutputFile.Codec.Bitrate = ((ComboBoxItem)cboOutputBitRateCBR.SelectedItem).HiddenValue;
                            break;
                        }
                    case BitrateMode.VBR:
                        {
                            conversion.OutputFile.Codec.Bitrate = ((ComboBoxItem)cboOutputBitRateVBR.SelectedItem).HiddenValue;
                            break;
                        }
                    case BitrateMode.ABR:
                        {
                            conversion.OutputFile.Codec.Bitrate = ((ComboBoxItem)cboOutputBitRateABR.SelectedItem).HiddenValue;
                            break;
                        }
                    default:
                        {
                            conversion.OutputFile.Codec.Bitrate = 0;
                            break;
                        }
                }

                strParam = conversion.OutputFile.Codec.GetParameterString(conversion.InputFile.InputFilePath, 
                    conversion.OutputFile.OutputFilePath, (int)encodingMode);                

                // -loglevel can be "quiet" "panic" "fatal" "error" "warning" "info" "verbose" "debug" "trace"
#if (DEBUG)
                strParam = strParam += " -loglevel debug";
#endif
                txtParam.Text = strParam;

                toolTip1.SetToolTip(txtParam, txtParam.Text);
            }
        }

        private void LoadBitrateCombos()
        {
            Codec codec = conversion.OutputFile.Codec;

            cboOutputBitRateCBR.Items.Clear();
            cboOutputBitRateVBR.Items.Clear();
            cboOutputBitRateABR.Items.Clear();

            // load CBR combo & ABR (uses same values)
            for (int i = 0; i < codec.AudioBitratesCBR.Length; i++)
            {
                string item = codec.AudioBitratesCBR_fmtd[i];
                cboOutputBitRateCBR.Items.Add(new ComboBoxItem(item, codec.AudioBitratesCBR[i]));
                cboOutputBitRateABR.Items.Add(new ComboBoxItem(item, codec.AudioBitratesCBR[i]));
            }
            cboOutputBitRateCBR.SelectedIndex = 0;
            cboOutputBitRateABR.SelectedIndex = 0;

            // load VBR combo
            for (int i = 0; i < codec.AudioBitratesVBR.Length; i++)
            {
                string item = codec.AudioBitratesVBR_fmtd[i];
                cboOutputBitRateVBR.Items.Add(new ComboBoxItem(item, i));
            }
            cboOutputBitRateVBR.SelectedIndex = 0;
        } 

        private bool ValidateOutputFileName()
        {
            bool status = true;
            if (txtOutputFileName.Text == "")
            {
                errorProvider1.SetError(txtOutputFileName, "An output file name is required");
                status = false;
            }
            else
                errorProvider1.SetError(txtOutputFileName, "");
            return status;
        }


        private void cboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cboFileType_SelectedIndexChanged");
           
            /// does the output file name already have the file extension associated with the new codec or not?
            /// when file is loading the answer is no because output file name has not yet been set.
            if (txtOutputFileName.Text.ToUpper() != 
                Path.Combine(Path.GetDirectoryName(txtFile.Text), 
                Path.GetFileNameWithoutExtension(txtFile.Text)).ToUpper() 
                + "." + codec_extensions[cboFileType.SelectedIndex].ToUpper())
            {
                /// no - this where output file name and codec are set. We need to do this every time the
                /// selected index is changed, includeng when file is loaded.
                SetupOutput();

                // these values are codec specific so need to be changed when codec is changed and when file is loaded.
                LoadBitrateCombos();

                // when the file loads we will get here and when it loads we want to run UpdateFfmpegParam() and this is where we do it
                if (fileLoading)
                {
                    UpdateFfmpegParam();
                    fileLoading = false;
                }
            }
            else
            {
                /// Need to run UpdateFfmpegParam() because the file name has not changed so the output file name text box on change event 
                /// has not been triggered and so the parameter string has not been updated so we need to that here.

                SetupOutput();

                // these values are codec specific so need to be changed when codec is changed and when file is loaded.
                LoadBitrateCombos();

                UpdateFfmpegParam();
            }   
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            // Executed when any radio button is changed.
            // ... It is wired up to every single radio button.
            
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                this.bitRateEncoding = rb.Text;
              
                if (!fileLoading)
                {
                    UpdateFfmpegParam();
                }

            }
        }

        private void param_entryChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("param_entryChanged");
            if (!fileLoading)
                UpdateFfmpegParam();


        }

        private void txtOutputFileName_Validating(object sender, CancelEventArgs e)
        {
            ValidateOutputFileName();
        }

        private void cboOutputBitRateVBR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!fileLoading && rdoVBR.Checked)
                UpdateFfmpegParam();
        }

        private void cboOutputBitRateCBR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!fileLoading && rdoCBR.Checked)
                UpdateFfmpegParam();
        }

        private void cboStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            conversion.InputFile.UpdateStreamFields(((ComboBoxItem)cb.SelectedItem).HiddenValue);
            
            txtStreamDetails.Text = "Codec: " + conversion.InputFile.Stream_codec;
            txtStreamDetails.AppendText(Environment.NewLine); 
            txtStreamDetails.AppendText("Bit rate: " + conversion.InputFile.Formatted_stream_bitrate);
            txtStreamDetails.AppendText(Environment.NewLine);

            if (conversion.InputFile.Stream_codec_type == "video")
            {
                txtStreamDetails.AppendText("Resolution: " + conversion.InputFile.Resolution);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Aspect ratio: " + conversion.InputFile.Aspect_ratio);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Pixel format: " + conversion.InputFile.Pixel_format + " | Level: " + conversion.InputFile.Level);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Number of frames: " + conversion.InputFile.Nb_frames);
            }
            else if (conversion.InputFile.Stream_codec_type == "audio")
            {
                txtStreamDetails.AppendText("Sample format: " + conversion.InputFile.Sample_format);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Sample rate: " + conversion.InputFile.Sample_rate);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Channels: " + conversion.InputFile.Channels + " | Layout: " + conversion.InputFile.Layout);
                txtStreamDetails.AppendText(Environment.NewLine);
                txtStreamDetails.AppendText("Encoder: " + conversion.InputFile.Stream_encoder);
            }
        }

        /* CONVERSION CODE */

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (OverwriteCheck())
                {

                    if (bitRateEncoding == null)
                    {
                        MessageBox.Show("Please select either VBR, ABR or CBR.");
                    }
                    else
                    {
                        long fileDur = (Int64)conversion.InputFile.Duration;
                        // from https://forums.creativecow.net/thread/291/286
                        long outputFileSize = (128000 / 8) * fileDur; // in bytes

                        //FfmpegConvertToAudio ffmpeg = new FfmpegConvertToAudio(txtParam.Text, outputFileSize);
                        ffmpeg = new FfmpegConvertToAudio(txtParam.Text, outputFileSize);

                        ffmpeg.FfmpegProgressChanged
                            += new EventHandler<ProgEventArgs>((sender2, e1) => Ffmpeg_ProgressChanged(sender2, e1));

                        ffmpeg.FfmpegFinished += Ffmpeg_Finished;
                        ffmpeg.FfmpegStarted += Ffmpeg_Started;

                        ffmpeg.ExecuteAsync();
                    }
                }
                else
                    txtOutputFileName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private bool OverwriteCheck()
        {
            bool continueFlag = true;

            if (conversion.InputFile.InputFilePath.ToUpper() == conversion.OutputFile.OutputFilePath.ToUpper())
            {
                MessageBox.Show("The output and input file paths are identical. Please change the output file name.", "Badger speaks!");

                continueFlag = false;

            }
            return continueFlag;
        }

        private void Ffmpeg_ProgressChanged(object sender, ProgEventArgs e)
        {

            // update progress bar and label.
            // see https://www.youtube.com/watch?v=TnG3urCD_m0 also downloaded code
            try
            {
                // Invoke is needed to prevent error when control is accessed from a thread other than
                // the thread it was created on.
                Invoke(new MethodInvoker(delegate ()
                {
                    int progPercent = (int)e.ProgPercentage;
                    if (progPercent <= 100)
                    {
                        progressBar1.Value = (int)e.ProgPercentage;
                        progressBar1.Update();
                        lblProgress.Text = $"{string.Format("{0:0.##}", e.ProgPercentage)}%";
                    }

                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Ffmpeg_Started(object sender, EventArgs e)
        {
            try
            {
                // Invoke is needed to prevent error when control is accessed from a thread other than
                // the thread it was created on.
                Invoke(new MethodInvoker(delegate ()
                {
                    progressBar1.Value = 0;
                    progressBar1.Update();
                    progressBar1.Show();

                    lblProgress.Text = "";
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Ffmpeg_Finished(object sender, EventArgs e)
        {
            try
            {

                // Invoke is needed to prevent error when control is accessed from a thread other than
                // the thread it was created on.
                Invoke(new MethodInvoker(delegate ()
                {
                    progressBar1.Value = 100;
                    progressBar1.Update();

                    // does file exist?
                    if (System.IO.File.Exists(txtOutputFileName.Text))
                    {
                        lblProgress.Text = "Done";
                    }
                    else
                    {
                        lblProgress.Text = "Failed";
                        string message = "Output file was not created." + Environment.NewLine
                        + "FFMPEG reported: " + Environment.NewLine
                        + ffmpeg.GetErrorLine();
                        MessageBox.Show(message);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cboOutputBitRateABR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!fileLoading && rdoABR.Checked)
                UpdateFfmpegParam();
        }
    }
}

