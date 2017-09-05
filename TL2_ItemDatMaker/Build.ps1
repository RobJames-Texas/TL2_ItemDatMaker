dotnet build -r win7-x64
dotnet build -r win7-x86
dotnet build -r osx.10.10-x64

dotnet publish -c release -r win10-x64
dotnet publish -c release -r win10-x86
dotnet publish -c release -r osx.10.10-x64
