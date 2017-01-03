using Microsoft.VisualStudio.TestTools.UnitTesting;
using XTools.Helpers;

namespace XTools.Tests
{
    [TestClass]
    public class PathTestSlash
    {
        private PathHelper helper = new PathHelper("/");

        [TestMethod]
        public void RemoveLastFolder1()
        {
            Assert.IsTrue(helper.RemoveLastFolder("/dir1/dir2") == "/dir1");
        }

        [TestMethod]
        public void GetFileName1()
        {
            var result = helper.GetFileName("/dir1/dir2/file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        public void GetFileName2()
        {
            var result = helper.GetFileName("file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        public void GetFileName3()
        {
            var result = helper.GetFileName("/file'proba.fit");
            Assert.IsTrue(result == "file'proba.fit");
        }

        [TestMethod]
        public void GetFileNameWithoutExtension()
        {
            var result = helper.GetFileNameWithoutExtension("/dir1/dir2/file'proba.fit");
            Assert.IsTrue(result == "file'proba");
        }

        [TestMethod]
        public void GetFolderName()
        {
            var result = helper.GetFolderName("/dir1/dir2/testfilename.ext");
            Assert.AreEqual(result, "/dir1/dir2");
        }

        [TestMethod]
        public void CombineTest()
        {
            var result = helper.Combine("", "proba.txt");
            Assert.AreEqual("proba.txt", result);
        }

        [TestMethod]
        public void GetFileExtension()
        {
            var result = helper.GetFileExtension("/dir1/dir2/testfilename.ext");
            Assert.AreEqual(result, ".ext");
            Assert.AreEqual(helper.GetFileExtension("/dir1/testfilename"), "");
        }

    }
}
