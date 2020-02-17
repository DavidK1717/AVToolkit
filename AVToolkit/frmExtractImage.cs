using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmExtractImage : frmOperation
    {
        public frmExtractImage()
        {
            InitializeComponent();

            VideoCodecs = new[] {"jpg", "png", "ppm"};
            VideoCodecExtensions = new[] {"jpg", "png", "ppm"};
        }

        protected override void InstantiateOperationObject()
        {
            Op = new ExtractImage(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void LoadFileTypesCombo()
        {
            cboFileType.Items.Clear();

            foreach (var t in VideoCodecs)
                cboFileType.Items.Add(t);

            cboFileType.SelectedIndex = 0;
        }

        protected override void SetupOutput()
        {
            // base class uses Codecs array
            Codecs = (string[]) VideoCodecs.Clone();
            CodecExtensions = (string[]) VideoCodecExtensions.Clone();
            base.SetupOutput();
        }

        protected override void FfmpegParamUpdate()
        {
            Op.OutputFile.StartTime = txtStartTime.Text;
            Op.OutputFile.Scale = cboWidth.Text;
            base.FfmpegParamUpdate();
        }

        protected void LoadImageWidthCombo()
        {
            var codec = Op.OutputFile.Codec;

            cboWidth.Items.Clear();

            foreach (var item in codec.ImageWidths)
                cboWidth.Items.Add(item);

            // set output file to same pixel width as input by default.
            var widthIndex = cboWidth.FindStringExact(Op.InputFile.Width.ToString());

            // if width is in drop down list then select it, otherwise enter it directly into the combobox
            if (widthIndex == -1)
                cboWidth.Text = Op.InputFile.Width.ToString();
            else
                cboWidth.SelectedIndex = widthIndex;
        }

        protected override void SetControlDefaults()
        {
            txtStartTime.Text = "00:00:00";
        }

        protected override void LoadCodecSpecificControls()
        {
            LoadImageWidthCombo();
        }

        protected bool ValidateStartTime()
        {
            var status = true;
            if (!Helper.IsValidTime(txtStartTime.Text))
            {
                errorProvider1.SetError(txtStartTime, "Please enter the time in the format hh:mm:ss ");
                status = false;
            }
            else
            {
                errorProvider1.SetError(txtStartTime, "");
            }
            return status;
        }

        private void cboWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }

        private void txtStartTime_Validating(object sender, CancelEventArgs e)
        {
            ValidateStartTime();
        }

        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            param_entryChanged(sender, e);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var frm = new frmPlay(txtFile.Text);

            var dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                frm.Close();
            }
            else if (dr == DialogResult.OK)
            {
                txtStartTime.Text = frm.GetPausedTimeString();
                frm.Close();
            }
        }
    }
}