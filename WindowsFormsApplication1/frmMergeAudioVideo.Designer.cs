namespace AVToolkit
{
    partial class frmMergeAudioVideo
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
            this.txtAudioFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAudioFile = new System.Windows.Forms.Button();
            this.cboBitrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboInputFileDetails = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAudioFileType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(79, 22);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(490, 20);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 547);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(456, 538);
            // 
            // txtFileDetails
            // 
            this.txtFileDetails.Location = new System.Drawing.Point(36, 198);
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.label7);
            this.gpbAudio.Controls.Add(this.label6);
            this.gpbAudio.Controls.Add(this.cboAudioFileType);
            this.gpbAudio.Controls.Add(this.cboInputFileDetails);
            this.gpbAudio.Controls.Add(this.label5);
            this.gpbAudio.Controls.Add(this.cboBitrate);
            this.gpbAudio.Location = new System.Drawing.Point(12, 148);
            this.gpbAudio.Size = new System.Drawing.Size(525, 307);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboBitrate, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label5, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboInputFileDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboAudioFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label6, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label7, 0);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(13, 505);
            // 
            // txtStreamDetails
            // 
            this.txtStreamDetails.Location = new System.Drawing.Point(23, 188);
            // 
            // cboStreams
            // 
            this.cboStreams.Location = new System.Drawing.Point(68, 159);
            // 
            // lblStreams
            // 
            this.lblStreams.Location = new System.Drawing.Point(15, 162);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 470);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.Text = "Video input:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 121);
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.Location = new System.Drawing.Point(79, 118);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 52);
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.Text = "Video encoder:";
            // 
            // txtAudioFile
            // 
            this.txtAudioFile.Location = new System.Drawing.Point(79, 71);
            this.txtAudioFile.Name = "txtAudioFile";
            this.txtAudioFile.ReadOnly = true;
            this.txtAudioFile.Size = new System.Drawing.Size(390, 20);
            this.txtAudioFile.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Audio input:";
            // 
            // btnAudioFile
            // 
            this.btnAudioFile.Image = global::AVToolkit.Resource1.OpenFolder_32x;
            this.btnAudioFile.Location = new System.Drawing.Point(490, 71);
            this.btnAudioFile.Name = "btnAudioFile";
            this.btnAudioFile.Size = new System.Drawing.Size(44, 44);
            this.btnAudioFile.TabIndex = 23;
            this.btnAudioFile.UseVisualStyleBackColor = true;
            this.btnAudioFile.Click += new System.EventHandler(this.btnAudioFile_Click);
            // 
            // cboBitrate
            // 
            this.cboBitrate.FormattingEnabled = true;
            this.cboBitrate.Location = new System.Drawing.Point(385, 241);
            this.cboBitrate.Name = "cboBitrate";
            this.cboBitrate.Size = new System.Drawing.Size(121, 21);
            this.cboBitrate.TabIndex = 23;
            this.cboBitrate.SelectedIndexChanged += new System.EventHandler(this.cboBitrate_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Bit rate:";
            // 
            // cboInputFileDetails
            // 
            this.cboInputFileDetails.FormattingEnabled = true;
            this.cboInputFileDetails.Items.AddRange(new object[] {
            "Video",
            "Audio"});
            this.cboInputFileDetails.Location = new System.Drawing.Point(68, 20);
            this.cboInputFileDetails.Name = "cboInputFileDetails";
            this.cboInputFileDetails.Size = new System.Drawing.Size(121, 21);
            this.cboInputFileDetails.TabIndex = 25;
            this.cboInputFileDetails.SelectedIndexChanged += new System.EventHandler(this.cboInputFileDetails_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Audio encoder:";
            // 
            // cboAudioFileType
            // 
            this.cboAudioFileType.FormattingEnabled = true;
            this.cboAudioFileType.Location = new System.Drawing.Point(385, 205);
            this.cboAudioFileType.Name = "cboAudioFileType";
            this.cboAudioFileType.Size = new System.Drawing.Size(121, 21);
            this.cboAudioFileType.TabIndex = 26;
            this.cboAudioFileType.SelectedIndexChanged += new System.EventHandler(this.cboAudioFileType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Input:";
            // 
            // frmMergeAudioVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 579);
            this.Controls.Add(this.btnAudioFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAudioFile);
            this.Name = "frmMergeAudioVideo";
            this.Text = "Merge audio and video files";
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
            this.Controls.SetChildIndex(this.txtAudioFile, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnAudioFile, 0);
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAudioFile;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Button btnAudioFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBitrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAudioFileType;
        private System.Windows.Forms.ComboBox cboInputFileDetails;
        private System.Windows.Forms.Label label7;
    }
}
