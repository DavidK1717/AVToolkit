using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AVToolkit.Properties;
using Util;

namespace AVToolkit
{
    public partial class frmDownload : Form
    {
        

        public frmDownload()
        {
            InitializeComponent();

            //_maxRows = (int) Settings.Default["DownloadListMaximum"];
        }
        
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmConvert frm = new frmConvert();
            //frm.Show();
        }

        

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            frm.Show();
        }

        
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new frmTemp();
            //frm.Show();
        }

        private void toAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmConvertToAudio();
            frm.Show();
        }

        

        private void toAudiooldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmConvert frm = new frmConvert();
            //frm.Show();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmExtractImage();
            frm.Show();
        }

        private void multipleImagesFromVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmExtractMultipleImages();
            frm.Show();
        }

        private void animatedGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateGif();
            frm.Show();
        }

        private void sectionFromVideoOrAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmExtractSection();
            frm.Show();
        }

        private void videoAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmMergeAudioVideo();
            frm.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmConvertVideo();
            frm.Show();
        }

        private void normaliseLoudnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmNormaliseAudio();
            frm.Show();
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            var frm = new FrmExtractSection();
            frm.Show();
        }

        private void frmDownload_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmDownload_Shown(object sender, EventArgs e)
        {
            var formtocall = Settings.Default["DefaultForm"].ToString();

            // if a default operation has been set then call the approriate form
            if (formtocall != "None")
            {
                // rather than hard code the namespace, use the namespace of this form, which
                // should be the same as that of the form to call.
                var ns = this.GetType().Namespace;

                var frm = Activator.CreateInstance(Type.GetType(ns + "." + formtocall)) as Form;

                frm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}