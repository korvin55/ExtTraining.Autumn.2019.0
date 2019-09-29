using System;

namespace AlgorithmsDay3Task2
{
    public class NumbersExtension
    {
        public static int FindPreviousLessThan(int number)
        {
            if (number < 0 || number >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException( nameof(number) + " is out of range");
            }

            if (number <= 11)
            {
                return 0;
            }

            return Next(number);
        }

        private static int СalculateLess(int number)
        {
            int[] arrayNumber = new int[number.ToString().Length];
            int numberStart = number;
            for (int i = 0; i < arrayNumber.Length; i++)
            {
                arrayNumber[i] = number % 10;
                number /= 10;
            }
            Array.Sort(arrayNumber);
            if (arrayNumber[0] == 0)
            {
                for(int i = 1; i < arrayNumber.Length; i++)
                {
                    if (arrayNumber[i] != 0)
                    {
                        int temp = arrayNumber[i];
                        arrayNumber[i] = arrayNumber[0];
                        arrayNumber[0] = temp;
                        break;
                    }
                }
            }
            int result = 0;
            for (int i = 0; i < arrayNumber.Length; i++)
            {
                result += (int)(arrayNumber[i] * Math.Pow(10, arrayNumber.Length - 1 - i));
            }
            if (result == numberStart)
            {
                return 0;
            }
            return result;
        }

        private static int Next(int number)
        {
            int[] buff = new int[number.ToString().Length];
            for (int i = buff.Length - 1; i > -1; i--)
            {
                buff[i] = number % 10;
                number /= 10;
            }

            int index = FindIndex(buff);

            if (index == -1)
            {
                return -1;
            }

            int temp;

            if (index < buff.Length - 1)
            {
                temp = buff[index];
                buff[index] = buff[index + 1];
                buff[index + 1] = temp;
                Array.Sort(buff, index + 1, buff.Length - index - 1);
            }

            int result = 0;
            for (int i = 0; i < buff.Length; i++)
            {
                result += (int)(buff[i] * Math.Pow(10, buff.Length - 1 - i));
            }

            return result;
        }

        private static int FindIndex(int[] temp)
        {
            for (int i = temp.Length - 1; i > 0; i--)
            {
                if (temp[i] < temp[i - 1])
                {
                    return (i );
                }
            }
            return -1;
        }
    }
}
