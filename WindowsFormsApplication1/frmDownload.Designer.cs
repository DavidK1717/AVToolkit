namespace AVToolkit
{
    partial class frmDownload
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleImagesFromVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionFromVideoOrAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animatedGifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normaliseLoudnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConvertToAudio = new System.Windows.Forms.Button();
            this.btnConvertVideo = new System.Windows.Forms.Button();
            this.btnExtractImage = new System.Windows.Forms.Button();
            this.btnExtractMultipleImages = new System.Windows.Forms.Button();
            this.btnExtractSection = new System.Windows.Forms.Button();
            this.btnCreateGif = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnNormaliseLoudness = new System.Windows.Forms.Button();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToolStripMenuItem,
            this.extractToolStripMenuItem,
            this.createToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.normaliseLoudnessToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toAudioToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.convertToolStripMenuItem.Text = "Convert";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // toAudioToolStripMenuItem
            // 
            this.toAudioToolStripMenuItem.Name = "toAudioToolStripMenuItem";
            this.toAudioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toAudioToolStripMenuItem.Text = "To Audio";
            this.toAudioToolStripMenuItem.Click += new System.EventHandler(this.toAudioToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videoToolStripMenuItem.Text = "Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.multipleImagesFromVideoToolStripMenuItem,
            this.sectionFromVideoOrAudioToolStripMenuItem});
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.extractToolStripMenuItem.Text = "Extract";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.imageToolStripMenuItem.Text = "Image from video";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // multipleImagesFromVideoToolStripMenuItem
            // 
            this.multipleImagesFromVideoToolStripMenuItem.Name = "multipleImagesFromVideoToolStripMenuItem";
            this.multipleImagesFromVideoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.multipleImagesFromVideoToolStripMenuItem.Text = "Multiple images from video";
            this.multipleImagesFromVideoToolStripMenuItem.Click += new System.EventHandler(this.multipleImagesFromVideoToolStripMenuItem_Click);
            // 
            // sectionFromVideoOrAudioToolStripMenuItem
            // 
            this.sectionFromVideoOrAudioToolStripMenuItem.Name = "sectionFromVideoOrAudioToolStripMenuItem";
            this.sectionFromVideoOrAudioToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.sectionFromVideoOrAudioToolStripMenuItem.Text = "Section from video or audio";
            this.sectionFromVideoOrAudioToolStripMenuItem.Click += new System.EventHandler(this.sectionFromVideoOrAudioToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animatedGifToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // animatedGifToolStripMenuItem
            // 
            this.animatedGifToolStripMenuItem.Name = "animatedGifToolStripMenuItem";
            this.animatedGifToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.animatedGifToolStripMenuItem.Text = "Animated Gif";
            this.animatedGifToolStripMenuItem.Click += new System.EventHandler(this.animatedGifToolStripMenuItem_Click);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoAudioToolStripMenuItem});
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.mergeToolStripMenuItem.Text = "Merge";
            // 
            // videoAudioToolStripMenuItem
            // 
            this.videoAudioToolStripMenuItem.Name = "videoAudioToolStripMenuItem";
            this.videoAudioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videoAudioToolStripMenuItem.Text = "Video && Audio";
            this.videoAudioToolStripMenuItem.Click += new System.EventHandler(this.videoAudioToolStripMenuItem_Click);
            // 
            // normaliseLoudnessToolStripMenuItem
            // 
            this.normaliseLoudnessToolStripMenuItem.Name = "normaliseLoudnessToolStripMenuItem";
            this.normaliseLoudnessToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.normaliseLoudnessToolStripMenuItem.Text = "Normalise Loudness";
            this.normaliseLoudnessToolStripMenuItem.Click += new System.EventHandler(this.normaliseLoudnessToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnConvertToAudio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConvertVideo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExtractImage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExtractMultipleImages, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExtractSection, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateGif, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMerge, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNormaliseLoudness, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 253);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnConvertToAudio
            // 
            this.btnConvertToAudio.BackColor = System.Drawing.Color.White;
            this.btnConvertToAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConvertToAudio.Location = new System.Drawing.Point(3, 3);
            this.btnConvertToAudio.Name = "btnConvertToAudio";
            this.btnConvertToAudio.Size = new System.Drawing.Size(175, 119);
            this.btnConvertToAudio.TabIndex = 11;
            this.btnConvertToAudio.Text = "Convert to Audio";
            this.btnConvertToAudio.UseVisualStyleBackColor = false;
            this.btnConvertToAudio.Click += new System.EventHandler(this.toAudioToolStripMenuItem_Click);
            // 
            // btnConvertVideo
            // 
            this.btnConvertVideo.BackColor = System.Drawing.Color.White;
            this.btnConvertVideo.Location = new System.Drawing.Point(184, 3);
            this.btnConvertVideo.Name = "btnConvertVideo";
            this.btnConvertVideo.Size = new System.Drawing.Size(175, 119);
            this.btnConvertVideo.TabIndex = 12;
            this.btnConvertVideo.Text = "Convert Video";
            this.btnConvertVideo.UseVisualStyleBackColor = false;
            this.btnConvertVideo.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // btnExtractImage
            // 
            this.btnExtractImage.BackColor = System.Drawing.Color.White;
            this.btnExtractImage.Location = new System.Drawing.Point(365, 3);
            this.btnExtractImage.Name = "btnExtractImage";
            this.btnExtractImage.Size = new System.Drawing.Size(175, 120);
            this.btnExtractImage.TabIndex = 13;
            this.btnExtractImage.Text = "Extract Image from Video";
            this.btnExtractImage.UseVisualStyleBackColor = false;
            this.btnExtractImage.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // btnExtractMultipleImages
            // 
            this.btnExtractMultipleImages.BackColor = System.Drawing.Color.White;
            this.btnExtractMultipleImages.Location = new System.Drawing.Point(546, 3);
            this.btnExtractMultipleImages.Name = "btnExtractMultipleImages";
            this.btnExtractMultipleImages.Size = new System.Drawing.Size(177, 120);
            this.btnExtractMultipleImages.TabIndex = 14;
            this.btnExtractMultipleImages.Text = "Extract Multiple Images from Video";
            this.btnExtractMultipleImages.UseVisualStyleBackColor = false;
            this.btnExtractMultipleImages.Click += new System.EventHandler(this.multipleImagesFromVideoToolStripMenuItem_Click);
            // 
            // btnExtractSection
            // 
            this.btnExtractSection.BackColor = System.Drawing.Color.White;
            this.btnExtractSection.Location = new System.Drawing.Point(3, 129);
            this.btnExtractSection.Name = "btnExtractSection";
            this.btnExtractSection.Size = new System.Drawing.Size(175, 121);
            this.btnExtractSection.TabIndex = 15;
            this.btnExtractSection.Text = "Extract Section from Video or Audio";
            this.btnExtractSection.UseVisualStyleBackColor = false;
            this.btnExtractSection.Click += new System.EventHandler(this.sectionFromVideoOrAudioToolStripMenuItem_Click);
            // 
            // btnCreateGif
            // 
            this.btnCreateGif.BackColor = System.Drawing.Color.White;
            this.btnCreateGif.Location = new System.Drawing.Point(184, 129);
            this.btnCreateGif.Name = "btnCreateGif";
            this.btnCreateGif.Size = new System.Drawing.Size(175, 121);
            this.btnCreateGif.TabIndex = 16;
            this.btnCreateGif.Text = "Create Animated Gif";
            this.btnCreateGif.UseVisualStyleBackColor = false;
            this.btnCreateGif.Click += new System.EventHandler(this.animatedGifToolStripMenuItem_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.BackColor = System.Drawing.Color.White;
            this.btnMerge.Location = new System.Drawing.Point(365, 129);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(175, 121);
            this.btnMerge.TabIndex = 17;
            this.btnMerge.Text = "Merge Video && Audio";
            this.btnMerge.UseVisualStyleBackColor = false;
            this.btnMerge.Click += new System.EventHandler(this.videoAudioToolStripMenuItem_Click);
            // 
            // btnNormaliseLoudness
            // 
            this.btnNormaliseLoudness.BackColor = System.Drawing.Color.White;
            this.btnNormaliseLoudness.Location = new System.Drawing.Point(546, 129);
            this.btnNormaliseLoudness.Name = "btnNormaliseLoudness";
            this.btnNormaliseLoudness.Size = new System.Drawing.Size(177, 121);
            this.btnNormaliseLoudness.TabIndex = 18;
            this.btnNormaliseLoudness.Text = "Normalise Loudness";
            this.btnNormaliseLoudness.UseVisualStyleBackColor = false;
            this.btnNormaliseLoudness.Click += new System.EventHandler(this.normaliseLoudnessToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmDownload
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(726, 280);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDownload";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AV Suite";
            this.Shown += new System.EventHandler(this.frmDownload_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        //private DK.Controls.CapturePasteBox cpbUrl;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleImagesFromVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animatedGifToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionFromVideoOrAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normaliseLoudnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnConvertToAudio;
        private System.Windows.Forms.Button btnConvertVideo;
        private System.Windows.Forms.Button btnExtractImage;
        private System.Windows.Forms.Button btnExtractMultipleImages;
        private System.Windows.Forms.Button btnExtractSection;
        private System.Windows.Forms.Button btnCreateGif;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnNormaliseLoudness;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}