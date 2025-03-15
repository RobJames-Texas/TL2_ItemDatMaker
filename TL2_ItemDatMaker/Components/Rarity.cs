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

        public readonly static Rarity Normal = new("Normal", "n", "");

        public readonly static Rarity Magic = new("Magic", "m", "_magic");

        public readonly static Rarity Unique = new("Unique", "u", "_unique");

        public readonly static Rarity Legendary = new("Legendary", "l", "_unique");

        public static Rarity GetByLevel(string level)
        {
            return List().FirstOrDefault(r => r.Level.Equals(level, System.StringComparison.CurrentCultureIgnoreCase));
        }

        public static Rarity GetByLetter(string letter)
        {
            return List().FirstOrDefault(r => r.NameLetter.Equals(letter, System.StringComparison.CurrentCultureIgnoreCase));
        }

        public static IEnumerable<Rarity> List()
        {
            return
            [
                Normal,
                Magic,
                Unique,
                Legendary
            ];
        }
    }
}
