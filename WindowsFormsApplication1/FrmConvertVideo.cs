using System;
using System.Linq;
using Util;

namespace AVToolkit
{
    public partial class FrmConvertVideo : frmOperation
    {
        public FrmConvertVideo()
        {
            InitializeComponent();

            VideoCodecs = new[] {"mp4", "mkv", "avi", "mpg", "webm", "opus"};
        }

        protected override void InstantiateOperationObject()
        {
            Op = new ConvertVideo(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void LoadFileTypesCombo()
        {
            AudioCodecs = Tools.IsLibraryEnabled("libfdk_aac")
                ? new[] {"Copy", "libfdk_aac", "aac", "libmp3lame", "libopus"}
                : new[] {"Copy", "aac", "libmp3lame", "libopus"};

            // Need to do this before loading file type combo because it triggers the setting of the audio codec
            // which is needed by the method that sets the parameter string which is triggered by the file type
            // combo selected index change.
            LoadAudioFileTypesCombo();

            cboFileType.Items.Clear();

            foreach (var t in VideoCodecs)
                cboFileType.Items.Add(t);
            cboFileType.SelectedIndex = 0;
        }

        protected override void SetupOutput()
        {
            // sets the output file name and the video codec to be used.
            Op.AssignCodec("Copy");
            Op.OutputFile.Codec.Extension = "." + VideoCodecs[cboFileType.SelectedIndex];
            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }

        protected void LoadAudioFileTypesCombo()
        {
            cboAudioFileType.Items.Clear();

            foreach (var t in AudioCodecs)
                cboAudioFileType.Items.Add(t);
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

            if (AudioCodecs[cboAudioFileType.SelectedIndex] == "Copy")
            {
                cboBitrate.Enabled = false;
            }
            else
            {
                cboBitrate.Enabled = true;
                LoadBitrateCombo();

                Op.OutputFile.AudioCodec.Bitrate = ((ComboBoxItem) cboBitrate.SelectedItem).HiddenValue;
            }

            if (!FileLoading)
                UpdateFfmpegParam();
        }
    }
}