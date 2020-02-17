using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using AVToolkit.Properties;

namespace AVToolkit
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Settings.Default["DownloadFolder"] = txtDownloadFolder.Text;
            Settings.Default["FfmpegFolder"] = txtFfmpegFolder.Text;
            Settings.Default["FfProbeFolder"] = txtFfProbeFolder.Text;
            Settings.Default["DefaultForm"] = cboDefault.SelectedValue.ToString();
            
            Settings.Default.Save();

            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtDownloadFolder.Text = Settings.Default["DownloadFolder"].ToString();
            txtFfmpegFolder.Text = Settings.Default["FfmpegFolder"].ToString();
            txtFfProbeFolder.Text = Settings.Default["FfProbeFolder"].ToString();

            var dataSource = new List<OperationForm>
            {
                new OperationForm() {Name = "None", Value = "None"},
                new OperationForm() {Name = "Convert to audio", Value = "frmConvertToAudio"},
                new OperationForm() {Name = "Convert to video", Value = "FrmConvertVideo"},
                new OperationForm() {Name = "Extract image from video", Value = "frmExtractImage"},
                new OperationForm() {Name = "Extract multiple images from video", Value = "frmExtractMultipleImages"},
                new OperationForm() {Name = "Extract section from video or audio", Value = "FrmExtractSection"},
                new OperationForm() {Name = "Create animated Gif", Value = "frmCreateGif"},
                new OperationForm() {Name = "Merge video && audio", Value = "frmMergeAudioVideo"},
                new OperationForm() {Name = "Normalise loudness", Value = "FrmNormaliseAudio"}
            };

            cboDefault.DataSource = dataSource;
            cboDefault.DisplayMember = "Name";
            cboDefault.ValueMember = "Value";
            cboDefault.DropDownStyle = ComboBoxStyle.DropDownList;

            cboDefault.SelectedValue = Settings.Default["DefaultForm"].ToString();
          
        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                    txtDownloadFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFfmpegFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                    txtFfmpegFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFfProbeFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                    txtFfProbeFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFfmpegFolder2_Click(object sender, EventArgs e)
        {
            try
            {
                var result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                    txtFfmpegFolder2.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }

    public class OperationForm
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}