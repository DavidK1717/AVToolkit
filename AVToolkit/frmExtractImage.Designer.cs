namespace AVToolkit
{
    partial class frmExtractImage
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
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboWidth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.btnPlay);
            this.gpbAudio.Controls.Add(this.label5);
            this.gpbAudio.Controls.Add(this.cboWidth);
            this.gpbAudio.Controls.Add(this.label4);
            this.gpbAudio.Controls.Add(this.txtStartTime);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStartTime, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label4, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboWidth, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label5, 0);
            this.gpbAudio.Controls.SetChildIndex(this.btnPlay, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 52);
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(385, 156);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(76, 20);
            this.txtStartTime.TabIndex = 24;
            this.txtStartTime.Tag = "";
            this.txtStartTime.TextChanged += new System.EventHandler(this.txtStartTime_TextChanged);
            this.txtStartTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartTime_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Start time (HH:MM:SS):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboWidth
            // 
            this.cboWidth.FormattingEnabled = true;
            this.cboWidth.Location = new System.Drawing.Point(385, 197);
            this.cboWidth.Name = "cboWidth";
            this.cboWidth.Size = new System.Drawing.Size(121, 21);
            this.cboWidth.TabIndex = 26;
            this.cboWidth.SelectedIndexChanged += new System.EventHandler(this.cboWidth_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Image width (pixels):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::AVToolkit.Resource1.PlayVideo_16x;
            this.btnPlay.Location = new System.Drawing.Point(466, 154);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 23);
            this.btnPlay.TabIndex = 28;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // frmExtractImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 521);
            this.Name = "frmExtractImage";
            this.Text = "Extract Image";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.TextBox txtStartTime;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cboWidth;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Button btnPlay;
    }
}
