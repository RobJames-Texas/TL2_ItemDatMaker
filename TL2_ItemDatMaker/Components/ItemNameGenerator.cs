namespace TL2_ItemDatMaker.Components
{
    public static class ItemNameGenerator
    {
        public static string Create(UnitType unitType, Rarity rarity, string nameTag, int itemLevel)
        {
            string name;
            if (rarity.Equals(Rarity.Legendary))
            {
                name = string.Format("{0}_{1}{2}{3:00}", rarity.Level.ToLower(), unitType.NamePrefix, nameTag, itemLevel);
            }
            else
            {
                name = string.Format("{0}_{1}{2}{3:00}", unitType.NamePrefix, nameTag, rarity.NameLetter, itemLevel);
            }
            return name;
        }
    }
}
