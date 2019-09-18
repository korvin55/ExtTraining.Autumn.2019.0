using NUnit.Framework;
using System;
namespace Algorithms.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new int[]{3, 2}, 2, ExpectedResult = new int[] {2, 3})]
        [TestCase(new int[] { 63, 56}, 8, ExpectedResult = new int[] {63, 56})]
        
        
        public int[] TestBubbleSort(int[] array, int system)
        {
            IComparer comparer = new NumberSystemComparator(system);
            ArrayExtension.BubbleSort(array, comparer);
            return array;
        }
    }
}
