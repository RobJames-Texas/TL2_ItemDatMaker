using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TL2_ItemDatMaker;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class InteractiveOptionsTests
    {
        [TestMethod]
        public void GetMeshFileOptions_Should_FailWhenNoReader()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new InteractiveOptions(null));

            Assert.IsTrue(ex.Message.Contains("inputReader"));
        }

        [TestMethod]
        public void GetMeshFileOptions_Should_FailWhenMeshFileNotProvided()
        {
            var mockInput = new Mock<IInputReader>();

            var interactive = new InteractiveOptions(mockInput.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => interactive.GetMeshFileOptions(null));

            Assert.IsTrue(ex.Message.Contains("meshFile"));
        }

        [TestMethod]
        public void GetMeshFileOptions_Should_ReturnOptionsNoClones()
        {
            var mockInput = new Mock<IInputReader>();
            mockInput.SetupSequence(x => x.ReadKey())
                .Returns("z") // invalid rarity will cause it to get called again
                .Returns("n") // Normal rarity
                .Returns("n") // no alt clones
                .Returns("n"); // no ng clones
            mockInput.SetupSequence(x => x.ReadLine())
                .Returns("someTag")
                .Returns("1") // Should cause it to get called again
                .Returns("2"); // Item Level. This one should work

            var interactive = new InteractiveOptions(mockInput.Object);

            var actual = interactive.GetMeshFileOptions("someFile");

            Assert.IsNotNull(actual);
            Assert.AreEqual("someFile", actual.MeshFile);
            Assert.AreEqual("Normal", actual.ItemRarity);
            Assert.AreEqual(2, actual.ItemLevel);
            Assert.IsFalse(actual.AltClones);
            Assert.IsFalse(actual.NgClones);

            mockInput.Verify(x => x.ReadKey(), Times.Exactly(4));
            mockInput.Verify(x => x.ReadLine(), Times.Exactly(3)); // 3 because of the invalid input
        }

        [TestMethod]
        public void GetMeshFileOptions_Should_ReturnOptionsWithClones()
        {
            var mockInput = new Mock<IInputReader>();
            mockInput.SetupSequence(x => x.ReadKey())
                .Returns("m") // Magic rarity
                .Returns("y") // alt clones
                .Returns("y"); // ng clones
            mockInput.SetupSequence(x => x.ReadLine())
                .Returns("someTag")
                .Returns("2"); // Item level

            var interactive = new InteractiveOptions(mockInput.Object);

            var actual = interactive.GetMeshFileOptions("someFile");

            Assert.IsNotNull(actual);
            Assert.AreEqual("someFile", actual.MeshFile);
            Assert.AreEqual("Magic", actual.ItemRarity);
            Assert.AreEqual(2, actual.ItemLevel);
            Assert.IsTrue(actual.AltClones);
            Assert.IsTrue(actual.NgClones);

            mockInput.Verify(x => x.ReadKey(), Times.Exactly(3));
            mockInput.Verify(x => x.ReadLine(), Times.Exactly(2));
        }
    }
}
