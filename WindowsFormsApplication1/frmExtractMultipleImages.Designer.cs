namespace AVToolkit
{
    partial class frmExtractMultipleImages
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
            this.cboFPS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.btnPlayEnd = new System.Windows.Forms.Button();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(385, 185);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(274, 150);
            this.label5.Visible = false;
            // 
            // cboWidth
            // 
            this.cboWidth.Location = new System.Drawing.Point(384, 147);
            this.cboWidth.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(259, 188);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(466, 183);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(246, 77);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 484);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(456, 490);
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.btnPlayEnd);
            this.gpbAudio.Controls.Add(this.chkEnd);
            this.gpbAudio.Controls.Add(this.label7);
            this.gpbAudio.Controls.Add(this.txtDuration);
            this.gpbAudio.Controls.Add(this.label6);
            this.gpbAudio.Controls.Add(this.cboFPS);
            this.gpbAudio.Size = new System.Drawing.Size(525, 298);
            this.gpbAudio.Controls.SetChildIndex(this.btnPlay, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStartTime, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label4, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboWidth, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label5, 0);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFPS, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label6, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtDuration, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label7, 0);
            this.gpbAudio.Controls.SetChildIndex(this.chkEnd, 0);
            this.gpbAudio.Controls.SetChildIndex(this.btnPlayEnd, 0);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(13, 442);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 407);
            // 
            // cboFPS
            // 
            this.cboFPS.FormattingEnabled = true;
            this.cboFPS.Location = new System.Drawing.Point(384, 153);
            this.cboFPS.Name = "cboFPS";
            this.cboFPS.Size = new System.Drawing.Size(121, 21);
            this.cboFPS.TabIndex = 28;
            this.cboFPS.SelectedIndexChanged += new System.EventHandler(this.cboFPS_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Frames per second:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(327, 219);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(59, 20);
            this.txtDuration.TabIndex = 30;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            this.txtDuration.Validating += new System.ComponentModel.CancelEventHandler(this.txtDuration_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Duration (s):";
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnd.Location = new System.Drawing.Point(442, 222);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(63, 17);
            this.chkEnd.TabIndex = 32;
            this.chkEnd.Text = "To end:";
            this.chkEnd.UseVisualStyleBackColor = true;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // btnPlayEnd
            // 
            this.btnPlayEnd.Image = global::AVToolkit.Resource1.PlayVideo_16x;
            this.btnPlayEnd.Location = new System.Drawing.Point(392, 217);
            this.btnPlayEnd.Name = "btnPlayEnd";
            this.btnPlayEnd.Size = new System.Drawing.Size(40, 23);
            this.btnPlayEnd.TabIndex = 33;
            this.btnPlayEnd.UseVisualStyleBackColor = true;
            this.btnPlayEnd.Click += new System.EventHandler(this.btnPlayEnd_Click);
            // 
            // frmExtractMultipleImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 525);
            this.Name = "frmExtractMultipleImages";
            this.Text = "Extract Multiple Images";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox cboFPS;
        protected System.Windows.Forms.CheckBox chkEnd;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtDuration;
        protected System.Windows.Forms.Button btnPlayEnd;
    }
}
