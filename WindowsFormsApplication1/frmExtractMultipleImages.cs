using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmExtractMultipleImages : frmExtractImage
    {
        public frmExtractMultipleImages()
        {
            InitializeComponent();
        }

        protected override void InstantiateOperationObject()
        {
            Op = new ExtractMultipleImages(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected void LoadFpsCombo()
        {
            var codec = Op.OutputFile.Codec;

            cboFPS.Items.Clear();

            foreach (var item in codec.ImageFrequency)
                cboFPS.Items.Add(item);
            cboFPS.SelectedIndex = 0;
        }

        protected override void SetControlDefaults()
        {
            base.SetControlDefaults();

            chkEnd.Checked = true;
        }

        protected override void LoadCodecSpecificControls()
        {
            LoadFpsCombo();
        }

        protected bool ValidateDuration()
        {
            var status = true;
            //if (!Helper.IsNullorEmptyTrim(txtDuration.Text))
            //{
            if (Helper.IsAllDigits(txtDuration.Text) == false && !chkEnd.Checked)
            {
                errorProvider1.SetError(txtDuration, "Please enter a duration in seconds or select 'To End'");
                status = false;
            }
            else
            {
                errorProvider1.SetError(txtDuration, "");
            }
            //}
            // else
            //     errorProvider1.SetError(txtStartTime, "");

            return status;
        }

        protected override void FfmpegParamUpdate()
        {
            Op.OutputFile.StartTime = txtStartTime.Text;
            Op.OutputFile.Fps = Op.OutputFile.Codec.Fps[cboFPS.SelectedIndex];
            Op.OutputFile.Duration = txtDuration.Text;
            Op.OutputFile.ToEnd = chkEnd.Checked;
            CreateParameterString();
        }

        protected override bool ParameterCheck()
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
                        if (result[result.Count - 1].Value.TrimStart('"').TrimEnd('"').GetUntilOrEmpty("_%03d") != Path.GetFileNameWithoutExtension(txtOutputFileName.Text))
                        {
                            // try rebuilding output file name
                            txtOutputFileName.Text = result[result.Count - 1].Value.TrimStart('"').TrimEnd('"').GetUntilOrEmpty("_%03d") + Path.GetExtension(txtOutputFileName.Text);
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

        private void cboFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (!FileLoading)
                UpdateFfmpegParam();
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            ValidateDuration();
        }

        private void btnPlayEnd_Click(object sender, EventArgs e)
        {
            var startSecond = Helper.FormattedTimeToSeconds(txtStartTime.Text);

            if (startSecond != -1)
            {
                // play video from start time
                var frm = new frmPlay(txtFile.Text, startSecond);

                var dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel)
                {
                    frm.Close();
                }
                else if (dr == DialogResult.OK)
                {
                    var endSecond = frm.GetPausedTime();

                    var duration = endSecond - startSecond;
                    txtDuration.Text = ((int) duration).ToString();
                    chkEnd.Checked = false;

                    frm.Close();
                }
            }
            else
            {
                MessageBox.Show("Start time is not in the correct format.");
                txtStartTime.Focus();
            }
        }
    }
}