using System;

namespace TL2_ItemDatMaker.Components
{
    public static class TorchlightGuid
    {
        private static readonly Random r = new Random();

        public static long Generate()
        {
            long first = r.Next(int.MinValue, int.MaxValue);
            long second = r.Next();

            first = first << 32;

            return first + second;
        }
    }
}
