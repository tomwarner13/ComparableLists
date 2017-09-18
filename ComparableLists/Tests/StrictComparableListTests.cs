using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
    [TestClass]
    public class StrictComparableListTests
    {
        [TestMethod]
        public void TestBasicEquality()
        {
            var l1 = new StrictComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            var l2 = new StrictComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            Assert.AreEqual(l1, l2);
        }

        [TestMethod]
        public void TestBasicInequality()
        {
            var l1 = new StrictComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            var l2 = new StrictComparableList<string>()
            {
                "a",
                "b",
                "d"
            };

            Assert.AreNotEqual(l1, l2);
        }

        [TestMethod]
        public void TestUnsortedInequality()
        {
            var l1 = new StrictComparableList<string>()
            {
                "a",
                "b",
                "c"
            };

            var l2 = new StrictComparableList<string>()
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
            StrictComparableList<string> l1 = null;
            StrictComparableList<string> l2 = null;

            var l3 = new StrictComparableList<string>()
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
