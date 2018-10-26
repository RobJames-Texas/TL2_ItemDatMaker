dotnet build -r win7-x64
dotnet build -r win7-x86
dotnet build -r osx.10.10-x64

Start-Sleep -Seconds 1

dotnet publish -c release -r win10-x64
dotnet publish -c release -r win10-x86
dotnet publish -c release -r osx.10.10-x64

Start-Sleep -Seconds 1

$dotnetv = '2.1'
$7zip = 'E:\Program Files\7-Zip\7z.exe'

$strPath = Resolve-Path -Path ('.\bin\debug\netcoreapp' + $dotnetv + '\TL2_ItemDatMaker.dll')
$Assembly = [Reflection.Assembly]::Loadfile($strPath)

$AssemblyName = $Assembly.GetName()
$Assemblyversion = $AssemblyName.version

$NameAndVersion = ($AssemblyName.name + '_v' + $Assemblyversion)

$Current = Resolve-Path -Path '.\'
$Destination = ($Current.ToString() + '\Artifacts')
$ReleasePath = Resolve-Path -Path ('.\bin\release\netcoreapp' + $dotnetv)

New-Item -ItemType Directory -Force -Path $Destination

$win10x64 = 'win10-x64'
$win10x86 = 'win10-x86'
$osx = 'osx.10.10-x64'
$rc = '_requires_core'
$full = '_full'
$zip = '.zip'

# \bin\release\netcoreapp2.1\win10-x64
$win10x64Path = ($ReleasePath.ToString() + '\' + $win10x64)
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $win10x64 + $rc + $zip) ($win10x64Path + '\*') -xr!publish
# \bin\release\netcoreapp2.1\win10-x64\publish
$win10x64PathFull = ($win10x64Path + '\publish\*')
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $win10x64 + $full + $zip) $win10x64PathFull
# \bin\release\netcoreapp2.1\win10-x86
$win10x86Path = ($ReleasePath.ToString() + '\' + $win10x86)
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $win10x86 + $rc + $zip) ($win10x86Path + '\*') -xr!publish
# \bin\release\netcoreapp2.1\win10-x86\publish
$win10x86PathFull = ($win10x86Path + '\publish\*')
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $win10x86 + $full + $zip) $win10x86PathFull
# \bin\release\netcoreapp2.1\osx.10.10-x64
$osx10x64Path = ($ReleasePath.ToString() + '\' + $osx)
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $osx + $rc + $zip) ($osx10x64Path + '\*') -xr!publish
# \bin\release\netcoreapp2.1\osx.10.10-x64\publish
$osx10x64PathFull = ($osx10x64Path + '\publish\*')
&$7zip a -tzip ($Destination + '\' + $NameAndVersion + '_' + $osx + $full + $zip) $osx10x64PathFull
