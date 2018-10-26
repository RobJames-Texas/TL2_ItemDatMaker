# TL2_ItemDatMaker

Generate DAT files for items in torchlight 2

http://torchmodders.com/forums/tips-tools/(request)-item-unit-file-maker-script-624/?topicseen

## BETA!!

v0.9.2

Releases: https://github.com/RobJames-Texas/TL2_ItemDatMaker/releases

Written in dot net core with Visual Studio 2017.

### Usage:

#### Stand Alone versions:

* Windows 7 and up 32/64bit **"TL2_ItemDatMaker.exe"**
* OSX 10.10 x64 and up **"TL2_ItemDatMaker"**

Either with the options below, *or* drag the mesh file in your mod folder over the executable and the application will ask for the rest of the options.

#### options:

-m | --3dmodel          Meshfile and full path. (required)  
-r | --itemrarity       Item Rarity: Normal, Magic (Blue), Unique or Legendary. (required)  
-t | --tag              Tag to be appended after item type. (required)  
-l | --itemlevel        Base level of the item. Minimum of 3. (required)  
-a | --altclones        Make Alt Clones.  
-n | --ngclones         Make NG+ Clones.

Release notes:

* v0.9.2 -- Changed spaces to tabs in output DAT files. Updated nuget packages and unit tests. Updated to dot net core 2.1.
* v0.9.1 -- Corrected output file encoding. Removed extension from the string for the meshfile.
* v0.9.0 -- Initial release.