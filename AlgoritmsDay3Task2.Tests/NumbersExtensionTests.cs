using AlgorithmsDay3Task2;
using NUnit.Framework;
using System;

namespace Tests
{
    public class NumbersExtensionTests
    {
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(1852814666, ExpectedResult = 1852686641)]
        [TestCase(12345678, ExpectedResult = 0)]
        [TestCase(11111, ExpectedResult = 0)]

        public int TestsFindPreviousLessThanWithoutThrow(int number)
        {
            return NumbersExtension.FindPreviousLessThan(number);
        }

        [Test]
        public void TestFindPreviousLessThanWithExceptionOutOfRange()
        {
            Assert.That(() => NumbersExtension.FindPreviousLessThan(-124), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

    }
}