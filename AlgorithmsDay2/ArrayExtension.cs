using System;
using System.Collections.Generic;

namespace AlgorithmsDay2
{
    public class ArrayExtension
    {
        #region Task2,D2_Task2
        /// <summary>
        /// Find Maximum Value in array 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
        #endregion Task2,D2_Task2

        #region Task3,D2_Task3
        /// <summary>
        /// Find index, which has the same elements's sum on both sides
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
        #endregion Task3,D2_Task3

        #region Task1,D4_Task1 (D2_Task4)
        /// <summary>
        /// filter array with Key
        /// </summary>
        /// <param name="array"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static int[] FilterArrayByKey(int[] array, IPredicate filter)
        {
            ControlInputArray(array);

            List<int> filterArray = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (filter.IsContain(Math.Abs(array[i])))
                {
                    filterArray.Add(array[i]);
                }
            }
            return filterArray.ToArray();
        }
        #endregion Task1,D4_Task1 (D2_Task4)

        public static void ControlInputArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + "can't be null");
            }
            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + "length is 0 ");
            }
            if (array.Length > int.MaxValue)
            {
                throw new ArgumentException(nameof(array) + "length is very long ");
            }
        }
    }

    public interface IPredicate
    {
        bool IsContain(int number);
    }

    public class FilterPredicateByKey : IPredicate
    {
        private int key;
        public FilterPredicateByKey(int key)
        {
            ControlInputKey(key);
            this.key = key;
        }
        public bool IsContain(int number)
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
        private static void ControlInputKey(int key)
        {
            if (key < 0 || key > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(key) + "is out of range");
            }
        }
    }

    public class FilterPredicatePalindrome : IPredicate
    {
        public bool IsContain(int number)
        {
            int[] arrayNumber = new int[number.ToString().Length];
            if (arrayNumber.Length == 1)
            {
                return false;
            }
            for (int i = arrayNumber.Length - 1; i > -1; i--)
            {
                arrayNumber[i] = number % 10;
                number /= 10;
            }
            bool flag = true;
            for (int i = 0; i < arrayNumber.Length / 2; i++)
            {
                if (arrayNumber[i] != arrayNumber[arrayNumber.Length - 1 - i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
