using System;
using NUnit.Framework;

namespace XTools.Tests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void Random_String()
        {
            string s = StringExtensions.GetRandomString(20);
            Console.WriteLine(s);
            Assert.IsTrue(s.Length == 20);
        }
    }
}
