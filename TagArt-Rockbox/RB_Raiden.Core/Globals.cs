#if GUI
using RB_TagArt;
#endif
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using TagLib;

namespace RB_Raiden.Core
{
    //https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }

    public static class Globals
    {
        #region Variables
        public enum ImageFormatOptions
        {
            BMP,
            JPEG
        }

        public static int musicFiles = 0;
        public static bool useShortFormJPEGName = true;
        public static bool trackArt = false;
#if CONSOLE
        public static bool beep = true;
#endif
        public static int imageSize = 500;
        public static ImageFormat imgFormat = ImageFormat.Bmp;
        public static string path = string.Empty;
        public static string[] excludedExts = new[] { ".png", ".jpg", ".bmp", ".jpeg", ".m3u",
                                                    ".ini", ".database_uuid", ".nomedia", ".ico",
                                                    ".db", ".blackplayer", ".bpstat", ".icns",
                                                    ".DS_Store"};
#if GUI
        public static MainForm? guiForm = null;
#endif
        #endregion

        #region Functions
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

        public static void SetImageFormatWithString(string input)
        {
            if (!string.IsNullOrEmpty(input)) 
            {
                if (input.Equals("bmp", StringComparison.InvariantCultureIgnoreCase))
                {
                    imgFormat = ImageFormat.Bmp;
                }
                else if (input.Equals("jpg", StringComparison.InvariantCultureIgnoreCase) || 
                    input.Equals("jpeg", StringComparison.InvariantCultureIgnoreCase))
                {
                    imgFormat = ImageFormat.Jpeg;
                }
            }
        }

        //https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
        public static void DirSearch(string sDir, string[] excludedFileExts)
        {
            try
            {
                Console.Out.WriteLine("Processing directory " + sDir);

                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (excludedFileExts.Contains(Path.GetExtension(f)))
                    {
                        continue;
                    }

#if CONSOLE
                    Console.Out.WriteLine("Processing file " + f);
#endif

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

                    ++musicFiles;
#if GUI
                    guiForm.UpdateCurrentTrack("#" + musicFiles.ToString("N0") + " - " + title);
#endif

                    Picture? Cover = new Picture(tags.Pictures[0].Data);

                    if (Cover != null)
                    {
                        MemoryStream ms = new MemoryStream(Cover.Data.Data);
                        Image coverImage = Image.FromStream(ms, true, true);
#if GUI
                        guiForm.AlbumCover.Image = coverImage;
#endif
                        Image resizedImage = ResizeImage(coverImage, imageSize, imageSize);
                        string imageName = trackArt ? Regex.Replace(Path.GetFileNameWithoutExtension(f).Replace("\"", "'"), @"[\\\/\<\>\:\?\*\|]", "_") : "cover";
                        string filepath = Path.Combine(Path.GetDirectoryName(f), imageName);
                        resizedImage.Save(filepath + GetImageFileExtensionForImageFormat(), imgFormat);
#if CONSOLE
                        Console.Out.WriteLine("Saved art as " + filepath + GetImageFileExtensionForImageFormat());
#endif
                        if (!trackArt)
                        {
                            break;
                        }
                    }
                    else
                    {
#if GUI
                        guiForm.AlbumCover.Image = null;
#endif
                        continue;
                    }
                }

                Console.Out.WriteLine("Done with " + sDir);

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
#endregion
    }
}
