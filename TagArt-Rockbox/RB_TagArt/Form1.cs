using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using TagLib;

namespace RB_TagArt
{
    public partial class Form1 : Form
    {
        int musicfiles = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void UpdateCurrentTrack(string text)
        {
            CurrentTrack.Text = "Track " + text;
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MusicBrowsePath.Text))
            {
                MessageBox.Show("Please specify a music folder.");
                return;
            }

            string[] ExcludeeExts = new[] { ".png", ".jpg", ".bmp", ".jpeg", ".m3u",
                                    ".ini", ".database_uuid", ".nomedia", ".ico",
                                    ".db", ".blackplayer", ".bpstat", ".icns",
                                    ".DS_Store"};

            DirSearch(MusicBrowsePath.Text, ExcludeeExts);
            Reset();

            MessageBox.Show("Finished reading the " + MusicBrowsePath.Text + " directory! You may now update your Rockbox library on your device to view your album art!");
        }

        void Reset()
        {
            musicfiles = 0;
            UpdateCurrentTrack("- None");
            AlbumCover.Image = null;
        }

        //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
        private void DirSearch(string sDir, string[] excludedFileExts)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (excludedFileExts.Contains(Path.GetExtension(f)))
                    {
                        continue;
                    }

                    var tags = TagLib.File.Create(f).Tag;
                    string title = "";

                    try
                    {
                        title = tags.JoinedPerformers + " - " + tags.Title;
                    }
                    catch (Exception)
                    {
                        title = Path.GetFileName(f);
                    }

                    ++musicfiles;
                    UpdateCurrentTrack("#" + musicfiles.ToString("N0") + " - " + title);

                    Picture? Cover = new Picture(tags.Pictures[0].Data);

                    if (Cover != null)
                    {
                        MemoryStream ms = new MemoryStream(Cover.Data.Data);
                        Image coverImage = Image.FromStream(ms, true, true);
                        AlbumCover.Image = coverImage;
                        Image resizedImage = ResizeImage(coverImage, int.Parse(ImageSize.Text), int.Parse(ImageSize.Text));
                        string filepath = Path.Combine(Path.GetDirectoryName(f), Regex.Replace(Path.GetFileNameWithoutExtension(f).Replace("\"", "'"), @"[\\\/\<\>\:\?\*\|]", "_"));
                        resizedImage.Save(filepath + ".bmp", ImageFormat.Bmp);
                    }
                    else
                    {
                        AlbumCover.Image = null;
                        continue;
                    }
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d, excludedFileExts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //https://www.c-sharpcorner.com/UploadFile/mahesh/folderbrowserdialog-in-C-Sharp/
        private void MusicBrowsePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                MusicBrowsePath.Text = folderDlg.SelectedPath;
            }
        }
    }
}