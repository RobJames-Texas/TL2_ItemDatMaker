using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TL2_ItemDatMaker.Components;


namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class NgLevelTests
    {
        [TestMethod]
        public void ShouldGetAllForLowLevelItem()
        {
            IEnumerable<NgLevel> expected = new NgLevel[] { NgLevel.One, NgLevel.Two, NgLevel.Three };

            IEnumerable<NgLevel> actual = NgLevel.Available(2);
            IEnumerable<NgLevel> actual2 = NgLevel.Available(50);

            actual.Should().BeEquivalentTo(expected);
            actual2.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ShouldGetUpperTwoForMidLevelItem()
        {
            IEnumerable<NgLevel> expected = new NgLevel[] { NgLevel.Two, NgLevel.Three };

            IEnumerable<NgLevel> actual = NgLevel.Available(51);
            IEnumerable<NgLevel> actual2 = NgLevel.Available(80);

            actual.Should().BeEquivalentTo(expected);
            actual2.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ShouldGetTopForHighLevelItem()
        {
            IEnumerable<NgLevel> expected = new NgLevel[] { NgLevel.Three };

            IEnumerable<NgLevel> actual = NgLevel.Available(81);
            IEnumerable<NgLevel> actual2 = NgLevel.Available(100);

            actual.Should().BeEquivalentTo(expected);
            actual2.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ShouldGetNoneForAbove100LevelItem()
        {
            IEnumerable<NgLevel> expected = new NgLevel[] { }.AsEnumerable();

            IEnumerable<NgLevel> actual = NgLevel.Available(101);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ShouldBeNgLevel60()
        {
            int expected = 60;
            int actual = NgLevel.One.CalcNgLevel(15);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldBeNgLevel87()
        {
            int expected = 87;
            int actual = NgLevel.Two.CalcNgLevel(15);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldBeNgLevel105()
        {
            int expected = 105;
            int actual = NgLevel.Three.CalcNgLevel(15);

            Assert.AreEqual(expected, actual);
        }
    }
}
