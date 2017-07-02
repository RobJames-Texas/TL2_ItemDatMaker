using System.Collections.Generic;
using System.Linq;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMaker.Models
{
    public class Unit
    {
        public Unit(string resourceDirectory, string meshFile, UnitType unitType, string name, int level, Rarity rarity, long guid)
        {
            ResourceDirectory = resourceDirectory;
            MeshFile = meshFile;
            UnitType = unitType;
            Name = name;
            Level = level;
            Rarity = rarity;
            Guid = guid;
            BaseFile = string.Format(@"media\units\items\{0}{1}.DAT", UnitType.BaseFile.ToUpper(), Rarity.BaseSuffix.ToUpper());
        }

        private Unit(string resourceDirectory, string meshFile, UnitType unitType, string name, int level, Rarity rarity, long guid, string baseFile)
        {
            ResourceDirectory = resourceDirectory;
            MeshFile = meshFile;
            UnitType = unitType;
            Name = name;
            Level = level;
            Rarity = rarity;
            Guid = guid;
            BaseFile = baseFile;
        }

        public string ResourceDirectory { get; private set; }

        public string MeshFile { get; private set; }

        public string BaseFile { get; private set; }

        public Rarity Rarity { get; private set; }

        public UnitType UnitType { get; private set; }

        public string Name { get; private set; }

        public int Level { get; private set; }

        public long Guid { get; private set; }

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
            string ouput = $@"[UNIT]
    <STRING>RESOURCEDIRECTORY:{ResourceDirectory}
    <STRING>MESHFILE:{MeshFile}
    <STRING>BASEFILE:{BaseFile}
    <STRING>UNIT_GUID:{Guid.ToString()}
    <STRING>UNITTYPE:{Rarity.Level.ToUpper()} {UnitType.Type}
    <STRING>NAME:{Name}
    <INTEGER>LEVEL:{Level}
    <INTEGER>MINLEVEL:{MinLevel}
    <INTEGER>MAXLEVEL:{MaxLevel}
[/UNIT]";

            return ouput;
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
                    units.Add(new Unit(pathInfo.Resource, pathInfo.MeshFile, unitType, name + post, newLevel, rarity, TorchlightGuid.Generate(), units.First().BaseFile));
                }
            }

            if (ngClones)
            {
                List<Unit> originalUnits = units;
                foreach (Unit unit in originalUnits)
                {
                    //units.Add()
                }
            }

            return units;
        }
    }
}
