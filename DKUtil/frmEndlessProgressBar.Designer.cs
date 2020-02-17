namespace Util
{
    partial class frmEndlessProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndlessProgressBar));
            this.endlessProgressBar1 = new EndlessProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // endlessProgressBar1
            // 
            this.endlessProgressBar1.AutoProgress = true;
            this.endlessProgressBar1.AutoProgressSpeed = 20;
            this.endlessProgressBar1.ForeColor = System.Drawing.Color.Blue;
            this.endlessProgressBar1.Location = new System.Drawing.Point(12, 61);
            this.endlessProgressBar1.Name = "endlessProgressBar1";
            this.endlessProgressBar1.NormalImage = ((System.Drawing.Image)(resources.GetObject("endlessProgressBar1.NormalImage")));
            this.endlessProgressBar1.PointImage = ((System.Drawing.Image)(resources.GetObject("endlessProgressBar1.PointImage")));
            this.endlessProgressBar1.Position = 10;
            this.endlessProgressBar1.ShowBorder = false;
            this.endlessProgressBar1.Size = new System.Drawing.Size(564, 22);
            this.endlessProgressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // frmEndlessProgressBar
            // 
            this.ClientSize = new System.Drawing.Size(582, 152);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endlessProgressBar1);
            this.MinimizeBox = false;
            this.Name = "frmEndlessProgressBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EndlessProgressBar endlessProgressBar1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}
