using System;
using System.Collections.Generic;
using System.Linq;

namespace TL2_ItemDatMaker.Components
{
    public class Rarity
    {
        public string Level { get; private set; }

        public string NameLetter { get; private set; }

        public string BaseSuffix { get; private set; }

        private Rarity(string level, string nameLetter, string baseSuffix)
        {
            Level = level;
            NameLetter = nameLetter;
            BaseSuffix = baseSuffix;
        }

        public static Rarity Normal = new Rarity("Normal", "n", "");

        public static Rarity Magic = new Rarity("Magic", "m", "_magic");

        public static Rarity Unique = new Rarity("Unique", "u", "_unique");

        public static Rarity Legendary = new Rarity("Legendary", "l", "_unique");

        public static Rarity GetByLevel(string level)
        {
            return Rarity.List().Where(r => r.Level.ToLower() == level.ToLower()).FirstOrDefault();
        }

        public static IEnumerable<Rarity> List()
        {
            return new Rarity[]
            {
                Normal,
                Magic,
                Unique,
                Legendary
            };
        }
    }
}
