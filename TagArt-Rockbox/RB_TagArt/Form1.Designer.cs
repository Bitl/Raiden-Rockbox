namespace RB_TagArt
{
    partial class Form1
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
            MusicBrowsePathButton = new Button();
            MusicBrowsePath = new TextBox();
            MusicBrowsePathBox = new GroupBox();
            ExtractButton = new Button();
            CurrentTrack = new Label();
            AlbumCover = new PictureBox();
            ImageSizeBox = new GroupBox();
            ImageSize = new NumericUpDown();
            MusicBrowsePathBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumCover).BeginInit();
            ImageSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImageSize).BeginInit();
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
            ExtractButton.Location = new Point(12, 75);
            ExtractButton.Name = "ExtractButton";
            ExtractButton.Size = new Size(370, 47);
            ExtractButton.TabIndex = 3;
            ExtractButton.Text = "LET 'ER RIP!";
            ExtractButton.UseVisualStyleBackColor = true;
            ExtractButton.Click += ExtractButton_Click;
            // 
            // CurrentTrack
            // 
            CurrentTrack.BorderStyle = BorderStyle.Fixed3D;
            CurrentTrack.Location = new Point(12, 127);
            CurrentTrack.Name = "CurrentTrack";
            CurrentTrack.Size = new Size(370, 32);
            CurrentTrack.TabIndex = 4;
            // 
            // AlbumCover
            // 
            AlbumCover.BorderStyle = BorderStyle.Fixed3D;
            AlbumCover.Location = new Point(428, 12);
            AlbumCover.Name = "AlbumCover";
            AlbumCover.Size = new Size(90, 90);
            AlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumCover.TabIndex = 5;
            AlbumCover.TabStop = false;
            // 
            // ImageSizeBox
            // 
            ImageSizeBox.Controls.Add(ImageSize);
            ImageSizeBox.Location = new Point(402, 111);
            ImageSizeBox.Name = "ImageSizeBox";
            ImageSizeBox.Size = new Size(143, 48);
            ImageSizeBox.TabIndex = 7;
            ImageSizeBox.TabStop = false;
            ImageSizeBox.Text = "Size (in width/height)";
            // 
            // ImageSize
            // 
            ImageSize.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            ImageSize.Location = new Point(6, 19);
            ImageSize.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ImageSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ImageSize.Name = "ImageSize";
            ImageSize.Size = new Size(131, 23);
            ImageSize.TabIndex = 0;
            ImageSize.TextAlign = HorizontalAlignment.Center;
            ImageSize.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 168);
            Controls.Add(ImageSizeBox);
            Controls.Add(AlbumCover);
            Controls.Add(CurrentTrack);
            Controls.Add(ExtractButton);
            Controls.Add(MusicBrowsePathBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitl's TagArt for Rockbox";
            Load += Form1_Load;
            MusicBrowsePathBox.ResumeLayout(false);
            MusicBrowsePathBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumCover).EndInit();
            ImageSizeBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImageSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button MusicBrowsePathButton;
        private TextBox MusicBrowsePath;
        private GroupBox MusicBrowsePathBox;
        private Button ExtractButton;
        private Label CurrentTrack;
        private PictureBox AlbumCover;
        private GroupBox ImageSizeBox;
        private NumericUpDown ImageSize;
    }
}