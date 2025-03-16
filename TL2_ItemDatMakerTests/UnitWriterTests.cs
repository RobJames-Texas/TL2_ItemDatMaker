using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Linq;
using TL2_ItemDatMaker;
using TL2_ItemDatMaker.Components;
using TL2_ItemDatMaker.Models;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class UnitWriterTests
    {
        [TestMethod]
        public void WriteUnits_Should_NotThrowWhenUnitsAreNull()
        {
            var mockInput = new Mock<IInputReader>();

            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal"
            };
            var unitWriter = new UnitWriter(options, mockInput.Object);

            unitWriter.WriteUnits(null);
        }

        [TestMethod]
        public void WriteUnits_Should_AskToCreateFolderAndNotCreateIt()
        {
            var mockInput = new Mock<IInputReader>();
            mockInput.Setup(x => x.ReadKey()).Returns("n");

            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal"
            };
            var units = UnitCreator.GenerateUnits(options);
            var unit = units.FirstOrDefault();

            var pathInfo = new PathInfo(options.MeshFile);
            var destination = pathInfo.CreateFullDatPath(unit.UnitType, unit.Name);
            var folder = Path.GetDirectoryName(destination);
            if (Directory.Exists(folder))
            {
                // Need to cleanup previous run.
                Directory.Delete(folder, true);
            }

            var unitWriter = new UnitWriter(options, mockInput.Object);

            unitWriter.WriteUnits(units);

            mockInput.Verify(x => x.ReadKey(), Times.Once);
            Assert.IsFalse(Directory.Exists(folder));
        }

        [TestMethod]
        public void WriteUnits_Should_AskToCreateFolderAndShouldCreateIt()
        {
            var mockInput = new Mock<IInputReader>();
            mockInput.Setup(x => x.ReadKey()).Returns("y");

            var options = new Options
            {
                MeshFile = TestHelpers.BuildGoodMeshPath(),
                ItemRarity = "normal"
            };
            var units = UnitCreator.GenerateUnits(options);
            var unit = units.FirstOrDefault();

            var pathInfo = new PathInfo(options.MeshFile);
            var destination = pathInfo.CreateFullDatPath(unit.UnitType, unit.Name);
            var folder = Path.GetDirectoryName(destination);
            if (Directory.Exists(folder))
            {
                // Need to cleanup previous run.
                Directory.Delete(folder, true);
            }

            var unitWriter = new UnitWriter(options, mockInput.Object);

            unitWriter.WriteUnits(units);

            mockInput.Verify(x => x.ReadKey(), Times.Once);
            Assert.IsTrue(Directory.Exists(folder));
            Assert.IsTrue(File.Exists(destination));

            // Cleanup
            Directory.Delete(folder, true);
        }
    }
}
