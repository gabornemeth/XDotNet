using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTools.Helpers;

namespace XTools.Tests
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void IncrementTest()
        {
            Assert.AreEqual("proba (1).txt", PathHelper.Increment("proba.txt"));
            Assert.AreEqual("proba (35).txt", PathHelper.Increment("proba (34).txt"));
            Assert.AreEqual("proba_20141225 (65).txt", PathHelper.Increment("proba_20141225 (64).txt"));
        }
    }
}
