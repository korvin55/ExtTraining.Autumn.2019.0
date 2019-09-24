using AlgorithmsDay2;
using NUnit.Framework;
using System;

namespace Tests
{

    public class ArrayExtensionTests
    {
        [TestCase(new int[] { -3, -2, -8 }, 3, ExpectedResult = -2)]
        [TestCase(new int[] { 63, 56, 1, 5, 7889, 10000 }, 6, ExpectedResult = 10000)]

        public int TestFindMximumItem(int[] array, int length)
        {
            int res = ArrayExtension.FindMximumItem(array, length);
            return res;
        }

    }
}