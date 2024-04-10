using ManyConsole;
using RB_Raiden.Core;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace RB_Raiden
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

    internal class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine(Globals.GetTitle());
            var commands = GetCommands();
            return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }

    public class RaidenCommand : ConsoleCommand
    {
        public bool pause { get; set; } = true;

        public RaidenCommand()
        {
            IsCommand("start", "JACK IS BACK TO LET 'ER RIP!");
            HasRequiredOption("d|dir|directory=", "The directory to start ripping from.", p => Globals.path = p);
            HasOption("f|format=", "Sets the image format to export the album art with. Use BMP for BMP or JPG/JPEG for JPEG. Uses BMP by default.", p => SetImageFormatWithString(p));
            HasOption("j|usejpg=", "Specifies whether JPEG images should use the '.jpg' file extension. Enabled by default. Use True or False.", p => Globals.useShortFormJPEGName = bool.Parse(p.FirstCharToUpper()));
            HasOption("s|size=", "Specifies the size of the exported images in width and height. Set to 500 by default.", p => Globals.imageSize = int.Parse(p));
            HasOption("t|trackart=", "Specifies whether images should be extracted per track. Ignored when the  \"rbs/rockboxstore=\" option is enabled. Disabled by default. Use True or False.", p => TrackArtOption(p));
            HasOption("rbs|rockboxstore=", "Specifies whether images should be stored in the current Rockbox installation in /.rockbox/albumart. Disabled by default. Use True or False.", p => Globals.storeInRockbox = bool.Parse(p.FirstCharToUpper()));
            HasOption("sim|simulator=", "Specifies whether images should be stored in the current Rockbox Simulator's simdisk/.rockbox/albumart folder. Requires the \"rbs/rockboxstore=\" option to function. Disabled by default. Use True or False.", p => SimOption(p));
            HasOption("a|usealbumartist=", "Specifies whether the extracted cover names should use the first album artist instead of the first contributing artist. Disabled by default. Use True or False.", p => FirstAlbumArtistOption(p));
            HasOption("b|beep=", "Specifies whether the console should beep upon completion. Enabled by default. Use True or False.", p => Globals.beep = bool.Parse(p.FirstCharToUpper()));
            HasOption("p|pause=", "Specifies whether the console should pause at important points. Enabled by default. Use True or False.", p => pause = bool.Parse(p.FirstCharToUpper()));
        }

        public override int Run(string[] remainingArguments)
        {
            if (string.IsNullOrWhiteSpace(Globals.path))
            {
                Console.Out.WriteLine("Please specify a music folder.");
                Console.ReadLine();
                return 0;
            }

            int imgsize = Globals.imageSize;
            Console.Out.WriteLine("Settings:");
            Console.Out.WriteLine(" Directory: " + Globals.path);
            Console.Out.WriteLine(" Image Format: " + Globals.imgFormat.ToString());
            Console.Out.WriteLine(" Use \".jpg\" instead of \".jpeg\": " + Globals.useShortFormJPEGName.ToString());
            Console.Out.WriteLine(" Image Size: " + imgsize + " x " + imgsize);
            Console.Out.WriteLine(" Extract art for every track: " + Globals.trackArt.ToString());
            Console.Out.WriteLine(" Store directly in Rockbox: " + Globals.storeInRockbox.ToString());
            Console.Out.WriteLine("     Use Simulator Path: " + Globals.isSimulator.ToString());
            Console.Out.WriteLine(" Use first album artist instead");
            Console.Out.WriteLine(" of first contributing artist: " + Globals.useFirstAlbumArtist.ToString());

            if (pause)
            {
                Console.Out.WriteLine("\nPlease review your settings before continuing.");
                Pause();
            }

            Console.Clear();

            if (pause && Globals.storeInRockbox)
            {
                Console.Out.WriteLine("\nNOTE: Make sure your library is in the same drive as your Rockbox installation. If you're using a Rockbox Simulator, make sure your Music folder is placed in the simdisk folder, and make sure the file path you have selected includes a simdisk folder. Please check everything before continuing.");
                Pause();
            }

            Console.Out.WriteLine("\nLET 'ER RIP!\n");

            Globals.DirSearch(Globals.path);

            Console.Clear();
            Globals.Reset();
            Console.Out.WriteLine("\nFinished reading the " + Globals.path + " directory! You may now refresh your Rockbox library on your device to view your art!");

            if (Globals.beep)
            {
                Console.Beep();
            }

            if (pause)
            {
                Pause();
            }

            return 0;
        }

        private void SimOption(string p)
        {
            if (Globals.storeInRockbox)
            {
                Globals.isSimulator = bool.Parse(p.FirstCharToUpper());
            }
        }

        private void TrackArtOption(string p)
        {
            if (!Globals.storeInRockbox)
            {
                Globals.trackArt = bool.Parse(p.FirstCharToUpper());
            }
        }

        private void FirstAlbumArtistOption(string p)
        {
            if (!Globals.storeInRockbox)
            {
                Globals.useFirstAlbumArtist = bool.Parse(p.FirstCharToUpper());
            }
        }

        public static void Pause()
        {
            Console.Out.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void SetImageFormatWithString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Equals("bmp", StringComparison.InvariantCultureIgnoreCase))
                {
                    Globals.imgFormat = ImageFormat.Bmp;
                }
                else if (input.Equals("jpg", StringComparison.InvariantCultureIgnoreCase) ||
                    input.Equals("jpeg", StringComparison.InvariantCultureIgnoreCase))
                {
                    Globals.imgFormat = ImageFormat.Jpeg;
                }
            }
        }


    }
}