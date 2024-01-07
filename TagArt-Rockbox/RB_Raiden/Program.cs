using ManyConsole;
using RB_Raiden.Core;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace RB_Raiden
{
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
            HasOption("f|format=", "Sets the image format to export the album art with. Use BMP for BMP or JPG/JPEG for JPEG. Uses BMP by default.", p => Globals.SetImageFormatWithString(p));
            HasOption("j|usejpg=", "Specifies whether JPEG images should use the '.jpg' file extension. Enabled by default. Use True or False.", p => Globals.useShortFormJPEGName = bool.Parse(p.FirstCharToUpper()));
            HasOption("s|size=", "Specifies the size of the exported images in width and height. Set to 500 by default.", p => Globals.imageSize = int.Parse(p));
            HasOption("t|trackart=", "Specifies whether images should be extracted per track. Disabled by default. Use True or False.", p => Globals.trackArt = bool.Parse(p.FirstCharToUpper()));
            HasOption("rbs|rockboxstore=", "Specifies whether images should be stored in the current Rockbox installation. Disabled by default. Use True or False.", p => Globals.storeInRockbox = bool.Parse(p.FirstCharToUpper()));
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

            Console.Out.WriteLine("Settings:");
            Console.Out.WriteLine(" Directory: " + Globals.path);
            Console.Out.WriteLine(" Image Format: " + Globals.imgFormat.ToString());
            Console.Out.WriteLine(" Use \".jpg\" instead of \".jpeg\": " + Globals.useShortFormJPEGName.ToString());
            Console.Out.WriteLine(" Image Size: " + Globals.imageSize.ToString() + "x" + Globals.imageSize.ToString());
            Console.Out.WriteLine(" Extract art for every track: " + Globals.trackArt.ToString());
            Console.Out.WriteLine(" Store directly in Rockbox: " + Globals.storeInRockbox.ToString());

            if (pause)
            {
                Console.Out.WriteLine("\nPlease review your settings before continuing." + Globals.storeInRockbox.ToString());
                Globals.Pause();
            }

            Console.Clear();

            if (pause && Globals.storeInRockbox)
            {
                Console.Out.WriteLine("\nNOTE: Make sure your library is in the same drive as your Rockbox installation." + Globals.storeInRockbox.ToString());
                Globals.Pause();
            }

            Console.Out.WriteLine("\nLET 'ER RIP!\n");

            Globals.DirSearch(Globals.path, Globals.excludedExts);

            Console.Clear();
            Console.Out.WriteLine("\nFinished reading the " + Globals.path + " directory! You may now refresh your Rockbox library on your device to view your art!");

            if (Globals.beep)
            {
                Console.Beep();
            }

            if (pause)
            {
                Globals.Pause();
            }

            return 0;
        }
    }
}