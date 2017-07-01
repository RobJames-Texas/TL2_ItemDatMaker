using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class ItemNameGeneratorTests
    {
        [TestMethod]
        public void ShouldMatchNormal()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Normal;
            string nameTag = "";
            int itemLevel = 2;

            string expected = "staff_n02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchNormalWithTag()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Normal;
            string nameTag = "TEST";
            int itemLevel = 2;

            string expected = "staff_TESTn02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchMagic()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Magic;
            string nameTag = "";
            int itemLevel = 2;

            string expected = "staff_m02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchMagicWithTag()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Magic;
            string nameTag = "TEST";
            int itemLevel = 2;

            string expected = "staff_TESTm02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchUnique()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Unique;
            string nameTag = "";
            int itemLevel = 2;

            string expected = "staff_u02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchUniqueWithTag()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Unique;
            string nameTag = "TEST";
            int itemLevel = 2;

            string expected = "staff_TESTu02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchLegendary()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Legendary;
            string nameTag = "";
            int itemLevel = 2;

            string expected = "legendary_staff02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldMatchLegendaryWithTag()
        {
            UnitType unitType = UnitType.Staves;
            Rarity rarity = Rarity.Legendary;
            string nameTag = "TEST";
            int itemLevel = 2;

            string expected = "legendary_staffTEST02";

            string actual = ItemNameGenerator.Create(unitType, rarity, nameTag, itemLevel);

            Assert.AreEqual(expected, actual);
        }
    }
}
