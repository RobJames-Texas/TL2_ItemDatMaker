using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TL2_ItemDatMaker.Components;

namespace TL2_ItemDatMakerTests
{
    [TestClass]
    public class TorchlightGuidTests
    {
        [TestMethod]
        public void ShouldCreateLong()
        {
            long actual = TorchlightGuid.Generate();
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        public void ShouldNotBeTheSame()
        {
            long notExpected = TorchlightGuid.Generate();
            long actual = TorchlightGuid.Generate();
            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
