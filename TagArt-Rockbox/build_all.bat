@ECHO OFF

echo x64 builds
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os win -a x64
dotnet build RB_TagArt/RB_Raiden.GUI.csproj -c Release --force --os win -a x64
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os linux -a x64
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os osx -a x64

echo x86 builds
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os win -a x86
dotnet build RB_TagArt/RB_Raiden.GUI.csproj -c Release --force --os win -a x86

echo arm64 builds
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os win -a arm64
dotnet build RB_TagArt/RB_Raiden.GUI.csproj -c Release --force --os win -a arm64
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os linux -a arm64
dotnet build RB_Raiden/RB_Raiden.csproj -c Release --force --os osx -a arm64

echo Done.
pause