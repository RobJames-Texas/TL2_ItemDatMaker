using System;
using System.Collections.Generic;
using System.Linq;

namespace TL2_ItemDatMaker.Components
{
    public class NgLevel
    {
        public int MinNgLevel { get; private set; }

        public int MaxNgLevel { get; private set; }

        public int MinItemLevel { get; private set; }

        public int MaxItemLevel { get; private set; }

        public int? LevelRequired { get; private set; }

        private Func<int, int> NgLevelCalcMath { get; set; }

        public int CalcNgLevel(int itemLevel)
        {
            //return MinItemLevel + itemLevel / 50 * MaxItemLevel - MinItemLevel;
            return NgLevelCalcMath(itemLevel);
        }

        private NgLevel(int minItemLevel, int maxItemLevel, int minNgLevel, int maxNgLevel, int? levelRequired, Func<int, int> ngLevelCalcMath)
        {
            MinItemLevel = minItemLevel;
            MaxItemLevel = maxItemLevel;
            MinNgLevel = minNgLevel;
            MaxNgLevel = maxNgLevel;
            LevelRequired = levelRequired;
            NgLevelCalcMath = ngLevelCalcMath;
        }

        public static NgLevel One = new NgLevel(51, 80, 51, 80, null, (int level) => { return 51 + level / 50 * 80 - 51; });

        public static NgLevel Two = new NgLevel(81, 100, 81, 100, null, (int level) => { return 81 + level / 50 * 100 - 81; });

        public static NgLevel Three = new NgLevel(101, 120, 99, 999, 101, (int level) => { return 105; });

        public static IEnumerable<NgLevel> Available(int itemLevel)
        {
            return List().Where(n => itemLevel < n.MinItemLevel);
        }

        private static IEnumerable<NgLevel> List()
        {
            return new NgLevel[]
            {
                One,
                Two,
                Three
            };
        }

    }
}
