namespace AVToolkit
{
    partial class frmCreateGif
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtParam2 = new System.Windows.Forms.TextBox();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(388, 24);
            this.label6.Visible = false;
            // 
            // cboFPS
            // 
            this.cboFPS.Location = new System.Drawing.Point(177, 11);
            this.cboFPS.Visible = false;
            // 
            // chkEnd
            // 
            this.chkEnd.Location = new System.Drawing.Point(408, 23);
            this.chkEnd.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(340, 224);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(408, 220);
            // 
            // btnPlayEnd
            // 
            this.btnPlayEnd.Location = new System.Drawing.Point(472, 217);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(391, 183);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(386, 22);
            // 
            // cboWidth
            // 
            this.cboWidth.Location = new System.Drawing.Point(385, 19);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(265, 186);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(472, 181);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 515);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(456, 521);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(418, 24);
            this.label3.Visible = false;
            // 
            // cboFileType
            // 
            this.cboFileType.Location = new System.Drawing.Point(382, 19);
            this.cboFileType.Visible = false;
            // 
            // txtParam2
            // 
            this.txtParam2.Location = new System.Drawing.Point(12, 479);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(525, 20);
            this.txtParam2.TabIndex = 21;
            // 
            // frmCreateGif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.txtParam2);
            this.Name = "frmCreateGif";
            this.Text = "Create Animated Gif";
            this.Controls.SetChildIndex(this.gpbAudio, 0);
            this.Controls.SetChildIndex(this.txtFile, 0);
            this.Controls.SetChildIndex(this.btnFile, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.Controls.SetChildIndex(this.txtFileDetails, 0);
            this.Controls.SetChildIndex(this.txtParam, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtOutputFileName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtParam2, 0);
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParam2;
    }
}
