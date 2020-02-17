using System;
using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class FrmOperationBitrate : frmOperation
    {
        protected string bitRateEncoding;

        public FrmOperationBitrate()
        {
            InitializeComponent();
        }

        protected override void SetControlDefaults()
        {
            // make sure one is checked by default
            rdoCBR.Checked = true;
        }

        protected override void LoadCodecSpecificControls()
        {
            LoadBitrateCombos();
        }

        protected override void PerformOperation()
        {
            if (bitRateEncoding == null)
                MessageBox.Show("Please select either VBR, ABR or CBR.");
            else
                base.PerformOperation();
        }

        protected void LoadBitrateCombos()
        {
            var codec = Op.OutputFile.Codec;

            cboOutputBitRateCBR.Items.Clear();
            cboOutputBitRateVBR.Items.Clear();
            cboOutputBitRateABR.Items.Clear();

            // load CBR combo & ABR (uses same values)
            for (var i = 0; i < codec.AudioBitratesCBR.Length; i++)
            {
                var item = codec.AudioBitratesCBR_fmtd[i];
                cboOutputBitRateCBR.Items.Add(new ComboBoxItem(item, codec.AudioBitratesCBR[i]));
                cboOutputBitRateABR.Items.Add(new ComboBoxItem(item, codec.AudioBitratesCBR[i]));
            }
            cboOutputBitRateCBR.SelectedIndex = 0;
            cboOutputBitRateABR.SelectedIndex = 0;

            // load VBR combo
            for (var i = 0; i < codec.AudioBitratesVBR.Length; i++)
            {
                var item = codec.AudioBitratesVBR_fmtd[i];
                cboOutputBitRateVBR.Items.Add(new ComboBoxItem(item, i));
            }
            cboOutputBitRateVBR.SelectedIndex = 0;
        }

        protected void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            // Executed when any radio button is changed.
            // ... It is wired up to every single radio button.

            var rb = (RadioButton) sender;

            if (!rb.Checked) return;
            bitRateEncoding = rb.Text;

            if (!FileLoading)
                UpdateFfmpegParam();
        }

        protected void cboOutputBitRateVBR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!FileLoading && rdoVBR.Checked)
                UpdateFfmpegParam();
        }

        protected void cboOutputBitRateCBR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!FileLoading && rdoCBR.Checked)
                UpdateFfmpegParam();
        }

        protected void cboOutputBitRateABR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!FileLoading && rdoABR.Checked)
                UpdateFfmpegParam();
        }
    }
}