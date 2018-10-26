using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class UnitTests
    {
        private string tab = TL2_ItemDatMaker.Constants.Tab;

        [TestMethod]
        public void ShouldSetupNormalStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01";
            UnitType unitType = UnitType.Staves;
            string name = "test";
            int itemLevel = 2;
            Rarity rarity = Rarity.Normal;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\staves\BASE_STAFF.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = $@"[UNIT]
{tab}<STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
{tab}<STRING>MESHFILE:staff_model_01
{tab}<STRING>BASEFILE:media\units\items\staves\BASE_STAFF.DAT
{tab}<STRING>UNIT_GUID:2013103151278660001
{tab}<STRING>UNITTYPE:NORMAL STAFF
{tab}<STRING>NAME:test
{tab}<INTEGER>LEVEL:2
{tab}<INTEGER>MINLEVEL:0
{tab}<INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity, guid);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }

        [TestMethod]
        public void ShouldSetupMagicStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01";
            UnitType unitType = UnitType.Staves;
            string name = "test2";
            int itemLevel = 2;
            Rarity rarity = Rarity.Magic;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\staves\BASE_STAFF_MAGIC.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = $@"[UNIT]
{tab}<STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
{tab}<STRING>MESHFILE:staff_model_01
{tab}<STRING>BASEFILE:media\units\items\staves\BASE_STAFF_MAGIC.DAT
{tab}<STRING>UNIT_GUID:2013103151278660001
{tab}<STRING>UNITTYPE:MAGIC STAFF
{tab}<STRING>NAME:test2
{tab}<INTEGER>LEVEL:2
{tab}<INTEGER>MINLEVEL:0
{tab}<INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity, guid);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }

        [TestMethod]
        public void ShouldSetupUniqueStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01";
            UnitType unitType = UnitType.Staves;
            string name = "test3";
            int itemLevel = 2;
            Rarity rarity = Rarity.Unique;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\staves\BASE_STAFF_UNIQUE.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = $@"[UNIT]
{tab}<STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
{tab}<STRING>MESHFILE:staff_model_01
{tab}<STRING>BASEFILE:media\units\items\staves\BASE_STAFF_UNIQUE.DAT
{tab}<STRING>UNIT_GUID:2013103151278660001
{tab}<STRING>UNITTYPE:UNIQUE STAFF
{tab}<STRING>NAME:test3
{tab}<INTEGER>LEVEL:2
{tab}<INTEGER>MINLEVEL:0
{tab}<INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity, guid);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }

        [TestMethod]
        public void ShouldSetupLegendaryStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01";
            UnitType unitType = UnitType.Staves;
            string name = "test4";
            int itemLevel = 2;
            Rarity rarity = Rarity.Legendary;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\staves\BASE_STAFF_UNIQUE.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = $@"[UNIT]
{tab}<STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
{tab}<STRING>MESHFILE:staff_model_01
{tab}<STRING>BASEFILE:media\units\items\staves\BASE_STAFF_UNIQUE.DAT
{tab}<STRING>UNIT_GUID:2013103151278660001
{tab}<STRING>UNITTYPE:LEGENDARY STAFF
{tab}<STRING>NAME:test4
{tab}<INTEGER>LEVEL:2
{tab}<INTEGER>MINLEVEL:0
{tab}<INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity, guid);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }

        [TestMethod]
        public void ShouldGenerateAltClones()
        {
            PathInfo pathInfo = new PathInfo(@".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH");

            IEnumerable<Unit> actual = Unit.GenerateVariations(pathInfo, UnitType.Staves, Rarity.Normal, 3, "test", true, false);

            actual.Should().HaveCount(3);

            Unit[] actualArray = actual.ToArray();

            string expectedAltBaseFile = @"media\units\items\staves\test.DAT";

            Assert.AreEqual(expectedAltBaseFile, actualArray[1].BaseFile);
            Assert.AreEqual(expectedAltBaseFile, actualArray[2].BaseFile);

            string datPath = pathInfo.CreateFullDatPath(actualArray[0].UnitType, actualArray[0].Name);

            datPath.Should().Contain(actualArray[1].BaseFile.ToUpper());
            datPath.Should().Contain(actualArray[2].BaseFile.ToUpper());
        }

        [TestMethod]
        public void ShouldGenerateNgClones()
        {
            PathInfo pathInfo = new PathInfo(@".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH");

            IEnumerable<Unit> actual = Unit.GenerateVariations(pathInfo, UnitType.Staves, Rarity.Normal, 3, "test", false, true);

            actual.Should().HaveCount(4);

            Unit[] actualArray = actual.ToArray();

            string expectedNgBaseFile = @"media\units\items\staves\test.DAT";

            Assert.AreEqual(expectedNgBaseFile, actualArray[1].BaseFile);
            Assert.AreEqual(expectedNgBaseFile, actualArray[2].BaseFile);
            Assert.AreEqual(expectedNgBaseFile, actualArray[3].BaseFile);

            Assert.IsNull(actualArray[0].LevelRequired);
            Assert.IsNull(actualArray[1].LevelRequired);
            Assert.IsNull(actualArray[2].LevelRequired);
            Assert.IsNotNull(actualArray[3].LevelRequired);


            string expectedBaseFile = $@"{tab}<STRING>BASEFILE:media\units\items\staves\test.DAT";
            string expectedName = $@"{tab}<STRING>NAME:testNG+3";
            string expectedRequiredLevel = $@"{tab}<INTEGER>LEVEL_REQUIRED:101";

            string actualDatContents = actualArray[3].ToDat();

            actualDatContents.Should().Contain(expectedBaseFile);
            actualDatContents.Should().Contain(expectedName);
            actualDatContents.Should().Contain(expectedRequiredLevel);

            string datPath = pathInfo.CreateFullDatPath(actualArray[0].UnitType, actualArray[0].Name);

            datPath.Should().Contain(actualArray[1].BaseFile.ToUpper());
            datPath.Should().Contain(actualArray[2].BaseFile.ToUpper());
            datPath.Should().Contain(actualArray[3].BaseFile.ToUpper());
        }

        [TestMethod]
        public void ShouldGenerateAltAndNgClones()
        {
            PathInfo pathInfo = new PathInfo(@".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH");

            IEnumerable<Unit> actual = Unit.GenerateVariations(pathInfo, UnitType.Staves, Rarity.Normal, 3, "test", true, true);

            actual.Should().HaveCount(12);
        }
    }
}
