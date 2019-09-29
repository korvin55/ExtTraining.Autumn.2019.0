using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDay2.Tests
{
    class MaxArray
    {
        public static (int[],int) Creat()
        {
            Random random = new Random();
            int length = random.Next(100_000, 100_000_000);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, int.MaxValue - 10);
            }
            array[random.Next(0, length)] = int.MaxValue;
            return (array, int.MaxValue);
        }
    }
}
