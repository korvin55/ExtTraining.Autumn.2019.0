using System;

namespace AlgorithmsDay2
{
    public class ArrayExtension
    {
        public static int FMI(int[] array, int index, int length)
        {
            int result = 0;
            if (index + 1 < length)
            {
                if (array[index] < array[index + 1])
                {
                    result = array[index + 1];
                }
                else
                {
                    result = FMI(array, index + 1, length);
                }
            }
            return result;
        }

        public static int FindMximumItem(int[] array, int length)
        {
            int res = FMI(array, 0, length);
            return res;

        }


    }
}
