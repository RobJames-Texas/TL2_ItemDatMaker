using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TL2_ItemDatMaker.Models;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ShouldSetupNormalStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01.MESH";
            UnitType unitType = UnitType.Staves;
            string name = "test";
            int itemLevel = 2;
            Rarity rarity = Rarity.Normal;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\BASE_STAFF.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = @"[UNIT]
    <STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
    <STRING>MESHFILE:staff_model_01.MESH
    <STRING>BASEFILE:media\units\items\BASE_STAFF.DAT
    <STRING>UNIT_GUID:2013103151278660001
    <STRING>UNITTYPE:NORMAL STAFF
    <STRING>NAME:test
    <INTEGER>LEVEL:2
    <INTEGER>MINLEVEL:0
    <INTEGER>MAXLEVEL:5
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
            string meshFile = "staff_model_01.MESH";
            UnitType unitType = UnitType.Staves;
            string name = "test2";
            int itemLevel = 2;
            Rarity rarity = Rarity.Magic;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\BASE_STAFF_MAGIC.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = @"[UNIT]
    <STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
    <STRING>MESHFILE:staff_model_01.MESH
    <STRING>BASEFILE:media\units\items\BASE_STAFF_MAGIC.DAT
    <STRING>UNIT_GUID:2013103151278660001
    <STRING>UNITTYPE:MAGIC STAFF
    <STRING>NAME:test2
    <INTEGER>LEVEL:2
    <INTEGER>MINLEVEL:0
    <INTEGER>MAXLEVEL:5
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
            string meshFile = "staff_model_01.MESH";
            UnitType unitType = UnitType.Staves;
            string name = "test3";
            int itemLevel = 2;
            Rarity rarity = Rarity.Unique;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\BASE_STAFF_UNIQUE.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = @"[UNIT]
    <STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
    <STRING>MESHFILE:staff_model_01.MESH
    <STRING>BASEFILE:media\units\items\BASE_STAFF_UNIQUE.DAT
    <STRING>UNIT_GUID:2013103151278660001
    <STRING>UNITTYPE:UNIQUE STAFF
    <STRING>NAME:test3
    <INTEGER>LEVEL:2
    <INTEGER>MINLEVEL:0
    <INTEGER>MAXLEVEL:5
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
            string meshFile = "staff_model_01.MESH";
            UnitType unitType = UnitType.Staves;
            string name = "test4";
            int itemLevel = 2;
            Rarity rarity = Rarity.Legendary;
            long guid = 2013103151278660001;

            string expectedBaseFile = @"media\units\items\BASE_STAFF_UNIQUE.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = @"[UNIT]
    <STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
    <STRING>MESHFILE:staff_model_01.MESH
    <STRING>BASEFILE:media\units\items\BASE_STAFF_UNIQUE.DAT
    <STRING>UNIT_GUID:2013103151278660001
    <STRING>UNITTYPE:LEGENDARY STAFF
    <STRING>NAME:test4
    <INTEGER>LEVEL:2
    <INTEGER>MINLEVEL:0
    <INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity, guid);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }
    }
}
