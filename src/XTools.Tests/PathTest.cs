using NUnit.Framework;
using XTools.Helpers;

namespace XTools.Tests
{
    [TestFixture]
    public class PathTest
    {
        [Test]
        public void IncrementTest()
        {
            Assert.AreEqual("proba (1).txt", PathHelper.Increment("proba.txt"));
            Assert.AreEqual("proba (35).txt", PathHelper.Increment("proba (34).txt"));
            Assert.AreEqual("proba_20141225 (65).txt", PathHelper.Increment("proba_20141225 (64).txt"));
        }
    }
}
