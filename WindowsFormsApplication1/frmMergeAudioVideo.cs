using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmMergeAudioVideo : frmOperation
    {
        //protected string[] audioCodecs;

        public frmMergeAudioVideo()
        {
            InitializeComponent();

            if (!Tools.IsLibraryEnabled("libfdk_aac"))
            {
                AudioCodecs = new[] {"aac", "libmp3lame", "libopus"};
                AudioCodecExtensions = new[] {"aac", "mp3", "opus"};
            }
            else
            {
                AudioCodecs = new[] {"libfdk_aac", "aac", "libmp3lame", "libopus"};
                AudioCodecExtensions = new[] {"aac", "aac", "mp3", "opus"};
            }

            VideoCodecs = new[] {"Copy", "mp4", "mkv", "avi", "mpg", "webm", "opus"};
        }

        protected override void InstantiateOperationObject()
        {
            Op = new Merge(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void LoadFileTypesCombo()
        {
            cboFileType.Items.Clear();

            for (var i = 0; i < VideoCodecs.Length; i++)
                cboFileType.Items.Add(VideoCodecs[i]);
            cboFileType.SelectedIndex = 0;

            // also might as well do this here
            LoadAudioFileTypesCombo();
        }

        protected override void SetControlDefaults()
        {
            ResetInputFileDetailsCombo("Video");
        }

        private void ResetInputFileDetailsCombo(string fileType)
        {
            var index = cboInputFileDetails.FindStringExact(fileType);

            if (index != -1)
                cboInputFileDetails.SelectedIndex = index;
            else
                throw new InvalidOperationException("Invalid parameter for cboInputFileDetails.");
        }

        protected override void UpdateStreamDetails()
        {
            if (cboInputFileDetails.SelectedIndex == 0)
                UpdateStreamDetails(Op.InputFile);
            else if (cboInputFileDetails.SelectedIndex == 1)
                UpdateStreamDetails(Op.AudioInputFile);
            else
                throw new InvalidOperationException("Invalid cboInputFileDetails item.");
        }

        protected void LoadAudioFileTypesCombo()
        {
            cboAudioFileType.Items.Clear();

            for (var i = 0; i < AudioCodecs.Length; i++)
                cboAudioFileType.Items.Add(AudioCodecs[i] + " (" + AudioCodecExtensions[i] + ")");
            cboAudioFileType.SelectedIndex = 0;
        }

        protected void LoadBitrateCombo()
        {
            var codec = Op.OutputFile.AudioCodec;
            cboBitrate.Items.Clear();

            for (var i = 0; i < codec.AudioBitratesVBR.Length; i++)
            {
                var item = codec.AudioBitratesVBR_fmtd[i];
                cboBitrate.Items.Add(new ComboBoxItem(item, i));
            }
            cboBitrate.SelectedIndex = 0;
        }

        private void cboAudioFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Op.AssignAudioCodec(AudioCodecs[cboAudioFileType.SelectedIndex]);

            LoadBitrateCombo();

            //Op.OutputFile.AudioCodec.Bitrate = ((ComboBoxItem)cboBitrate.SelectedItem).HiddenValue;            

            if (!FileLoading)
                UpdateFfmpegParam();
        }

        private void btnAudioFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                // display selected file
                txtAudioFile.Text = openFileDialog1.FileName;

                var inputFile = new InputFile(txtAudioFile.Text);

                Op.AudioInputFile = inputFile;

                ResetInputFileDetailsCombo("Audio");

                UpdateInputDetails(inputFile);

                UpdateFfmpegParam();


                //txtAudioFile.Text = Op.OutputFile.Path;
            }
        }

        protected override void SetupOutput()
        {
            Op.AssignCodec(VideoCodecs[cboFileType.SelectedIndex]);

            if (Op.OutputFile.Codec.Ffmpeg_library == "Copy")
                Op.OutputFile.Codec.Extension = Path.GetExtension(Op.InputFile.Path);
            else
                Op.OutputFile.Codec.Extension = "." + VideoCodecs[cboFileType.SelectedIndex];

            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }

        protected override void FfmpegParamUpdate()
        {
            // problem: here we need the audio input file but what if it hasn't been loaded yet?
            if (txtAudioFile.Text.Length == 0) return;

            Op.OutputFile.Bitrate = ((ComboBoxItem) cboBitrate.SelectedItem).HiddenValue;
            base.FfmpegParamUpdate();
        }

        private void cboInputFileDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                if (cboInputFileDetails.SelectedIndex == 0)
                    UpdateInputDetails(Op.InputFile);
                else if (cboInputFileDetails.SelectedIndex == 1)
                    UpdateInputDetails(Op.AudioInputFile);
                else
                    throw new InvalidOperationException("Invalid cboInputFileDetails item.");
        }

        private void cboBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }
    }
}