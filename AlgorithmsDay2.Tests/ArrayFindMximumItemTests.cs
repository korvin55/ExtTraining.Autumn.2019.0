using AlgorithmsDay2;
using AlgorithmsDay2.Tests;
using NUnit.Framework;
using System;

namespace Tests
{

    public class ArrayFindMximumItemTests
    {
        [TestCase(new int[] { -3, -2, -8 }, ExpectedResult = -2)]
        [TestCase(new int[] { 63, 56, 1, 5, 7889, 10000 }, ExpectedResult = 10000)]

        public int TestFindMximumItemWithoutThrow(int[] array)
        {
            int res = ArrayExtension.FindMximumItem(array);
            return res;
        }

        [Test]
        public void TestFindMximumItemWithThrowNull()
        {
            Assert.That(() => ArrayExtension.FindMximumItem(null), Throws.TypeOf<System.ArgumentNullException>());
        }

        [Test]
        public void TestFindMximumItemWithThrowOutOfRange()
        {
            Assert.That(() => ArrayExtension.FindMximumItem(new int[] { }), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestFindMximumWithMaxArray()
        {
            (int[] array, int expectedResult) = MaxArray.Creat();
            Assert.AreEqual(expectedResult, ArrayExtension.FindMximumItem(array));
        }

    }
}