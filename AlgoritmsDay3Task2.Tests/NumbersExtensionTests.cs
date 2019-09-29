using AlgorithmsDay3Task2;
using NUnit.Framework;
using System;

namespace Tests
{
    public class NumbersExtensionTests
    {
        [TestCase(1, ExpectedResult = 0)]

        [TestCase(52814666, ExpectedResult = 52686641052814666)]
        //1852814666
        //1852686641
        public int TestsFindPreviousLessThanWithoutThrow(int number)
        {

            return NumbersExtension.FindPreviousLessThan(number);
        }

    }
}