using NUnit.Framework;
using System;
namespace Algorithms.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [TestCase(new int[]{3, 2, 8}, 2, 1, 0, 2, 1, ExpectedResult = new int[] {2, 8, 3})]
        [TestCase(new int[] { 63, 56}, 8, 7, 0, 1, 1, ExpectedResult = new int[] {56, 63})]
        
        public int[] TestBubbleSort(int[] array, int system, int flag, int start, int end, int step)
        {
            IComparer comparer = new NumberSystemComparator(system, flag);
            IIterable iterator = new Iterator(start, end, step);
            ArrayExtension.BubbleSort(array, comparer, iterator);
            return array;
        }

        [TestCase(new int[] { 3, 2 }, 2, 1, ExpectedResult = new int[] { 2, 3 })]
        [TestCase(new int[] { 63, 56 }, 8, 7, ExpectedResult = new int[] { 56, 63 })]

        public int[] TestQuickSort(int[] array, int system, int flag)
        {
            IComparer comparer = new NumberSystemComparator(system, flag);
            ArrayExtension.QuickSort(array, comparer);
            return array; 
        }

        [TestCase(new int[] { 3, 2 }, 2, 1, ExpectedResult = new int[] { 2, 3 })]
        [TestCase(new int[] { 63, 56 }, 8, 7, ExpectedResult = new int[] { 56, 63 })]

        public int[] TestInsertionSort(int[] array, int system, int flag)
        {
            IComparer comparer = new NumberSystemComparator(system, flag);
            ArrayExtension.InsertionSort(array, comparer);
            return array;
        }
    }
}
