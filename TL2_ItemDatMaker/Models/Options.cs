using coreArgs.Attributes;

namespace TL2_ItemDatMaker.Models
{
    public class Options
    {
        [Option('m', "3dmodel", "Meshfile and full path.", true)]
        public string MeshFile { get; set; }

        [Option('r', "itemrarity", "Item Rarity: Normal, Magic (Blue), Unique or Legendary.", true)]
        public string ItemRarity { get; set; }

        [Option('t', "tag", "Tag to be appended after item type.", true)]
        public string NameTag { get; set; }

        [Option('l', "itemlevel", "Base level of the item. Minimum of 2.", true)]
        public int ItemLevel { get; set; }

        [Option('a', "altclones", "Make Alt Clones.", false)]
        public bool AltClones { get; set; }

        [Option('n', "ngclones", "Make NG+ Clones.", false)]
        public bool NgClones { get; set; }
    }
}
