using System;
using System.Collections.Generic;

namespace AlgorithmsDay3Task2
{
    public class NumbersExtension
    {
        public static int FindPreviousLessThan(int number)
        {
            ControlInputPositiveNumber(number);
            if (number <= 11)
            {
                return 0;
            }

            return FindLess(number);
        }

        private static int FindLess(int number)
        {
            int[] arrayNumber = new int[number.ToString().Length];
            for (int i = arrayNumber.Length - 1; i > -1; i--)
            {
                arrayNumber[i] = number % 10;
                number /= 10;
            }
            int indexFirst = FindIndex(arrayNumber);
            if (indexFirst == -1)
            {
                return 0;
            }
            int indexSecond = FindMaxFail(arrayNumber, indexFirst);
            Swap(ref arrayNumber[indexFirst], ref arrayNumber[indexSecond]);
            SortAscending(arrayNumber, indexFirst, arrayNumber.Length);

            int result = 0;
            for (int i = 0; i < arrayNumber.Length; i++)
            {
                result += (int)(arrayNumber[i] * Math.Pow(10, arrayNumber.Length - 1 - i));
            }

            return result;
        }

        private static int FindIndex(int[] arrayNumber)
        {
            for (int i = arrayNumber.Length - 1; i > 0; i--)
            {
                if (arrayNumber[i] < arrayNumber[i - 1])
                {
                    return (i - 1);
                }
            }
            return -1;
        }

        private static int FindMaxFail(int[] arrayNumber, int indexFirst)
        {
            int maxValue = int.MinValue;
            int index = -1;
            for (int i = indexFirst + 1; i < arrayNumber.Length; i++)
            {
                if (arrayNumber[i] > maxValue)
                {
                    maxValue = arrayNumber[i];
                    index = i;
                }
            }
            return index;
        }

        static void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        private static void SortAscending(int[] array, int start, int end)
        {
            for (int i = start + 2; i < end; i++)
            {
                int key = array[i];
                int j = i;
                while ((j >= start + 2) && array[j - 1] < key)
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
                array[j] = key;
            }
        }

        private static void ControlInputPositiveNumber(int positiveNumber)
        {
            if (positiveNumber < 0 || positiveNumber >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(positiveNumber) + " is out of range");
            }
        }
    }
}
