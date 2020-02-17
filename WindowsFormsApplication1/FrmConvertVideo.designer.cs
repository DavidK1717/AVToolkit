namespace AVToolkit
{
    partial class FrmConvertVideo
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
            this.label6 = new System.Windows.Forms.Label();
            this.cboAudioFileType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBitrate = new System.Windows.Forms.ComboBox();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.label6);
            this.gpbAudio.Controls.Add(this.cboAudioFileType);
            this.gpbAudio.Controls.Add(this.label5);
            this.gpbAudio.Controls.Add(this.cboBitrate);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboBitrate, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label5, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboAudioFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label6, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(330, 52);
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.Text = "File type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Audio encoder:";
            // 
            // cboAudioFileType
            // 
            this.cboAudioFileType.FormattingEnabled = true;
            this.cboAudioFileType.Location = new System.Drawing.Point(385, 148);
            this.cboAudioFileType.Name = "cboAudioFileType";
            this.cboAudioFileType.Size = new System.Drawing.Size(121, 21);
            this.cboAudioFileType.TabIndex = 30;
            this.cboAudioFileType.SelectedIndexChanged += new System.EventHandler(this.cboAudioFileType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Bit rate:";
            // 
            // cboBitrate
            // 
            this.cboBitrate.FormattingEnabled = true;
            this.cboBitrate.Location = new System.Drawing.Point(385, 184);
            this.cboBitrate.Name = "cboBitrate";
            this.cboBitrate.Size = new System.Drawing.Size(121, 21);
            this.cboBitrate.TabIndex = 28;
            // 
            // FrmConvertVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 521);
            this.Name = "FrmConvertVideo";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAudioFileType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBitrate;
    }
}
