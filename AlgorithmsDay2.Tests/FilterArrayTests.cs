using AlgorithmsDay2;
using AlgorithmsDay2.Tests;
using NUnit.Framework;
using System;

namespace Tests
{
    class FilterArrayTests
    {
        #region Task4,D2_Task4

        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]

        public int[] TestFilterArrayByKey(int[] array, int key)
        {
            IPredicate filter = new FilterPredicateByKey(key);
            return ArrayExtension.FilterArrayByKey(array, filter);
        }

        [Test]
        public void TestFilterArrayByKeyWithNull()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(null, new FilterPredicateByKey(5)), Throws.TypeOf<System.ArgumentNullException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionArray()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[0], new FilterPredicateByKey(0)), Throws.TypeOf<System.ArgumentException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionKey()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, new FilterPredicateByKey(-1)), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestFilterArrayByKeyArgumentExceptionKeyTwo()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, new FilterPredicateByKey(10)), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

        #endregion Task4,D2_Task4

        #region Task1,D4_Task1
        [TestCase(new[] {12221, 2, 45 }, ExpectedResult = new[] { 12221 })]
        [TestCase(new[] { 22, 0, 454 }, ExpectedResult = new[] { 22, 454 })]
        [TestCase(new[] { 0, 0, 1 }, ExpectedResult = new int [0])]
        [TestCase(new[] { 0, 13, 123321, 12321 }, ExpectedResult = new int[] {123321, 12321 })]
        public int[] TestFilterArrayByPalindrome(int[] array)
        {
            IPredicate filter = new FilterPredicatePalindrome();
            return ArrayExtension.FilterArrayByKey(array, filter);
        }

        [Test]
        public void TestFilterArrayByPalindromeWithNull()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(null, new FilterPredicatePalindrome()), Throws.TypeOf<System.ArgumentNullException>());
        }

        [Test]
        public void TestFilterArrayByPalindromeArgumentExceptionArray()
        {
            Assert.That(() => ArrayExtension.FilterArrayByKey(new int[0], new FilterPredicatePalindrome()), Throws.TypeOf<System.ArgumentException>());
        }

        #endregion Task1,D4_Task1

    }
}
