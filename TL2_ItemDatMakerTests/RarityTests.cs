using Microsoft.VisualStudio.TestTools.UnitTesting;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class RarityTests
    {
        [TestMethod]
        public void ShouldReturnNullWhenInvalid()
        {
            string level = "Junk";
            Rarity expected = null;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnNormal()
        {
            string level = "normal";
            Rarity expected = Rarity.Normal;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnMagic()
        {
            string level = "magic";
            Rarity expected = Rarity.Magic;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnUnique()
        {
            string level = "unique";
            Rarity expected = Rarity.Unique;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnLegendary()
        {
            string level = "legendary";
            Rarity expected = Rarity.Legendary;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }
    }
}
