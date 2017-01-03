using Microsoft.VisualStudio.TestTools.UnitTesting;
using XTools.Helpers;

namespace XTools.Tests
{
    [TestClass]
    public class PathTestBackslash
    {
        private PathHelper helper = new PathHelper("\\");
        private const string Category = "Path tests with \\ separator";
        
        [TestMethod]
        [TestCategory(Category)]
        public void RemoveLastFolder1()
        {
            Assert.IsTrue(helper.RemoveLastFolder(@"c:\dir1\dir2") == @"c:\dir1");
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetFileName1()
        {
            var result = helper.GetFileName(@"c:\dir1\dir2\file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetFileName2()
        {
            var result = helper.GetFileName("file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetFileName3()
        {
            var result = helper.GetFileName(@"\file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        [TestCategory(Category)]
        public void GetFileNameWithoutExtension()
        {
            var result = helper.GetFileNameWithoutExtension(@"\dir1\dir2\file'proba.fit");
            Assert.IsTrue(result == "file'proba");
        }
    }
}
