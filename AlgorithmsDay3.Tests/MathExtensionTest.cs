using AlgorithmsDay3Task1;
using NUnit.Framework;

namespace Tests
{
    public class MathExtensionTest
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]


        public void TestFindNthRootWithoutThrow(double a, int n, double accurancy, double expectedResult)
        {
            Assert.AreEqual(MathExtension.FindNthRoot(a, n, accurancy), expectedResult, accurancy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]

        
        public void TestFindNthRootWithThrow(double a, int n, double accurancy)
        {
            Assert.That(() => MathExtension.FindNthRoot(a, n, accurancy), Throws.TypeOf<System.ArgumentException>());
        }
        [TestCase( 4, 2, 8, 0, ExpectedResult = 2)]
        [TestCase( 40, 4, 20, 9, ExpectedResult = 1)]
        [TestCase( 5, 5, 55, 5, ExpectedResult = 5)]
        [TestCase(10, 2, ExpectedResult = 2)]
        [TestCase(-15, 3, 30, -60, ExpectedResult = 3)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        public int TestFindGcdByEuclidean(params int[] array)
        {
            return MathExtension.FindGcdByEuclidean(array);
        }

        [TestCase(4, 2, 8, 0, ExpectedResult = 2)]
        [TestCase(40, 4, 20, 9, ExpectedResult = 1)]
        [TestCase(5, 5, 55, 5, ExpectedResult = 5)]
        [TestCase(10, 2, ExpectedResult = 2)]
        [TestCase(-15, 3, 30, -60, ExpectedResult = 3)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        public int TestFindGcdByStein(params int[] array)
        {
            return MathExtension.FindGcdByStein(array);
        }


    }
}