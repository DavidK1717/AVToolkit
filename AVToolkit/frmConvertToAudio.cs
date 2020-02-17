using System;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmConvertToAudio : FrmOperationBitrate
    {
        public frmConvertToAudio()
        {
            InitializeComponent();

            if (Tools.IsLibraryEnabled("libfdk_aac"))
            {
                AudioCodecs = new[] {"libmp3lame", "libfdk_aac", "aac"};
                AudioCodecExtensions = new[] {"mp3", "aac", "aac"};
            }
            else
            {
                AudioCodecs = new[] {"libmp3lame", "aac"};
                AudioCodecExtensions = new[] {"mp3", "aac"};
            }
        }

        protected override void InstantiateOperationObject()
        {
            Op = new ConvertToAudio(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void LoadFileTypesCombo()
        {
            Codecs = (string[]) AudioCodecs.Clone();
            CodecExtensions = (string[]) AudioCodecExtensions.Clone();
            base.LoadFileTypesCombo();
        }

        protected override void FfmpegParamUpdate()
        {
            //MessageBox.Show("UpdateFfmpegParam");       

            if (bitRateEncoding == null)
            {
                // should never get here!
                MessageBox.Show("Please select either VBR, ABR or CBR.");
            }
            else
            {
                // has the output file path changed? If so we need to tell the OutputFile object.                

                if (txtOutputFileName.Text != Op.OutputFile.Path)
                    Op.OutputFile.Path = txtOutputFileName.Text;

                //BitrateMode encodingMode = (BitrateMode)Enum.Parse(typeof(BitrateMode), bitRateEncoding);
                ((ConvertToAudio) Op).EncodingMode = (BitrateMode) Enum.Parse(typeof(BitrateMode), bitRateEncoding);

                switch (((ConvertToAudio) Op).EncodingMode)
                {
                    case BitrateMode.CBR:
                    {
                        Op.OutputFile.Bitrate = ((ComboBoxItem) cboOutputBitRateCBR.SelectedItem).HiddenValue;
                        break;
                    }
                    case BitrateMode.VBR:
                    {
                        Op.OutputFile.Bitrate = ((ComboBoxItem) cboOutputBitRateVBR.SelectedItem).HiddenValue;
                        break;
                    }
                    case BitrateMode.ABR:
                    {
                        Op.OutputFile.Bitrate = ((ComboBoxItem) cboOutputBitRateABR.SelectedItem).HiddenValue;
                        break;
                    }
                    default:
                    {
                        Op.OutputFile.Bitrate = 0;
                        break;
                    }
                }

                Op.AssignParameterString();
                txtParam.Text = Op.ParameterString;
#if (DEBUG_LOGLEVEL) // -loglevel can be "quiet" "panic" "fatal" "error" "warning" "info" "verbose" "debug" "trace"
            txtParam.Text = txtParam.Text += " -loglevel debug";
#endif

                toolTip1.SetToolTip(txtParam, txtParam.Text);
            }
        }
    }
}