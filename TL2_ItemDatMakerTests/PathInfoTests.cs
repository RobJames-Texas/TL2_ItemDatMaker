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
            // ".\MEDIA\MODELS\WEAPONS\_STAVES\staff_model_01.MESH";
            List<string> pathParts =
            [
                ".",
                "MEDIA",
                "MODELS",
                "WEAPONS",
                "_STAVES",
                "staff_model_01.MESH"
            ];
            string meshFile = Path.Combine([.. pathParts]);
            var pathInfo = new PathInfo(meshFile);

            string expectedItemType = "_STAVES";
            string expectedMeshFile = "staff_model_01";
            string expectedResource = @"MEDIA/MODELS/WEAPONS/_STAVES";

            List<string> datPathParts =
            [
                ".",
                "MEDIA",
                "UNITS",
                "ITEMS",
                "STAVES",
                "TEST.DAT"
            ];
            string expectedDatPath = Path.Combine([.. datPathParts]);

            Assert.IsNotNull(pathInfo);
            Assert.AreEqual(expectedItemType, pathInfo.ItemType);
            Assert.AreEqual(expectedMeshFile, pathInfo.MeshFile);
            Assert.AreEqual(expectedResource, pathInfo.Resource);
            Assert.AreEqual(expectedDatPath, pathInfo.CreateFullDatPath(UnitType.Staves, "test"));
        }

        [TestMethod]
        public void ShouldFailOnNoPath()
        {
            string meshFile = @"";
            _ = Assert.ThrowsExactly<ArgumentException>(() => new PathInfo(meshFile));
        }

        [TestMethod]
        public void ShouldFailOnNoMesh()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => new PathInfo(@".nope"));
        }

        [TestMethod]
        public void ShouldFailOnFileOnly()
        {
            string meshFile = @"staff_model_01.MESH";
            _ = Assert.ThrowsExactly<ArgumentException>(() => new PathInfo(meshFile));
        }

        [TestMethod]
        public void ShouldFailOnBadItemType()
        {
            string meshFile = @".\MEDIA\MODELS\WEAPONS\_JUNK\staff_model_01.MESH";
            _ = Assert.ThrowsExactly<ArgumentException>(() => new PathInfo(meshFile));
        }
    }
}
