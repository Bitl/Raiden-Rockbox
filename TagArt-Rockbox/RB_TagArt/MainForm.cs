#region Usings
using RB_Raiden.Core;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text.RegularExpressions;
using TagLib;
#endregion

namespace RB_TagArt
{
    #region MainForm
    public partial class MainForm : Form
    {


        #region Form Events
        public MainForm()
        {
            Globals.guiForm = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Globals.GetTitle();
            Width = 611;
            ImageFormatBox.SelectedIndex = (int)Globals.ImageFormatOptions.BMP;
            CenterToScreen();
            FormReset();
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Globals.path))
            {
                MessageBox.Show("Please specify a music folder.");
                return;
            }

            Globals.DirSearch(Globals.path, Globals.excludedExts);
            MessageBox.Show("Finished reading the " + Globals.path + " directory! You may now update your Rockbox library on your device to view your art!");
            FormReset();
        }

        //https://www.c-sharpcorner.com/UploadFile/mahesh/folderbrowserdialog-in-C-Sharp/
        private void MusicBrowsePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                MusicBrowsePath.Text = folderDlg.SelectedPath;
                Globals.path = folderDlg.SelectedPath;
            }
        }

        private void OpenOptionsButton_Click(object sender, EventArgs e)
        {
            if (Width == 611)
            {
                Width = 813;
            }
            else if (Width == 813)
            {
                Width = 611;
            }
        }

        private void ImageFormatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImageFormatBox.SelectedIndex == (int)Globals.ImageFormatOptions.BMP)
            {
                Globals.imgFormat = ImageFormat.Bmp;
                UseJPGInsteadOfJPEG.Enabled = false;
            }
            else if (ImageFormatBox.SelectedIndex == (int)Globals.ImageFormatOptions.JPEG)
            {
                Globals.imgFormat = ImageFormat.Jpeg;
                UseJPGInsteadOfJPEG.Enabled = true;
            }
        }

        private void UseJPGInsteadOfJPEG_CheckedChanged(object sender, EventArgs e)
        {
            Globals.useShortFormJPEGName = UseJPGInsteadOfJPEG.Checked;
        }

        private void TrackOrAlbumArt_CheckedChanged(object sender, EventArgs e)
        {
            Globals.trackArt = TrackOrAlbumArt.Checked;
        }

        private void ImageSizeBox_ValueChanged(object sender, EventArgs e)
        {
            Globals.imageSize = (int)ImageSizeBox.Value;
        }
        #endregion

        #region Functions
        public void UpdateCurrentTrack(string text)
        {
            CurrentTrackLabel.Text = "Track " + text;
        }

        public void FormReset()
        {
            UpdateCurrentTrack("- None");
            AlbumCover.Image = null;
            Globals.Reset();
        }
        #endregion
    }
    #endregion
}