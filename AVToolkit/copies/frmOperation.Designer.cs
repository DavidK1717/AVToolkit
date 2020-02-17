namespace VD
{
    partial class frmOperation
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFileDetails = new System.Windows.Forms.TextBox();
            this.cboOutputBitRateVBR = new System.Windows.Forms.ComboBox();
            this.cboOutputBitRateCBR = new System.Windows.Forms.ComboBox();
            this.rdoCBR = new System.Windows.Forms.RadioButton();
            this.rdoVBR = new System.Windows.Forms.RadioButton();
            this.gpbAudio = new System.Windows.Forms.GroupBox();
            this.lblStreams = new System.Windows.Forms.Label();
            this.cboOutputBitRateABR = new System.Windows.Forms.ComboBox();
            this.rdoABR = new System.Windows.Forms.RadioButton();
            this.txtStreamDetails = new System.Windows.Forms.TextBox();
            this.cboStreams = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputFileName = new System.Windows.Forms.TextBox();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gpbAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(60, 22);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(390, 20);
            this.txtFile.TabIndex = 0;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.Yellow;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConvert.Font = new System.Drawing.Font("Symbol", 20F, System.Drawing.FontStyle.Bold);
            this.btnConvert.Location = new System.Drawing.Point(246, 92);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(52, 46);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Þ";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 476);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(437, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(456, 483);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 4;
            // 
            // btnFile
            // 
            this.btnFile.Image = global::VD.Resource1.OpenFolder_32x;
            this.btnFile.Location = new System.Drawing.Point(474, 20);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(44, 44);
            this.btnFile.TabIndex = 1;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFileDetails
            // 
            this.txtFileDetails.BackColor = System.Drawing.Color.LightBlue;
            this.txtFileDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileDetails.Enabled = false;
            this.txtFileDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileDetails.Location = new System.Drawing.Point(36, 116);
            this.txtFileDetails.Multiline = true;
            this.txtFileDetails.Name = "txtFileDetails";
            this.txtFileDetails.Size = new System.Drawing.Size(208, 96);
            this.txtFileDetails.TabIndex = 5;
            // 
            // cboOutputBitRateVBR
            // 
            this.cboOutputBitRateVBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateVBR.FormattingEnabled = true;
            this.cboOutputBitRateVBR.Location = new System.Drawing.Point(385, 93);
            this.cboOutputBitRateVBR.Name = "cboOutputBitRateVBR";
            this.cboOutputBitRateVBR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateVBR.TabIndex = 7;
            this.cboOutputBitRateVBR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateVBR_SelectionChangeCommitted);
            // 
            // cboOutputBitRateCBR
            // 
            this.cboOutputBitRateCBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateCBR.FormattingEnabled = true;
            this.cboOutputBitRateCBR.Location = new System.Drawing.Point(384, 188);
            this.cboOutputBitRateCBR.Name = "cboOutputBitRateCBR";
            this.cboOutputBitRateCBR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateCBR.TabIndex = 8;
            this.cboOutputBitRateCBR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateCBR_SelectionChangeCommitted);
            // 
            // rdoCBR
            // 
            this.rdoCBR.AutoSize = true;
            this.rdoCBR.Location = new System.Drawing.Point(321, 188);
            this.rdoCBR.Name = "rdoCBR";
            this.rdoCBR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoCBR.Size = new System.Drawing.Size(47, 17);
            this.rdoCBR.TabIndex = 10;
            this.rdoCBR.TabStop = true;
            this.rdoCBR.Text = "CBR";
            this.rdoCBR.UseVisualStyleBackColor = true;
            this.rdoCBR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdoVBR
            // 
            this.rdoVBR.AutoSize = true;
            this.rdoVBR.Location = new System.Drawing.Point(321, 93);
            this.rdoVBR.Name = "rdoVBR";
            this.rdoVBR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoVBR.Size = new System.Drawing.Size(47, 17);
            this.rdoVBR.TabIndex = 11;
            this.rdoVBR.TabStop = true;
            this.rdoVBR.Text = "VBR";
            this.rdoVBR.UseVisualStyleBackColor = true;
            this.rdoVBR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // gpbAudio
            // 
            this.gpbAudio.Controls.Add(this.lblStreams);
            this.gpbAudio.Controls.Add(this.cboOutputBitRateABR);
            this.gpbAudio.Controls.Add(this.rdoABR);
            this.gpbAudio.Controls.Add(this.cboOutputBitRateVBR);
            this.gpbAudio.Controls.Add(this.cboOutputBitRateCBR);
            this.gpbAudio.Controls.Add(this.txtStreamDetails);
            this.gpbAudio.Controls.Add(this.cboStreams);
            this.gpbAudio.Controls.Add(this.rdoCBR);
            this.gpbAudio.Controls.Add(this.rdoVBR);
            this.gpbAudio.Controls.Add(this.btnConvert);
            this.gpbAudio.Controls.Add(this.label3);
            this.gpbAudio.Controls.Add(this.cboFileType);
            this.gpbAudio.Location = new System.Drawing.Point(12, 92);
            this.gpbAudio.Name = "gpbAudio";
            this.gpbAudio.Size = new System.Drawing.Size(525, 291);
            this.gpbAudio.TabIndex = 12;
            this.gpbAudio.TabStop = false;
            this.gpbAudio.Text = "Audio Output Configuration";
            // 
            // lblStreams
            // 
            this.lblStreams.AutoSize = true;
            this.lblStreams.Location = new System.Drawing.Point(20, 153);
            this.lblStreams.Name = "lblStreams";
            this.lblStreams.Size = new System.Drawing.Size(48, 13);
            this.lblStreams.TabIndex = 17;
            this.lblStreams.Text = "Streams:";
            // 
            // cboOutputBitRateABR
            // 
            this.cboOutputBitRateABR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBitRateABR.FormattingEnabled = true;
            this.cboOutputBitRateABR.Location = new System.Drawing.Point(385, 140);
            this.cboOutputBitRateABR.Name = "cboOutputBitRateABR";
            this.cboOutputBitRateABR.Size = new System.Drawing.Size(121, 21);
            this.cboOutputBitRateABR.TabIndex = 15;
            this.cboOutputBitRateABR.SelectionChangeCommitted += new System.EventHandler(this.cboOutputBitRateABR_SelectionChangeCommitted);
            // 
            // rdoABR
            // 
            this.rdoABR.AutoSize = true;
            this.rdoABR.Location = new System.Drawing.Point(321, 140);
            this.rdoABR.Name = "rdoABR";
            this.rdoABR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoABR.Size = new System.Drawing.Size(47, 17);
            this.rdoABR.TabIndex = 16;
            this.rdoABR.TabStop = true;
            this.rdoABR.Text = "ABR";
            this.rdoABR.UseVisualStyleBackColor = true;
            this.rdoABR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // txtStreamDetails
            // 
            this.txtStreamDetails.BackColor = System.Drawing.Color.LightBlue;
            this.txtStreamDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStreamDetails.Enabled = false;
            this.txtStreamDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreamDetails.Location = new System.Drawing.Point(23, 177);
            this.txtStreamDetails.Multiline = true;
            this.txtStreamDetails.Name = "txtStreamDetails";
            this.txtStreamDetails.Size = new System.Drawing.Size(208, 102);
            this.txtStreamDetails.TabIndex = 14;
            // 
            // cboStreams
            // 
            this.cboStreams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStreams.FormattingEnabled = true;
            this.cboStreams.Location = new System.Drawing.Point(68, 148);
            this.cboStreams.Name = "cboStreams";
            this.cboStreams.Size = new System.Drawing.Size(121, 21);
            this.cboStreams.TabIndex = 12;
            this.cboStreams.SelectedIndexChanged += new System.EventHandler(this.cboStreams_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File type:";
            // 
            // cboFileType
            // 
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(384, 49);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(121, 21);
            this.cboFileType.TabIndex = 0;
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.cboFileType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.Location = new System.Drawing.Point(60, 48);
            this.txtOutputFileName.Name = "txtOutputFileName";
            this.txtOutputFileName.Size = new System.Drawing.Size(390, 20);
            this.txtOutputFileName.TabIndex = 1;
            this.txtOutputFileName.TextChanged += new System.EventHandler(this.param_entryChanged);
            this.txtOutputFileName.Validating += new System.ComponentModel.CancelEventHandler(this.txtOutputFileName_Validating);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(13, 434);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(525, 20);
            this.txtParam.TabIndex = 13;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(13, 399);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(525, 29);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "These are the arguments to be used by FFMPEG. They can be edited directly to over" +
    "ride or fine tune the options selected above.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Input:";
            // 
            // frmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(550, 521);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.txtFileDetails);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gpbAudio);
            this.Controls.Add(this.txtOutputFileName);
            this.Name = "frmOperation";
            this.Text = "Convert to Audio";
            this.gpbAudio.ResumeLayout(false);
            this.gpbAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtFileDetails;
        private System.Windows.Forms.ComboBox cboOutputBitRateVBR;
        private System.Windows.Forms.ComboBox cboOutputBitRateCBR;
        private System.Windows.Forms.RadioButton rdoCBR;
        private System.Windows.Forms.RadioButton rdoVBR;
        private System.Windows.Forms.GroupBox gpbAudio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtStreamDetails;
        private System.Windows.Forms.ComboBox cboStreams;
        private System.Windows.Forms.ComboBox cboOutputBitRateABR;
        private System.Windows.Forms.RadioButton rdoABR;
        private System.Windows.Forms.Label lblStreams;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}