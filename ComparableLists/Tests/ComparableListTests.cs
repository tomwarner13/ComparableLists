using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
    [TestClass]
    public class ComparableListTests
    {
        [TestMethod]
        public void TestBasicEquality()
        {
            var l1 = new ComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            var l2 = new ComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            Assert.AreEqual(l1, l2);
        }

        [TestMethod]
        public void TestUnsortedEquality()
        {
            var l1 = new ComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            var l2 = new ComparableList<string>()
            {
                "a",
                "c",
                "b"
            };

            Assert.AreEqual(l1, l2);
        }

        [TestMethod]
        public void TestInequality()
        {
            var l1 = new ComparableList<string>()
            {
                "a",
                "b",
                "d"
            };

            var l2 = new ComparableList<string>()
            {
                "a",
                "c",
                "b"
            };

            Assert.AreNotEqual(l1, l2);
        }

        [TestMethod]
        public void TestNullEquality()
        {
            ComparableList<string> l1 = null;
            ComparableList<string> l2 = null;

            var l3 = new ComparableList<string>()
            {
                "a",
                "c",
                "b"
            };

            Assert.AreEqual(l1, l2);
            Assert.AreNotEqual(l1, l3);
        }
    }
}
