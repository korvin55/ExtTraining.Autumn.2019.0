using System;

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
            return FindBalance(1);

            int? FindBalance(int balanceIndex)
            {
                if (balanceIndex < array.Length - 1)
                {
                    int resultLeft = 0;
                    int resultRight = 0;
                    for (int i = 0; i < balanceIndex; i++)
                    {
                        resultLeft += array[i];
                    }
                    for (int i = balanceIndex + 1; i < array.Length; i++)
                    {
                        resultRight += array[i];
                    }
                    if (resultLeft == resultRight)
                    {
                        return balanceIndex;
                    }
                    return FindBalance(balanceIndex + 1);
                }
                return null;
            }
        }

        private static void ControlInputArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + "can't be null");
            }
            if (array.Length == int.MaxValue || array.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array) + "length out of range ");
            }
        }






    }
}
