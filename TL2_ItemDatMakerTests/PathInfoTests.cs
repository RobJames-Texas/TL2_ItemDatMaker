using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
            // Example: ".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH"
            List<string> pathParts = new List<string>
            {
                ".",
                "MEDIA",
                "MODELS",
                "WEAPONS",
                "_STAVES",
                "staff_model_01.MESH"
            };
            string meshFile = Path.Combine(pathParts.ToArray());
            PathInfo pathInfo = new PathInfo(meshFile);

            string expectedItemType = "_STAVES";
            string expectedMeshFile = "staff_model_01";
            string expectedResource = @"MEDIA/MODELS/WEAPONS/_STAVES";

            List<string> datPathParts = new List<string>
            {
                ".",
                "MEDIA",
                "UNITS",
                "ITEMS",
                "STAVES",
                "TEST.DAT"
            };
            string expectedDatPath = Path.Combine(datPathParts.ToArray());

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
