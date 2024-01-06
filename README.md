# Raiden Extractor
### IT'S TIME FOR JACK TO LET 'ER RIP!
Raiden Extractor is a program used to RIP images from item tags for use in [Rockbox](https://www.rockbox.org/), the free and open source firmware for MP3 players.
Other programs exist that do the same things, but are either bugged in some way, are non-functional, or are completely unaccessable. This software solves that issue while also streamlining the experience.

## Features:
- Exports in .bmp and .jpeg (with the option to use shorter .jpg file names if necessary.)
- Allows you to set the size of the images (500 x 500 by default)
- Abides by Rockbox's naming and formatting schemes for album art (listed [here](https://download.rockbox.org/daily/manual/rockbox-ipodvideo/rockbox-buildap3.html))
- Has the ability to recursively operate through large music libraries or individual albums depending on what directory the user chooses.
- Includes a GUI or CMD/Terminal based version, adding user flexability.
- Has the option to extract the art for the album only, or extract the art for every track. This helps with albums which have alternate track art.
- Built in .NET 6.0, which means it can be built on Windows, MacOS, and Linux. (GUI only supports Windows due to the use of Windows Forms)

## Dependencies:
On all platforms, install the [.NET 6.0 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
On Linux, you must install the libgdiplus package for your respective distro.

## Compile instructions
Download the .NET SDK for your respective operating system and run the following command in your terminal in the project's derectory:
```dotnet build RB_Raiden.sln -c Release --force```

You can also install Visual Studio 2022 or above and compile it from there.