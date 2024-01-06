# Raiden
### IT'S TIME FOR JACK TO LET 'ER RIP!
Raiden is a program used to RIP images from item tags for use in [Rockbox](https://www.rockbox.org/), the free and open source firmware for mp3 players.

Features:
- Exports in .bmp and .jpg (with the option to use longer .jpeg file names if necessary.)
- Abides by Rockbox's naming and formatting schemes for album art (listed [here](https://download.rockbox.org/daily/manual/rockbox-ipodvideo/rockbox-buildap3.html))
- Built in .NET 6.0, which means it can be built on Windows, MacOS, and Linux (currently only supports Windows at the moment due to the use of Windows Forms).

## Compile instructions
Download the .NET SDK for your respective operating system and run the following command in your terminal in the project's deirectory:
```dotnet build RB_Raiden.csproj -c Release -f net6.0-windows --force```
