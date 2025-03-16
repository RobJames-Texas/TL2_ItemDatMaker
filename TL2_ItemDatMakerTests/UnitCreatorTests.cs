using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class UnitCreatorTests
    {
        [TestMethod]
        public void GenerateUnits_Should_ErrorWhenOptionsIsNull()
        {
            _ = Assert.Throws<ArgumentNullException>(() => UnitCreator.GenerateUnits(null));
        }

        [TestMethod]
        public void GenerateUnits_Should_ErrorWhenInvalidUnitType()
        {
            var options = new Options
            {
                MeshFile = @".\MEDIA\MODELS\WEAPONS\_JUNK\staff_model_01.MESH"
,
            };
            // Currently impossible to throw the "Invalid UnitType detected", PathInfo will throw first.
            _ = Assert.Throws<ArgumentException>(() => UnitCreator.GenerateUnits(options));
        }

        [TestMethod]
        public void GenerateUnits_Should_ErrorWhenInvalidRarityLevel()
        {
            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath()
            };
            var ex = Assert.Throws<ArgumentException>(() => UnitCreator.GenerateUnits(options));
            Assert.AreEqual("Invalid Rarity Level.", ex.Message);
        }

        [TestMethod]
        public void GenerateUnits_Should_ReturnOneUnit()
        {
            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal"
            };
            var actual = UnitCreator.GenerateUnits(options);
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count());
        }

        [TestMethod]
        public void GenerateUnits_Should_ReturnThreeUnits()
        {
            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal",
                AltClones = true
            };
            var actual = UnitCreator.GenerateUnits(options);
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count());
        }

        [TestMethod]
        public void GenerateUnits_Should_ReturnTwelveUnits()
        {
            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal",
                AltClones = true,
                NgClones = true
            };
            var actual = UnitCreator.GenerateUnits(options);
            Assert.IsNotNull(actual);
            Assert.AreEqual(12, actual.Count());
        }
    }
}
