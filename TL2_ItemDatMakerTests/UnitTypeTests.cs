using Microsoft.VisualStudio.TestTools.UnitTesting;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class UnitTypeTests
    {

        [TestMethod]
        public void ShouldReturnNullWhenInvalid()
        {
            string itemType = "_JUNK";

            UnitType expected = null;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnStaves()
        {
            string itemType = "_STAVES";

            UnitType expected = UnitType.Staves;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnStavesEvenWhenLowerCase()
        {
            string itemType = "_staves";

            UnitType expected = UnitType.Staves;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnAxes()
        {
            string itemType = "_AXES";

            UnitType expected = UnitType.Axes;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnBows()
        {
            string itemType = "_BOWS";

            UnitType expected = UnitType.Bows;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnCannons()
        {
            string itemType = "_CANNONS";

            UnitType expected = UnitType.Cannons;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnCrossBows()
        {
            string itemType = "_CROSSBOWS";

            UnitType expected = UnitType.Crossbows;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnFists()
        {
            string itemType = "_FISTS";

            UnitType expected = UnitType.Fists;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnGreatAxes()
        {
            string itemType = "_GREATAXES";

            UnitType expected = UnitType.GreatAxes;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnGreatHammers()
        {
            string itemType = "_GREATHAMMERS";

            UnitType expected = UnitType.GreatHammers;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnGreatSwords()
        {
            string itemType = "_GREATSWORDS";

            UnitType expected = UnitType.GreatSwords;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnHammers()
        {
            string itemType = "_HAMMERS";

            UnitType expected = UnitType.Hammers;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnPistols()
        {
            string itemType = "_PISTOLS";

            UnitType expected = UnitType.Pistols;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnPolearms()
        {
            string itemType = "_POLEARMS";

            UnitType expected = UnitType.Polearms;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnRifles()
        {
            string itemType = "_RIFLES";

            UnitType expected = UnitType.Rifles;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnShields()
        {
            string itemType = "_SHIELDS";

            UnitType expected = UnitType.Shields;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnSwords()
        {
            string itemType = "_SWORDS";

            UnitType expected = UnitType.Swords;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnWands()
        {
            string itemType = "_WANDS";

            UnitType expected = UnitType.Wands;
            UnitType actual = UnitType.GetByMeshFolder(itemType);

            Assert.AreEqual(expected, actual);
        }
    }
}
