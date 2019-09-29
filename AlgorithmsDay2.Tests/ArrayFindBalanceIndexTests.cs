using AlgorithmsDay2;
using AlgorithmsDay2.Tests;
using NUnit.Framework;
using System;

namespace Tests
{
    class ArrayFindBalanceIndexTests
    {
        [TestCase(new int[] { -3, -2, -8, -5, 0 }, ExpectedResult = 2)]
        [TestCase(new int[] { 10, -2, 5, 3, 2 }, ExpectedResult = 1)]
        [TestCase(new int[] { 10, 0, 0, 1, 1, 1, 1, 9 }, ExpectedResult = 4)]
        [TestCase(new int[] { 63, 56, 1, 5, 7889, 10000 }, ExpectedResult = null)]

        public int? TestFindBalanceIndex(int[] array)
        {
            return ArrayExtension.FindBalanceIndex(array);
        }

    }
}
