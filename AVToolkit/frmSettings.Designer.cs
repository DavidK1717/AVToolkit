namespace AVToolkit
{
    partial class frmSettings
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
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.txtFfmpegFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDownloadFolder = new System.Windows.Forms.Button();
            this.btnFfmpegFolder = new System.Windows.Forms.Button();
            this.btnFfProbeFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFfProbeFolder = new System.Windows.Forms.TextBox();
            this.btnFfmpegFolder2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFfmpegFolder2 = new System.Windows.Forms.TextBox();
            this.cboDefault = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(168, 53);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(353, 20);
            this.txtDownloadFolder.TabIndex = 0;
            // 
            // txtFfmpegFolder
            // 
            this.txtFfmpegFolder.Location = new System.Drawing.Point(168, 117);
            this.txtFfmpegFolder.Name = "txtFfmpegFolder";
            this.txtFfmpegFolder.Size = new System.Drawing.Size(353, 20);
            this.txtFfmpegFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Download folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FFMPEG folder:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(483, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Save && Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Image = global::AVToolkit.Resource1.OpenFolder_16x;
            this.btnDownloadFolder.Location = new System.Drawing.Point(527, 53);
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(31, 31);
            this.btnDownloadFolder.TabIndex = 7;
            this.btnDownloadFolder.UseVisualStyleBackColor = true;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDownloadFolder_Click);
            // 
            // btnFfmpegFolder
            // 
            this.btnFfmpegFolder.Image = global::AVToolkit.Resource1.OpenFolder_16x;
            this.btnFfmpegFolder.Location = new System.Drawing.Point(527, 117);
            this.btnFfmpegFolder.Name = "btnFfmpegFolder";
            this.btnFfmpegFolder.Size = new System.Drawing.Size(31, 31);
            this.btnFfmpegFolder.TabIndex = 8;
            this.btnFfmpegFolder.UseVisualStyleBackColor = true;
            this.btnFfmpegFolder.Click += new System.EventHandler(this.btnFfmpegFolder_Click);
            // 
            // btnFfProbeFolder
            // 
            this.btnFfProbeFolder.Image = global::AVToolkit.Resource1.OpenFolder_16x;
            this.btnFfProbeFolder.Location = new System.Drawing.Point(527, 181);
            this.btnFfProbeFolder.Name = "btnFfProbeFolder";
            this.btnFfProbeFolder.Size = new System.Drawing.Size(31, 31);
            this.btnFfProbeFolder.TabIndex = 11;
            this.btnFfProbeFolder.UseVisualStyleBackColor = true;
            this.btnFfProbeFolder.Click += new System.EventHandler(this.btnFfProbeFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "FFProbe folder:";
            // 
            // txtFfProbeFolder
            // 
            this.txtFfProbeFolder.Location = new System.Drawing.Point(168, 181);
            this.txtFfProbeFolder.Name = "txtFfProbeFolder";
            this.txtFfProbeFolder.Size = new System.Drawing.Size(353, 20);
            this.txtFfProbeFolder.TabIndex = 9;
            // 
            // btnFfmpegFolder2
            // 
            this.btnFfmpegFolder2.Image = global::AVToolkit.Resource1.OpenFolder_16x;
            this.btnFfmpegFolder2.Location = new System.Drawing.Point(527, 287);
            this.btnFfmpegFolder2.Name = "btnFfmpegFolder2";
            this.btnFfmpegFolder2.Size = new System.Drawing.Size(31, 31);
            this.btnFfmpegFolder2.TabIndex = 14;
            this.btnFfmpegFolder2.UseVisualStyleBackColor = true;
            this.btnFfmpegFolder2.Visible = false;
            this.btnFfmpegFolder2.Click += new System.EventHandler(this.btnFfmpegFolder2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "2nd FFMPEG folder:";
            this.label5.Visible = false;
            // 
            // txtFfmpegFolder2
            // 
            this.txtFfmpegFolder2.Location = new System.Drawing.Point(168, 287);
            this.txtFfmpegFolder2.Name = "txtFfmpegFolder2";
            this.txtFfmpegFolder2.Size = new System.Drawing.Size(353, 20);
            this.txtFfmpegFolder2.TabIndex = 12;
            this.txtFfmpegFolder2.Visible = false;
            // 
            // cboDefault
            // 
            this.cboDefault.FormattingEnabled = true;
            this.cboDefault.Location = new System.Drawing.Point(168, 242);
            this.cboDefault.Name = "cboDefault";
            this.cboDefault.Size = new System.Drawing.Size(268, 21);
            this.cboDefault.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(38, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Default Screen:";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 395);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDefault);
            this.Controls.Add(this.btnFfmpegFolder2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFfmpegFolder2);
            this.Controls.Add(this.btnFfProbeFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFfProbeFolder);
            this.Controls.Add(this.btnFfmpegFolder);
            this.Controls.Add(this.btnDownloadFolder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFfmpegFolder);
            this.Controls.Add(this.txtDownloadFolder);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.TextBox txtFfmpegFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDownloadFolder;
        private System.Windows.Forms.Button btnFfmpegFolder;
        private System.Windows.Forms.Button btnFfProbeFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFfProbeFolder;
        private System.Windows.Forms.Button btnFfmpegFolder2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFfmpegFolder2;
        private System.Windows.Forms.ComboBox cboDefault;
    }
}