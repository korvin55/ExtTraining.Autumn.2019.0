using System;

namespace Algorithms
{
    public static class ArrayExtension
    {
        static void Swap(ref int first,ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        public static void BubbleSort( int[] array, IComparer comparator)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparator.Compare(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i],ref array[j]);
                    }
                }
            }
        }

        public static int Partition(int[] array, int minIndex, int maxIndex, IComparer comparator)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (comparator.Compare(array[maxIndex], array[i]) > 0)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        public static int[] QuickSort(int[] array, int minIndex, int maxIndex, IComparer comparator)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, comparator);
            QuickSort(array, minIndex, pivotIndex - 1, comparator);
            QuickSort(array, pivotIndex + 1, maxIndex, comparator);

            return array;
        }

        public static int[] QuickSort(int[] array, IComparer comparator)
        {
            return QuickSort(array, 0, array.Length - 1, comparator);
        }

        public static void InsertionSort(int[] array, IComparer comparator)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j >= 1) && (comparator.Compare(array[j-1], key) > 0))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
                array[j] = key;
            }

        }

    }

    public interface IComparer
    {
        int Compare(int first, int second);
    }

    public class AbsComparator : IComparer
    {
        public int Compare(int first, int second)
        {
            return Math.Abs(first) - Math.Abs(second);
        }
    }

    public class NumberSystemComparator : IComparer
    {
        private int system;

        public NumberSystemComparator(int system)
        {
            this.system = system;
        }

        public int Compare(int first, int second)
        {
            return NumberSystem.Convert(first, system) - NumberSystem.Convert(second, system);
        }
    }

    public class NumberSystem
    {
        //doesn't work correctly
        public static int Convert(int number,int system)
        {
            int sum = 0;

            if (number <= 0 || system < 2)
            {
                return sum;
            }
            
            while (number > 1)
            {
                if ( number % system > 0)
                {
                    sum++;
                }
                number /= system;
            }
            return sum;
        }
    }

}
