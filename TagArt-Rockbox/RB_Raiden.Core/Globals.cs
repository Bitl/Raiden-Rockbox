#if GUI
using RB_TagArt;
#endif
#if CONSOLE
using System.Drawing;
#endif
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text.RegularExpressions;
using TagLib;

namespace RB_Raiden.Core
{
    public static class Globals
    {
        #region Variables
        public enum ImageFormatOptions
        {
            BMP,
            JPEG,
            None
        }

        public static int musicFiles = 0;
        public static bool useShortFormJPEGName = true;
        public static bool trackArt = false;
        public static bool storeInRockbox = false;
        public static bool isSimulator = false;
#if CONSOLE
        public static bool beep = true;
#endif
        public static int imageSize = 300;
        public static ImageFormat imgFormat = ImageFormat.Jpeg;
        public static string path = "";
        public static string[] excludedExts = new[] { ".png", ".jpg", ".bmp", ".jpeg", ".m3u",
                                                    ".ini", ".database_uuid", ".nomedia", ".ico",
                                                    ".db", ".blackplayer", ".bpstat", ".icns",
                                                    ".DS_Store", ".mp4", ".avi", ".wmv",
                                                    ".mkv", ".mov", ".exe", ".playlist_control"};
#if GUI
        public static MainForm? guiForm = null;
#endif
#endregion

        #region Functions
        public static string GetTitle()
        {
            return "Bitl's Raiden Extractor v" + Assembly.GetExecutingAssembly().GetName().Version + " for Rockbox";
        }

        public static void Reset()
        {
            musicFiles = 0;
        }

        //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        public static Bitmap ResizeImage(Image image, int width, int height)
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

        public static string GetImageFileExtensionForImageFormat()
        {
            if (imgFormat == ImageFormat.Bmp)
            {
                return ".bmp";
            }
            else if (imgFormat == ImageFormat.Jpeg)
            {
                return useShortFormJPEGName ? ".jpg" : ".jpeg";
            }

            return "";
        }

        public static Task<bool> ProcessCoverImage(Image coverImage, string path)
        {
            Image resizedImage = ResizeImage(coverImage, imageSize, imageSize);
            resizedImage.Save(path, imgFormat);

            if (System.IO.File.Exists(path))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public static string GenerateRockboxCompatibleName(string OGName)
        {
            string pattern = @"[\\/<>:?*|]";
            string replacement = "_";

            Regex regEx = new Regex(pattern);

            return regEx.Replace(OGName.Replace("\"", "'"), replacement);
        }

        public static string DetermineImagePath(string RBtitle, string sDir, string f)
        {
            string RBpath = "";
            if (storeInRockbox)
            {
                if (isSimulator)
                {
                    RBpath = Path.Combine(path, "simdisk/.rockbox/albumart/");
                }
                else
                {
                    RBpath = Directory.GetDirectoryRoot(sDir).Replace("\\", "/") + ".rockbox/albumart/";
                }

                if (!Directory.Exists(RBpath))
                {
                    Directory.CreateDirectory(RBpath);
                }
            }

            string imageName = trackArt ? GenerateRockboxCompatibleName(Path.GetFileNameWithoutExtension(f)) :
                (storeInRockbox ? GenerateRockboxCompatibleName(RBtitle) : "cover");
            string filepath = Path.Combine(storeInRockbox ? RBpath : Path.GetDirectoryName(f), imageName);
            string fullfilepath = filepath + GetImageFileExtensionForImageFormat();

            return fullfilepath;
        }

        //https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
        public static async void DirSearch(string sDir)
        {
#if CONSOLE
            Console.Out.WriteLine("Processing directory " + sDir);
#endif

            string title = "";
            Image curImage = null;

            foreach (string f in Directory.GetFiles(sDir))
            {
                if (excludedExts.Contains(Path.GetExtension(f)))
                {
                    continue;
                }

                try
                {
                    var tags = TagLib.File.Create(f).Tag;
                    string RBtitle = "";

                    try
                    {
                        if (trackArt)
                        {
                            title = tags.JoinedPerformers + " - " + tags.Title;
                        }
                        else 
                        {
                            title = tags.JoinedPerformers + " - " + tags.Album;
                            RBtitle = tags.JoinedPerformers + "-" + tags.Album;
                        }
                    }
                    catch (Exception)
                    {
                        if (!storeInRockbox)
                        {
                            title = Path.GetFileName(f);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    ++musicFiles;
                    
                    string filepath = DetermineImagePath(RBtitle, sDir, f);

                    Picture? Cover = new Picture(tags.Pictures[0].Data);

                    if (Cover != null)
                    {
                        using (MemoryStream ms = new MemoryStream(Cover.Data.Data))
                        {
                            curImage = Image.FromStream(ms, true, true);
                            bool exists = await ProcessCoverImage(curImage, filepath);

                            if (exists)
                            {
#if CONSOLE
                               Console.Out.WriteLine("Saved art as " + filepath);
#endif
                            }
                        }

                        if (!trackArt || storeInRockbox)
                        {
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

#if GUI
            string text = "#" + musicFiles.ToString("N0") + " - " + title;
            guiForm.BeginInvoke(new MethodInvoker(() =>
            {
                guiForm.CurrentTrackLabel.Text = trackArt ? "Track " + text : "Album " + text;
                guiForm.AlbumCover.Image = curImage;
                guiForm.Update();
            }));
#endif

            foreach (string d in Directory.GetDirectories(sDir))
            {
                DirSearch(d);
            }
        }
#endregion
    }
}
