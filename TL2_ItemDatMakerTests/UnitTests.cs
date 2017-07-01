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
        public void ShouldSetupStaff()
        {
            string resource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string meshFile = "staff_model_01.MESH";
            UnitType unitType = UnitType.Staves;
            string name = "test";
            int itemLevel = 2;
            Rarity rarity = Rarity.Normal;

            string expectedBaseFile = @"media\units\items\BASE_STAFF.DAT";
            int expectedMinLevel = 0;
            int expectedMaxLevel = 5;

            string expectedDatContents = @"[UNIT]
<STRING>RESOURCEDIRECTORY:MEDIA/MODELS/WEAPONS/_STAVES
<STRING>MESHFILE:staff_model_01.MESH
<STRING>BASEFILE:media\units\items\BASE_STAFF.DAT
<STRING>UNITTYPE:STAFF
<STRING>NAME:test
<INTEGER>LEVEL:2
<INTEGER>MINLEVEL:0
<INTEGER>MAXLEVEL:5
[/UNIT]";


            Unit actual = new Unit(resource, meshFile, unitType, name, itemLevel, rarity);

            Assert.AreEqual(expectedBaseFile, actual.BaseFile);
            Assert.AreEqual(expectedMinLevel, actual.MinLevel);
            Assert.AreEqual(expectedMaxLevel, actual.MaxLevel);
            Assert.AreEqual(expectedDatContents, actual.ToDat());
        }
    }
}
