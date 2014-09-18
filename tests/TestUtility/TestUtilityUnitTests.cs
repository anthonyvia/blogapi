using System;
using System.Threading;
using NUnit.Framework;

namespace TestUtility
{
    [TestFixture]
    public class TestUtilityUnitTests
    {
        [TestCase]
        public void TestUnequalDates()
        {
            DateTime lhs = DateTime.UtcNow;
            Thread.Sleep(2000);
            DateTime rhs = DateTime.UtcNow;

            Assert.IsFalse(TestUtility.AreEqualDates(lhs, rhs));
        }

        [TestCase]
        public void TestEqualDates()
        {
            DateTime lhs = DateTime.UtcNow;
            DateTime rhs = lhs;

            Assert.IsTrue(TestUtility.AreEqualDates(lhs, rhs));
        }
    }
}
