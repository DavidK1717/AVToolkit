namespace AVToolkit
{
    partial class FrmOperationBitrate
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
            this.cboOutputBitRateABR = new System.Windows.Forms.ComboBox();
            this.rdoABR = new System.Windows.Forms.RadioButton();
            this.cboOutputBitRateVBR = new System.Windows.Forms.ComboBox();
            this.cboOutputBitRateCBR = new System.Windows.Forms.ComboBox();
            this.rdoCBR = new System.Windows.Forms.RadioButton();
            this.rdoVBR = new System.Windows.Forms.RadioButton();
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.cboOutputBitRateABR);
            this.gpbAudio.Controls.Add(this.rdoABR);
            this.gpbAudio.Controls.Add(this.cboOutputBitRateVBR);
            this.gpbAudio.Controls.Add(this.cboOutputBitRateCBR);
            this.gpbAudio.Controls.Add(this.rdoCBR);
            this.gpbAudio.Controls.Add(this.cboFileType);
            this.gpbAudio.Controls.Add(this.rdoVBR);
            this.gpbAudio.Controls.Add(this.label3);
            this.gpbAudio.Controls.SetChildIndex(this.label3, 0);
            this.gpbAudio.Controls.SetChildIndex(this.rdoVBR, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboFileType, 0);
            this.gpbAudio.Controls.SetChildIndex(this.rdoCBR, 0);
            this.gpbAudio.Controls.SetChildIndex(this.btnConvert, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboOutputBitRateCBR, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboOutputBitRateVBR, 0);
            this.gpbAudio.Controls.SetChildIndex(this.txtStreamDetails, 0);
            this.gpbAudio.Controls.SetChildIndex(this.rdoABR, 0);
            this.gpbAudio.Controls.SetChildIndex(this.lblStreams, 0);
            this.gpbAudio.Controls.SetChildIndex(this.cboOutputBitRateABR, 0);
            // 
            // cboOutputBitRateABR
            // 
            this.cboOutputBitRateABR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateABR.FormattingEnabled = true;
            this.cboOutputBitRateABR.Location = new System.Drawing.Point(386, 139);
            this.cboOutputBitRateABR.Name = "cboOutputBitRateABR";
            this.cboOutputBitRateABR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateABR.TabIndex = 25;
            this.cboOutputBitRateABR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateABR_SelectionChangeCommitted);
            // 
            // rdoABR
            // 
            this.rdoABR.AutoSize = true;
            this.rdoABR.Location = new System.Drawing.Point(322, 139);
            this.rdoABR.Name = "rdoABR";
            this.rdoABR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoABR.Size = new System.Drawing.Size(47, 17);
            this.rdoABR.TabIndex = 26;
            this.rdoABR.TabStop = true;
            this.rdoABR.Text = "ABR";
            this.rdoABR.UseVisualStyleBackColor = true;
            this.rdoABR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // cboOutputBitRateVBR
            // 
            this.cboOutputBitRateVBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateVBR.FormattingEnabled = true;
            this.cboOutputBitRateVBR.Location = new System.Drawing.Point(386, 92);
            this.cboOutputBitRateVBR.Name = "cboOutputBitRateVBR";
            this.cboOutputBitRateVBR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateVBR.TabIndex = 21;
            this.cboOutputBitRateVBR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateVBR_SelectionChangeCommitted);
            // 
            // cboOutputBitRateCBR
            // 
            this.cboOutputBitRateCBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateCBR.FormattingEnabled = true;
            this.cboOutputBitRateCBR.Location = new System.Drawing.Point(385, 187);
            this.cboOutputBitRateCBR.Name = "cboOutputBitRateCBR";
            this.cboOutputBitRateCBR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateCBR.TabIndex = 22;
            this.cboOutputBitRateCBR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateCBR_SelectionChangeCommitted);
            // 
            // rdoCBR
            // 
            this.rdoCBR.AutoSize = true;
            this.rdoCBR.Location = new System.Drawing.Point(322, 187);
            this.rdoCBR.Name = "rdoCBR";
            this.rdoCBR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoCBR.Size = new System.Drawing.Size(47, 17);
            this.rdoCBR.TabIndex = 23;
            this.rdoCBR.TabStop = true;
            this.rdoCBR.Text = "CBR";
            this.rdoCBR.UseVisualStyleBackColor = true;
            this.rdoCBR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdoVBR
            // 
            this.rdoVBR.AutoSize = true;
            this.rdoVBR.Location = new System.Drawing.Point(322, 92);
            this.rdoVBR.Name = "rdoVBR";
            this.rdoVBR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoVBR.Size = new System.Drawing.Size(47, 17);
            this.rdoVBR.TabIndex = 24;
            this.rdoVBR.TabStop = true;
            this.rdoVBR.Text = "VBR";
            this.rdoVBR.UseVisualStyleBackColor = true;
            this.rdoVBR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // frmOperationOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 521);
            this.Name = "frmOperationOutput";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.ComboBox cboOutputBitRateABR;
        protected System.Windows.Forms.RadioButton rdoABR;
        protected System.Windows.Forms.ComboBox cboOutputBitRateVBR;
        protected System.Windows.Forms.ComboBox cboOutputBitRateCBR;
        protected System.Windows.Forms.RadioButton rdoCBR;
        protected System.Windows.Forms.RadioButton rdoVBR;
    }
}
