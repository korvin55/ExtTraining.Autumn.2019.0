using System;
using System.Collections.Generic;

namespace AlgorithmsDay2
{
    public class ArrayExtension
    {
        public static int FindMximumItem(int[] array)
        {
            ControlInputArray(array);
            return FindMaxValue(0, array.Length - 1);

            int FindMaxValue(int first, int second)
            {
                if (second - first == 1)
                {
                    return Math.Max(array[first], array[second]);
                }

                return Math.Max(FindMaxValue(first, (first + second) / 2), FindMaxValue((first + second) / 2, second));
            }

        }

        public static int? FindBalanceIndex(int[] array)
        {
            ControlInputArray(array);
            if (array.Length < 3)
            {
                return null;
            }
            int sumAllAlements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumAllAlements += array[i];
            }
            return FindBalance(1);

            int? FindBalance(int balanceIndex)

            {
                if (balanceIndex < array.Length - 1)
                {
                    int resultLeft = 0;
                    for (int i = 0; i < balanceIndex; i++)
                    {
                        resultLeft += array[i];
                    }
                    if (resultLeft == sumAllAlements - resultLeft - array[balanceIndex])
                    {
                        return balanceIndex;
                    }
                    return FindBalance(balanceIndex + 1);
                }
                return null;
            }
        }

        public static int[] FilterArrayByKey(int[] array, int key)
        {
            ControlInputArray(array);
            ControlInputKey(key);

            List<int> filterArray = new List<int>();
            IPredicate filter = new FilterPredicate();
            for (int i = 0; i < array.Length; i++)
            {
                if (filter.IsContain(Math.Abs(array[i]), key))
                {
                    filterArray.Add(array[i]);
                }
            }
            return filterArray.ToArray();
        }

        private static void ControlInputArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + "can't be null");
            }
            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + "length is 0 ");
            }
            if (array.Length > int.MaxValue )
            {
                throw new ArgumentException(nameof(array) + "length is very long ");
            }
        }

        private static void ControlInputKey(int key)
        {
            if (key < 0 || key > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(key) + "is out of range");
            }
        }
    }

    public interface IPredicate
    {
        bool IsContain(int number, int key);
    }

    public class FilterPredicate : IPredicate
    {
        public bool IsContain(int number, int key)
        {
            while (number > 0)
            {
                if (number % 10 == key)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
