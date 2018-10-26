using System.Collections.Generic;
using System.Linq;

namespace TL2_ItemDatMaker.Components
{
    public class UnitType
    {
        public string Type { get; private set; }

        public string MeshFolder { get; private set; }

        public string BaseFile { get; private set; }

        public string UnitFolder { get; private set; }

        public string NamePrefix { get; private set; }

        private UnitType(string type, string meshFolder, string unitFolder, string baseFile, string namePrefix)
        {
            Type = type;
            MeshFolder = meshFolder;
            UnitFolder = unitFolder;
            BaseFile = baseFile;
            NamePrefix = namePrefix;
        }

        public static UnitType Axes { get; } = new UnitType("1HAXE", "_AXES", "AXES", "BASE_AXE", "axe");

        public static UnitType Bows { get; } = new UnitType("BOW", "_BOWS", "BOWS", "BASE_BOW", "bow");

        public static UnitType Cannons { get; } = new UnitType("CANNON", "_CANNONS", "CANNONS", "BASE_CANNON", "cannon");

        public static UnitType Crossbows { get; } = new UnitType("CROSSBOW", "_CROSSBOWS", "CROSSBOWS", "BASE_CROSSBOW", "crossbow");

        public static UnitType Fists { get; } = new UnitType("FIST", "_FISTS", "FISTS", "BASE_FIST", "fist");

        public static UnitType GreatAxes { get; } = new UnitType("2HAXE", "_GREATAXES", "2HAXE", "BASE_2HAXE", "greataxe");

        public static UnitType GreatHammers { get; } = new UnitType("2HMACE", "_GREATHAMMERS", "2HMACE", "BASE_2HMACE", "greathammer");

        public static UnitType GreatSwords { get; } = new UnitType("2HSWORD", "_GREATSWORDS", "2HSWORD", "BASE_2HSWORD", "greatsword");

        public static UnitType Hammers { get; } = new UnitType("1HMACE", "_HAMMERS", "MACES", "BASE_MACE", "hammer");

        public static UnitType Pistols { get; } = new UnitType("PISTOL", "_PISTOLS", "PISTOLS", "BASE_PISTOL", "pistol");

        public static UnitType Polearms { get; } = new UnitType("POLEARM", "_POLEARMS", "POLEARMS", "BASE_POLEARM", "polearm");

        public static UnitType Rifles { get; } = new UnitType("RIFLE", "_RIFLES", "RIFLES", "BASE_RIFLE", "rifle");

        public static UnitType Shields { get; } = new UnitType("SHIELD", "_SHIELDS", "SHIELDS", "BASE_SHIELD", "shield");

        public static UnitType Staves { get; } = new UnitType("STAFF", "_STAVES", "STAVES", "BASE_STAFF", "staff");

        public static UnitType Swords { get; } = new UnitType("1HSWORD", "_SWORDS", "SWORDS", "BASE_SWORD", "sword");

        public static UnitType Wands { get; } = new UnitType("WAND", "_WANDS", "WANDS", "BASE_WAND", "wand");

        public static UnitType GetByMeshFolder(string meshFolder)
        {
            return UnitType.List().Where(u => u.MeshFolder == meshFolder.ToUpper()).FirstOrDefault();
        }

        public static IEnumerable<UnitType> List()
        {
            return new UnitType[]
            {
                Axes,
                Bows,
                Cannons,
                Crossbows,
                Fists,
                GreatAxes,
                GreatHammers,
                GreatSwords,
                Hammers,
                Pistols,
                Polearms,
                Rifles,
                Shields,
                Staves,
                Swords,
                Wands
            };
        }
    }
}
