using AlgorithmsDay2;
using AlgorithmsDay2.Tests;
using NUnit.Framework;
using System;

namespace Tests
{
    class FilterArrayTests
    {
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]

        public int[] TestFilterArrayByKey(int[] array, int key)
        {
            return ArrayExtension.FilterArrayByKey(array, key);
        }

        [Test]
        public void TestFilterArrayByKeyWithNull()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(null, 5), Throws.TypeOf<System.ArgumentNullException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionArray()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[0], 0), Throws.TypeOf<System.ArgumentException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionKey()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionKeyTwo()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, 10), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

    }
}
