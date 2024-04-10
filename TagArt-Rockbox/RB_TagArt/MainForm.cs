#region Usings
using RB_Raiden.Core;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
#endregion

namespace RB_TagArt
{
    #region MainForm
    public partial class MainForm : Form
    {
        #region

        #endregion

        #region Form Events
        public MainForm()
        {
            Globals.guiForm = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Text = Globals.GetTitle();
            Width = 611;
            ImageFormatBox.SelectedIndex = (int)GetImageFormatThroughOptions(Globals.imgFormat);
            ImageSizeBox.Value = Globals.imageSize;
            UseJPGInsteadOfJPEG.Checked = Globals.useShortFormJPEGName;
            TrackOrAlbumArt.Checked = Globals.trackArt;
            StoreDirectlyInRockbox.Checked = Globals.storeInRockbox;
            Simulator.Checked = Globals.isSimulator;
            FirstAlbumArtist.Checked = Globals.useFirstAlbumArtist;
            CenterToScreen();
            FormReset();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Worker.CancelAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                Globals.DirSearch(Globals.path);
                e.Result = true;
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                CurrentTrackLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                CurrentTrackLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                MessageBox.Show("Finished reading the " + Globals.path + " directory! You may now refresh your Rockbox library on your device to view your art!",
                            Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormReset();
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Globals.path))
            {
                MessageBox.Show("Please specify a music folder. If you have \"Use Simulator Path\" enabled, specify the directory where your Rockbox simulator is stored.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Worker.RunWorkerAsync();
        }

        //https://www.c-sharpcorner.com/UploadFile/mahesh/folderbrowserdialog-in-C-Sharp/
        private void MusicBrowsePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                MusicBrowsePath.Text = folderDlg.SelectedPath;
                Globals.path = MusicBrowsePath.Text;
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
            UseJPGInsteadOfJPEG.Enabled = SetImageFormatThroughOptions(ImageFormatBox.SelectedIndex);
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
            HeightLabel.Text = "x " + Globals.imageSize.ToString();
        }

        private void StoreDirectlyInRockbox_Click(object sender, EventArgs e)
        {
            if (StoreDirectlyInRockbox.Checked)
            {
                DialogResult result = MessageBox.Show("NOTE: Make sure your library is in the same drive as your Rockbox installation. If you're using a Rockbox Simulator, make sure your Music folder is placed in the simdisk folder, and make sure the file path you have selected includes a simdisk folder. Please check everything before continuing.\n\nContinue?",
                                        Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Globals.storeInRockbox = StoreDirectlyInRockbox.Checked;
                }
                else
                {
                    StoreDirectlyInRockbox.Checked = false;
                }
            }
        }

        private void Simulator_CheckedChanged(object sender, EventArgs e)
        {
            Globals.isSimulator = Simulator.Checked;
        }

        private void StoreDirectlyInRockbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.storeInRockbox == true)
            {
                Globals.storeInRockbox = false;
            }

            Simulator.Checked = false;
            TrackOrAlbumArt.Checked = false;
            TrackOrAlbumArt.Enabled = !StoreDirectlyInRockbox.Checked;
            Simulator.Enabled = StoreDirectlyInRockbox.Checked;
        }
        #endregion

        #region Functions
        public void FormReset()
        {
            CurrentTrackLabel.Text = "Ready";
            AlbumCover.Image = null;
            Globals.Reset();
        }

        public static bool SetImageFormatThroughOptions(int option)
        {
            bool isJpeg = false;

            if (option == (int)Globals.ImageFormatOptions.BMP)
            {
                Globals.imgFormat = ImageFormat.Bmp;
                isJpeg = false;
            }
            else if (option == (int)Globals.ImageFormatOptions.JPEG)
            {
                Globals.imgFormat = ImageFormat.Jpeg;
                isJpeg = true;
            }

            return isJpeg;
        }

        public static Globals.ImageFormatOptions GetImageFormatThroughOptions(ImageFormat format)
        {
            Globals.ImageFormatOptions selectedOption = Globals.ImageFormatOptions.None;

            if (format == ImageFormat.Bmp)
            {
                selectedOption = Globals.ImageFormatOptions.BMP;
            }
            else if (format == ImageFormat.Jpeg)
            {
                selectedOption = Globals.ImageFormatOptions.JPEG;
            }

            return selectedOption;
        }

        private void MusicBrowsePath_TextChanged(object sender, EventArgs e)
        {
            Globals.path = MusicBrowsePath.Text;
        }

        private void FirstAlbumArtist_CheckedChanged(object sender, EventArgs e)
        {
            Globals.useFirstAlbumArtist = FirstAlbumArtist.Checked;
        }
        #endregion
    }
    #endregion
}