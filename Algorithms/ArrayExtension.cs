using System;

namespace Algorithms
{
    public static class ArrayExtension
    {
        static void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        public static void BubbleSort(int[] array, IComparer comparator, IIterable iterator)
        {
            bool isSort = true;
            while (isSort)
            {
                isSort = false;
                for (int current = iterator.GetStart(); !iterator.IsEnd(); current = iterator.GetCurrent())
                {

                    int next = iterator.GetNext();
                    if (comparator.Compare(array[current], array[next]) > 0)
                    {
                        Swap(ref array[current], ref array[next]);
                        isSort = true;
                    }
                    iterator.Next();
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
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i;
                while ((j >= 1) && (comparator.Compare(array[j - 1], key) > 0))
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
        private int flag;

        public NumberSystemComparator(int system, int flag)
        {
            this.system = system;
            this.flag = flag;
        }

        public int Compare(int first, int second)
        {
            return NumberSystem.Convert(first, system, flag) - NumberSystem.Convert(second, system, flag);
        }
    }

    public class NumberSystem
    {
        public static int Convert(int number, int system, int flag)
        {
            int sum = 0;


            while (Math.Abs(number) > 1)
            {
                if (Math.Abs(number) % system == flag)
                {
                    sum++;
                }
                number /= system;
            }
            return sum;
        }
    }

    public interface IIterable
    {
        int GetStart();
        int GetCurrent();
        void Next();
        int GetNext();
        int GetPreview();
        bool IsEnd();
    }

    public class Iterator : IIterable
    {
        private int start;
        private int end;
        private int step;
        private int current;

        public Iterator(int start, int end, int step)
        {
            this.start = start;
            this.end = end;
            this.step = step;
            current = start;
        }

        public int GetStart()
        {
            current = start;
            return start;
        }
        public int GetCurrent()
        {
            return current;
        }

        public void Next()
        {
            if (start + step <= end)
            {
                current += step;
            }
        }

        public int GetNext()
        {
            if (start + step <= end)
            {
                return current + step;
            }
            return current;
        }

        public int GetPreview()
        {
            if (current - step >= start)
            {
                return current - step;
            }
            return current;
        }

        public bool IsEnd()
        {
            if (current >= end)
            {
                return true;
            }
            return false;
        }
    }

}
