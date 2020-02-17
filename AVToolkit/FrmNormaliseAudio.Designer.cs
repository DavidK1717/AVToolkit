namespace AVToolkit
{
    partial class FrmNormaliseAudio
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
            this.txtLoudNormIn = new System.Windows.Forms.TextBox();
            this.txtLoudNormOut = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gpbAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFileType
            // 
            this.cboFileType.Location = new System.Drawing.Point(398, 9);
            this.cboFileType.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(311, 17);
            this.label3.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 431);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(13, 466);
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.txtLoudNormOut);
            this.gpbAudio.Controls.Add(this.txtLoudNormIn);
            this.gpbAudio.Size = new System.Drawing.Size(525, 322);
            this.gpbAudio.Controls.SetChildIndex(this.txtLoudNormIn, 0);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtLoudNormOut, 0);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(456, 555);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 548);
            // 
            // txtParam2
            // 
            this.txtParam2.Location = new System.Drawing.Point(12, 507);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(525, 20);
            this.txtParam2.TabIndex = 22;
            // 
            // txtLoudNormIn
            // 
            this.txtLoudNormIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoudNormIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoudNormIn.Location = new System.Drawing.Point(314, 12);
            this.txtLoudNormIn.Multiline = true;
            this.txtLoudNormIn.Name = "txtLoudNormIn";
            this.txtLoudNormIn.Size = new System.Drawing.Size(205, 154);
            this.txtLoudNormIn.TabIndex = 23;
            // 
            // txtLoudNormOut
            // 
            this.txtLoudNormOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoudNormOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoudNormOut.Location = new System.Drawing.Point(314, 179);
            this.txtLoudNormOut.Multiline = true;
            this.txtLoudNormOut.Name = "txtLoudNormOut";
            this.txtLoudNormOut.Size = new System.Drawing.Size(205, 134);
            this.txtLoudNormOut.TabIndex = 24;
            // 
            // FrmNormaliseAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 586);
            this.Controls.Add(this.txtParam2);
            this.Name = "FrmNormaliseAudio";
            this.Text = "Normalise Audio";
            this.Controls.SetChildIndex(this.lblWorking, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParam2;
        private System.Windows.Forms.TextBox txtLoudNormIn;
        private System.Windows.Forms.TextBox txtLoudNormOut;
    }
}
