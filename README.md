# Raiden Extractor

## **IT'S TIME FOR JACK TO LET 'ER RIP!**
Raiden Extractor is a program used to RIP images from item tags for use in [Rockbox](https://www.rockbox.org/), the free and open source firmware for MP3 players.
Other programs exist that do the same things, but are either bugged in some way, are non-functional, or are completely unaccessable. This software solves that issue while also streamlining the experience.

## Features:
- Exports in .bmp and .jpeg (with the option to use shorter .jpg file names if necessary.)
- Allows you to set the size of the images (300 x 300 by default)
- Abides by Rockbox's naming and formatting schemes for album art (listed [here](https://download.rockbox.org/daily/manual/rockbox-ipodvideo/rockbox-buildap3.html))
- Has the ability to recursively operate through large music libraries or individual albums depending on what directory the user chooses.
- Includes a GUI or CMD/Terminal based version, adding user flexability.
- Has the option to extract the art for the album only, or extract the art for every track. This helps with albums which have alternate track art.
- As of releases v1.1.0 (v1.0.1 and v1.0.2 had it but the implementation was buggy), you can save art in your Rockbox "/.rockbox/albumart/" install directory.
> [!NOTE]
> As of release v1.1.0, you can use the above option with the [Rockbox Simulators](http://rasher.dk/rockbox/simulator/).
- Built in .NET 6.0, which means it can be built on Windows, MacOS, and Linux. (GUI only supports Windows due to the use of Windows Forms)

## Dependencies:
On all platforms, install the [.NET 6.0 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
On MacOS, use the [mono-libgdiplus](https://formulae.brew.sh/formula/mono-libgdiplus) Homebrew package on Apple Silicon. 
> [!NOTE]
> You do not need to do this on x64/Intel Macs as the files needed to launch this are included with the x64/Intel version of the application.
On Linux, you must install the libgdiplus package for your respective distro.

## Compile instructions:
Download the .NET SDK for your respective operating system and run the following command in your terminal in the project's directory:

For Windows, use:
```
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os win
```
and
```
dotnet build RB_TagArt/RB_Raiden.GUI.csproj -c Release --force --os win
```

Add ```-a x86``` for 32 bit, or ```-a arm64``` for ARM64.

For Linux, use:
```dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os linux```

Add ```-a arm64``` for ARM64.

For MacOS, use:
```dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os osx```

Add ```-a arm64``` for ARM64/Apple Silicon.

> [!NOTE]
> More information regarding build targets [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog). You can also install Visual Studio 2022 or above and compile it from there.