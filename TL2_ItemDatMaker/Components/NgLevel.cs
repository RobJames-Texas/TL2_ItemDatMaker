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

        public string Suffix { get; private set; }

        private NgLevelCalcDelegate _ngLevelCalcMath { get; set; }

        private delegate decimal NgLevelCalcDelegate(decimal level);

        public int CalcNgLevel(int itemLevel)
        {
            return (int)Math.Round(_ngLevelCalcMath(itemLevel), MidpointRounding.AwayFromZero);
        }

        private NgLevel(int minItemLevel, int maxItemLevel, int minNgLevel, int maxNgLevel, string suffix, int? levelRequired, NgLevelCalcDelegate ngLevelCalcMath)
        {
            MinItemLevel = minItemLevel;
            MaxItemLevel = maxItemLevel;
            MinNgLevel = minNgLevel;
            MaxNgLevel = maxNgLevel;
            Suffix = suffix;
            LevelRequired = levelRequired;
            _ngLevelCalcMath = ngLevelCalcMath;
        }

        public readonly static NgLevel One = new NgLevel(51, 80, 51, 80, "NG+", null, (level) => { return 51M + ((level / 50M) * (80M - 51M)); });

        public readonly static NgLevel Two = new NgLevel(81, 100, 81, 100, "NG+2", null, (level) => { return 81M + ((level / 50M) * (100M - 81M)); });

        public readonly static NgLevel Three = new NgLevel(101, 120, 99, 999, "NG+3", 101, (level) => { return 105M; });

        public static IEnumerable<NgLevel> Available(int itemLevel)
        {
            return List().Where(n => itemLevel < n.MinItemLevel);
        }

        private static IEnumerable<NgLevel> List()
        {
            return
            [
                One,
                Two,
                Three
            ];
        }

    }
}
