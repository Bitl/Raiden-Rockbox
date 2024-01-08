namespace RB_TagArt
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MusicBrowsePathButton = new Button();
            MusicBrowsePath = new TextBox();
            MusicBrowsePathBox = new GroupBox();
            ExtractButton = new Button();
            CurrentTrackLabel = new Label();
            AlbumCover = new PictureBox();
            OptionsBox = new GroupBox();
            Simulator = new CheckBox();
            HeightLabel = new Label();
            StoreDirectlyInRockbox = new CheckBox();
            UseJPGInsteadOfJPEG = new CheckBox();
            TrackOrAlbumArt = new CheckBox();
            ImageFormatLabel = new Label();
            ImageFormatBox = new ComboBox();
            ImageSizeLabel = new Label();
            ImageSizeBox = new NumericUpDown();
            OpenOptionsButton = new Button();
            CurStatusLabel = new Label();
            Worker = new System.ComponentModel.BackgroundWorker();
            MusicBrowsePathBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumCover).BeginInit();
            OptionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImageSizeBox).BeginInit();
            SuspendLayout();
            // 
            // MusicBrowsePathButton
            // 
            MusicBrowsePathButton.Location = new Point(289, 22);
            MusicBrowsePathButton.Name = "MusicBrowsePathButton";
            MusicBrowsePathButton.Size = new Size(75, 23);
            MusicBrowsePathButton.TabIndex = 0;
            MusicBrowsePathButton.Text = "Browse...";
            MusicBrowsePathButton.UseVisualStyleBackColor = true;
            MusicBrowsePathButton.Click += MusicBrowsePathButton_Click;
            // 
            // MusicBrowsePath
            // 
            MusicBrowsePath.Location = new Point(6, 22);
            MusicBrowsePath.Name = "MusicBrowsePath";
            MusicBrowsePath.Size = new Size(277, 23);
            MusicBrowsePath.TabIndex = 1;
            // 
            // MusicBrowsePathBox
            // 
            MusicBrowsePathBox.Controls.Add(MusicBrowsePath);
            MusicBrowsePathBox.Controls.Add(MusicBrowsePathButton);
            MusicBrowsePathBox.Location = new Point(12, 12);
            MusicBrowsePathBox.Name = "MusicBrowsePathBox";
            MusicBrowsePathBox.Size = new Size(370, 59);
            MusicBrowsePathBox.TabIndex = 2;
            MusicBrowsePathBox.TabStop = false;
            MusicBrowsePathBox.Text = "Music Path";
            // 
            // ExtractButton
            // 
            ExtractButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            ExtractButton.ForeColor = Color.Red;
            ExtractButton.Location = new Point(12, 107);
            ExtractButton.Name = "ExtractButton";
            ExtractButton.Size = new Size(370, 47);
            ExtractButton.TabIndex = 3;
            ExtractButton.Text = "LET 'ER RIP!";
            ExtractButton.UseVisualStyleBackColor = true;
            ExtractButton.Click += ExtractButton_Click;
            // 
            // CurrentTrackLabel
            // 
            CurrentTrackLabel.BorderStyle = BorderStyle.Fixed3D;
            CurrentTrackLabel.Location = new Point(12, 174);
            CurrentTrackLabel.Name = "CurrentTrackLabel";
            CurrentTrackLabel.Size = new Size(370, 40);
            CurrentTrackLabel.TabIndex = 4;
            // 
            // AlbumCover
            // 
            AlbumCover.BorderStyle = BorderStyle.Fixed3D;
            AlbumCover.Location = new Point(388, 12);
            AlbumCover.Name = "AlbumCover";
            AlbumCover.Size = new Size(202, 202);
            AlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumCover.TabIndex = 5;
            AlbumCover.TabStop = false;
            // 
            // OptionsBox
            // 
            OptionsBox.Controls.Add(Simulator);
            OptionsBox.Controls.Add(HeightLabel);
            OptionsBox.Controls.Add(StoreDirectlyInRockbox);
            OptionsBox.Controls.Add(UseJPGInsteadOfJPEG);
            OptionsBox.Controls.Add(TrackOrAlbumArt);
            OptionsBox.Controls.Add(ImageFormatLabel);
            OptionsBox.Controls.Add(ImageFormatBox);
            OptionsBox.Controls.Add(ImageSizeLabel);
            OptionsBox.Controls.Add(ImageSizeBox);
            OptionsBox.Location = new Point(596, 4);
            OptionsBox.Name = "OptionsBox";
            OptionsBox.Size = new Size(192, 210);
            OptionsBox.TabIndex = 7;
            OptionsBox.TabStop = false;
            OptionsBox.Text = "Program Options";
            // 
            // Simulator
            // 
            Simulator.AutoSize = true;
            Simulator.Enabled = false;
            Simulator.Location = new Point(24, 136);
            Simulator.Name = "Simulator";
            Simulator.Size = new Size(126, 19);
            Simulator.TabIndex = 8;
            Simulator.Text = "Use Simulator Path";
            Simulator.UseVisualStyleBackColor = true;
            Simulator.CheckedChanged += Simulator_CheckedChanged;
            // 
            // HeightLabel
            // 
            HeightLabel.AutoSize = true;
            HeightLabel.Location = new Point(125, 19);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(22, 15);
            HeightLabel.TabIndex = 7;
            HeightLabel.Text = "x 1";
            // 
            // StoreDirectlyInRockbox
            // 
            StoreDirectlyInRockbox.AutoSize = true;
            StoreDirectlyInRockbox.Location = new Point(6, 117);
            StoreDirectlyInRockbox.Name = "StoreDirectlyInRockbox";
            StoreDirectlyInRockbox.Size = new Size(157, 19);
            StoreDirectlyInRockbox.TabIndex = 6;
            StoreDirectlyInRockbox.Text = "Store directly in Rockbox";
            StoreDirectlyInRockbox.UseVisualStyleBackColor = true;
            StoreDirectlyInRockbox.CheckedChanged += StoreDirectlyInRockbox_CheckedChanged;
            StoreDirectlyInRockbox.Click += StoreDirectlyInRockbox_Click;
            // 
            // UseJPGInsteadOfJPEG
            // 
            UseJPGInsteadOfJPEG.AutoSize = true;
            UseJPGInsteadOfJPEG.Enabled = false;
            UseJPGInsteadOfJPEG.Location = new Point(6, 79);
            UseJPGInsteadOfJPEG.Name = "UseJPGInsteadOfJPEG";
            UseJPGInsteadOfJPEG.Size = new Size(172, 19);
            UseJPGInsteadOfJPEG.TabIndex = 5;
            UseJPGInsteadOfJPEG.Text = "Use \".jpg\" instead of \".jpeg\"";
            UseJPGInsteadOfJPEG.UseVisualStyleBackColor = true;
            UseJPGInsteadOfJPEG.CheckedChanged += UseJPGInsteadOfJPEG_CheckedChanged;
            // 
            // TrackOrAlbumArt
            // 
            TrackOrAlbumArt.AutoSize = true;
            TrackOrAlbumArt.Location = new Point(6, 98);
            TrackOrAlbumArt.Name = "TrackOrAlbumArt";
            TrackOrAlbumArt.Size = new Size(157, 19);
            TrackOrAlbumArt.TabIndex = 4;
            TrackOrAlbumArt.Text = "Extract art for every track";
            TrackOrAlbumArt.UseVisualStyleBackColor = true;
            TrackOrAlbumArt.CheckedChanged += TrackOrAlbumArt_CheckedChanged;
            // 
            // ImageFormatLabel
            // 
            ImageFormatLabel.AutoSize = true;
            ImageFormatLabel.Location = new Point(6, 52);
            ImageFormatLabel.Name = "ImageFormatLabel";
            ImageFormatLabel.Size = new Size(81, 15);
            ImageFormatLabel.TabIndex = 3;
            ImageFormatLabel.Text = "Image Format";
            // 
            // ImageFormatBox
            // 
            ImageFormatBox.FormattingEnabled = true;
            ImageFormatBox.Items.AddRange(new object[] { "BMP", "JPEG" });
            ImageFormatBox.Location = new Point(93, 49);
            ImageFormatBox.Name = "ImageFormatBox";
            ImageFormatBox.Size = new Size(58, 23);
            ImageFormatBox.TabIndex = 2;
            ImageFormatBox.SelectedIndexChanged += ImageFormatBox_SelectedIndexChanged;
            // 
            // ImageSizeLabel
            // 
            ImageSizeLabel.AutoSize = true;
            ImageSizeLabel.Location = new Point(6, 19);
            ImageSizeLabel.Name = "ImageSizeLabel";
            ImageSizeLabel.Size = new Size(63, 15);
            ImageSizeLabel.TabIndex = 1;
            ImageSizeLabel.Text = "Image Size";
            // 
            // ImageSizeBox
            // 
            ImageSizeBox.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            ImageSizeBox.Location = new Point(75, 17);
            ImageSizeBox.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            ImageSizeBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ImageSizeBox.Name = "ImageSizeBox";
            ImageSizeBox.Size = new Size(46, 23);
            ImageSizeBox.TabIndex = 0;
            ImageSizeBox.TextAlign = HorizontalAlignment.Center;
            ImageSizeBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ImageSizeBox.ValueChanged += ImageSizeBox_ValueChanged;
            // 
            // OpenOptionsButton
            // 
            OpenOptionsButton.Location = new Point(12, 77);
            OpenOptionsButton.Name = "OpenOptionsButton";
            OpenOptionsButton.Size = new Size(370, 24);
            OpenOptionsButton.TabIndex = 8;
            OpenOptionsButton.Text = "Open Options Panel";
            OpenOptionsButton.UseVisualStyleBackColor = true;
            OpenOptionsButton.Click += OpenOptionsButton_Click;
            // 
            // CurStatusLabel
            // 
            CurStatusLabel.AutoSize = true;
            CurStatusLabel.Location = new Point(12, 157);
            CurStatusLabel.Name = "CurStatusLabel";
            CurStatusLabel.Size = new Size(42, 15);
            CurStatusLabel.TabIndex = 9;
            CurStatusLabel.Text = "Status:";
            // 
            // Worker
            // 
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 221);
            Controls.Add(CurStatusLabel);
            Controls.Add(OpenOptionsButton);
            Controls.Add(OptionsBox);
            Controls.Add(AlbumCover);
            Controls.Add(CurrentTrackLabel);
            Controls.Add(ExtractButton);
            Controls.Add(MusicBrowsePathBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "RB_Raiden.GUI";
            FormClosing += Form1_Closing;
            Load += Form1_Load;
            MusicBrowsePathBox.ResumeLayout(false);
            MusicBrowsePathBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumCover).EndInit();
            OptionsBox.ResumeLayout(false);
            OptionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ImageSizeBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MusicBrowsePathButton;
        private TextBox MusicBrowsePath;
        private GroupBox MusicBrowsePathBox;
        private Button ExtractButton;
        public Label CurrentTrackLabel;
        public PictureBox AlbumCover;
        private GroupBox OptionsBox;
        private NumericUpDown ImageSizeBox;
        private Label ImageSizeLabel;
        private Button OpenOptionsButton;
        private Label CurStatusLabel;
        private Label ImageFormatLabel;
        private ComboBox ImageFormatBox;
        private CheckBox TrackOrAlbumArt;
        private CheckBox UseJPGInsteadOfJPEG;
        private CheckBox StoreDirectlyInRockbox;
        private Label HeightLabel;
        private CheckBox Simulator;
        public System.ComponentModel.BackgroundWorker Worker;
    }
}