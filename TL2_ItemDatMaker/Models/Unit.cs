using System.Collections.Generic;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMaker.Models
{
    public class Unit
    {
        public Unit(string resourceDirectory, string meshFile, UnitType unitType, string name, int level, Rarity rarity, long guid, int? levelRequired = null)
        {
            ResourceDirectory = resourceDirectory;
            MeshFile = meshFile;
            UnitType = unitType;
            Name = name;
            Level = level;
            Rarity = rarity;
            Guid = guid;
            BaseFile = string.Format(@"media\units\items\{0}\{1}{2}.DAT", UnitType.UnitFolder.ToLower(), UnitType.BaseFile.ToUpper(), Rarity.BaseSuffix.ToUpper());
            LevelRequired = levelRequired;
        }

        private Unit(string resourceDirectory, string meshFile, UnitType unitType, string name, int level, Rarity rarity, long guid, string baseItemName, int? levelRequired = null)
        {
            ResourceDirectory = resourceDirectory;
            MeshFile = meshFile;
            UnitType = unitType;
            Name = name;
            Level = level;
            Rarity = rarity;
            Guid = guid;
            BaseFile = string.Format(@"media\units\items\{0}\{1}.DAT", UnitType.UnitFolder.ToLower(), baseItemName);
            LevelRequired = levelRequired;
        }

        public string ResourceDirectory { get; private set; }

        public string MeshFile { get; private set; }

        public string BaseFile { get; private set; }

        public Rarity Rarity { get; private set; }

        public UnitType UnitType { get; private set; }

        public string Name { get; private set; }

        public int Level { get; private set; }

        public long Guid { get; private set; }

        public int? LevelRequired { get; private set; }

        public int MinLevel
        {
            get
            {
                return Level - 2;
            }
        }

        public int MaxLevel
        {
            get
            {
                return Level + 3;
            }
        }

        public string ToDat()
        {
            string tab = Constants.Tab;
            string template = $@"[UNIT]
{tab}<STRING>RESOURCEDIRECTORY:{ResourceDirectory}
{tab}<STRING>MESHFILE:{MeshFile}
{tab}<STRING>BASEFILE:{BaseFile}
{tab}<STRING>UNIT_GUID:{Guid.ToString()}
{tab}<STRING>UNITTYPE:{Rarity.Level.ToUpper()} {UnitType.Type}
{tab}<STRING>NAME:{Name}
{tab}<INTEGER>LEVEL:{Level}
{tab}<INTEGER>MINLEVEL:{MinLevel}
{tab}<INTEGER>MAXLEVEL:{MaxLevel}
";
            string levelRequired = LevelRequired.HasValue ? "\t<INTEGER>LEVEL_REQUIRED:" + LevelRequired.Value + "\n" : string.Empty;

            return template + levelRequired + "[/UNIT]";
        }

        public static IEnumerable<Unit> GenerateVariations(PathInfo pathInfo, UnitType unitType, Rarity rarity, int itemLevel, string name, bool altClones, bool ngClones)
        {
            List<Unit> units = new List<Unit>();
            int altLevel = 4;
            string[] altPost = { "b", "c" };

            units.Add(new Unit(pathInfo.Resource, pathInfo.MeshFile, unitType, name, itemLevel, rarity, TorchlightGuid.Generate()));

            if (altClones)
            {
                int newLevel = itemLevel;
                foreach (string post in altPost)
                {
                    newLevel += altLevel;
                    units.Add(new Unit(pathInfo.Resource, pathInfo.MeshFile, unitType, name + post, newLevel, rarity, TorchlightGuid.Generate(), name));
                }
            }

            if (ngClones)
            {
                IEnumerable<Unit> originalUnits = units.ToArray();
                foreach (Unit unit in originalUnits)
                {
                    IEnumerable<NgLevel> ngLevels = NgLevel.Available(unit.Level);
                    foreach(NgLevel ngLevel in ngLevels)
                    {
                        units.Add(new Unit(pathInfo.Resource, pathInfo.MeshFile, unitType, unit.Name + ngLevel.Suffix, ngLevel.CalcNgLevel(unit.Level), rarity, TorchlightGuid.Generate(), name, ngLevel.LevelRequired));
                    }
                }
            }

            return units;
        }
    }
}
