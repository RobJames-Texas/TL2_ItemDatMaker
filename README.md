# TL2_ItemDatMaker
Generate DAT files for items in torchlight 2

http://torchmodders.com/forums/tips-tools/(request)-item-unit-file-maker-script-624/?topicseen

Not complete yet.

Written in dot net core with Visual Studio 2017.

run with "dotnet .\TL2_ItemDatMaker.dll"
options:

-m | --3dmodel          Meshfile and full path. (required)
-r | --itemrarity               Item Rarity: Normal, Magic (Blue), Unique or Legendary. (required)
-t | --tag              Tag to be appended after item type. (required)
-l | --itemlevel                Base level of the item. Minimum of 3. (required)
-a | --altclones                Make Alt Clones.
-n | --ngclones         Make NG+ Clones.

Clones not implemented yet.

Consider this very early alpha.
