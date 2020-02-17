namespace AVToolkit
{
    partial class FrmExtractSection
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
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(405, 55);
            this.label6.Visible = false;
            // 
            // cboFPS
            // 
            this.cboFPS.Location = new System.Drawing.Point(392, 52);
            this.cboFPS.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(403, 55);
            // 
            // cboWidth
            // 
            this.cboWidth.Location = new System.Drawing.Point(392, 52);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(403, 52);
            this.label3.Visible = false;
            // 
            // cboFileType
            // 
            this.cboFileType.Visible = false;
            // 
            // frmExtract_Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 525);
            this.Name = "FrmExtractSection";
            this.Text = "Extract Section (Audio or Video)";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
