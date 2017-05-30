using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMaker.Models
{
    public class Unit
    {
        public Unit(string resourceDirectory, string meshFile, UnitType unitType, string name, int level, Rarity rarity)
        {
            ResourceDirectory = resourceDirectory;
            MeshFile = meshFile;
            UnitType = unitType;
            Name = name;
            Level = level;
            Rarity = rarity;
        }

        public string ResourceDirectory { get; private set; }

        public string MeshFile { get; private set; }

        public string BaseFile
        {
            get
            {
                return string.Format(@"media\units\items\{0}{1}.DAT", UnitType.BaseFile, Rarity.BaseSuffix);
            }
        }

        public Rarity Rarity { get; private set; }

        public UnitType UnitType { get; private set; }

        public string Name { get; private set; }

        public int Level { get; private set; }

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
<STRING>UNITTYPE:{UnitType.Type}
<STRING>NAME:{Name}
<INTEGER>LEVEL:{Level}
<INTEGER>MINLEVEL:{MinLevel}
<INTEGER>MAXLEVEL:{MaxLevel}
[/UNIT]";

            return ouput;
        }
    }
}
