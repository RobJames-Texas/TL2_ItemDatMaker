using Microsoft.VisualStudio.TestTools.UnitTesting;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class RarityTests
    {
        [TestMethod]
        public void GetByLevel_ShouldReturnNullWhenInvalid()
        {
            string level = "Junk";
            Rarity expected = null;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLevel_ShouldReturnNormal()
        {
            string level = "normal";
            Rarity expected = Rarity.Normal;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLevel_ShouldReturnMagic()
        {
            string level = "magic";
            Rarity expected = Rarity.Magic;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLevel_ShouldReturnUnique()
        {
            string level = "unique";
            Rarity expected = Rarity.Unique;
            Rarity actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLevel_ShouldReturnLegendary()
        {
            string level = "legendary";
            var expected = Rarity.Legendary;
            var actual = Rarity.GetByLevel(level);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLetter_ShouldReturnNullWhenInvalid()
        {
            var letter = "j";
            Rarity expected = null;
            var actual = Rarity.GetByLetter(letter);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLetter_ShouldReturnNormal()
        {
            string letter = "N";
            var expected = Rarity.Normal;
            var actual = Rarity.GetByLetter(letter);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLetter_ShouldReturnMagic()
        {
            string letter = "m";
            var expected = Rarity.Magic;
            var actual = Rarity.GetByLetter(letter);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLetter_ShouldReturnUnique()
        {
            string letter = "u";
            var expected = Rarity.Unique;
            var actual = Rarity.GetByLetter(letter);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByLetter_ShouldReturnLegendary()
        {
            string letter = "l";
            var expected = Rarity.Legendary;
            var actual = Rarity.GetByLetter(letter);

            Assert.AreEqual(expected, actual);
        }
    }
}
