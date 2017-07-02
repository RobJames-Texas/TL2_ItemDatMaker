using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class PathInfoTests
    {
        [TestMethod]
        public void ShouldFillInWithStaffPropertiesWhenPathIsGood()
        {
            string meshFile = @".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH";
            PathInfo pathInfo = new PathInfo(meshFile);

            string expectedItemType = "_STAVES";
            string expectedMeshFile = "staff_model_01.MESH";
            string expectedResource = @"MEDIA/MODELS/WEAPONS/_STAVES";
            string expectedDatPath = @".\MEDIA\UNITS\ITEMS\STAVES\TEST.DAT";

            Assert.IsNotNull(pathInfo);
            Assert.AreEqual(expectedItemType, pathInfo.ItemType);
            Assert.AreEqual(expectedMeshFile, pathInfo.MeshFile);
            Assert.AreEqual(expectedResource, pathInfo.Resource);
            Assert.AreEqual(expectedDatPath, pathInfo.CreateFullDatPath(UnitType.Staves, "test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldFailOnNoPath()
        {
            string meshFile = @"";
            PathInfo pathInfo = new PathInfo(meshFile);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldFailOnFileOnly()
        {
            string meshFile = @"staff_model_01.MESH";
            PathInfo pathInfo = new PathInfo(meshFile);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldFailOnBadItemType()
        {
            string meshFile = @".\MEDIA\MODELS\WEAPONS\_JUNK\staff_model_01.MESH";
            PathInfo pathInfo = new PathInfo(meshFile);
        }
    }
}
