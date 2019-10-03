using System;

namespace AlgorithmsDay3Task1
{
    public class MathExtension
    {
        /// <summary>
        /// find sqrt from number A
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree"></param>
        /// <param name="accurancy"></param>
        /// <returns></returns>
        public static double FindNthRoot(double number, int degree, double accurancy)
        {
            if (accurancy <= 0)
            {
                throw new ArgumentException(nameof(accurancy) + "is negative");
            }
            if (degree <= 0)
            {
                throw new ArgumentException(nameof(degree) + "is negative");
            }
            if (number <= 0 && degree % 2 == 0)
            {
                throw new ArgumentException("if degree is even, number can't be negative");
            }
            return SqrtNumber(number, degree, accurancy);
        }
        /// <summary>
        ///  find sqrt from number A
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree"></param>
        /// <param name="accurancy"></param>
        /// <returns></returns>
        static double SqrtNumber(double number, int degree, double accurancy)
        {
            double x0 = number / degree;
            double xk = x0 * (1 - ((1 - number / Math.Pow(x0, degree)) / degree));

            while (Math.Abs(xk - x0) > accurancy)
            {
                x0 = xk;
                xk = x0 * (1 - ((1 - number / Math.Pow(x0, degree)) / degree));

            }

            return xk;
        }
        /// <summary>
        ///  verification array and output error
        /// </summary>
        /// <param name="array"></param>
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
            if (array.Length > int.MaxValue)
            {
                throw new ArgumentException(nameof(array) + "length is very long ");
            }
        }

        #region Task2,D4_Task2
        /// <summary>
        /// find GCD by Euclidean
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>     
        public static int FindGcdByEuclidean(params int[] array)
        {
            ControlInputArray(array);
            return FindGcd(0, array.Length - 1);

            int FindGcd(int indexFirst, int indexSecond)
            {
                if (indexSecond - indexFirst == 1)
                {
                    return GcdByEuclideanValue(array[indexFirst], array[indexSecond]);
                }

                return GcdByEuclideanValue(FindGcd(indexFirst, (indexFirst + indexSecond) / 2), FindGcd((indexFirst + indexSecond) / 2, indexSecond));
            }
        }
        /// <summary>
        /// find GCD by Euclidean
        /// </summary>
        /// <param name="numberFirst"></param>
        /// <param name="numberSecond"></param>
        /// <returns></returns>
        private static int GcdByEuclideanValue(int numberFirst, int numberSecond)
        {
            numberFirst = Math.Abs(numberFirst);
            numberSecond = Math.Abs(numberSecond);
            if (numberFirst == 0 || numberSecond == 0)
            {
                return numberFirst + numberSecond;
            }
            while (numberFirst != numberSecond)
            {
                if (numberFirst > numberSecond)
                {
                    numberFirst = numberFirst - numberSecond;
                }
                else
                {
                    numberSecond = numberSecond - numberFirst;
                }
            }
            return numberFirst;
        }
        /// <summary>
        /// find GCD by Stein
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindGcdByStein(params int[] array)
        {
            ControlInputArray(array);
            return FindGcd(0, array.Length - 1);

            int FindGcd(int indexFirst, int indexSecond)
            {
                if (indexSecond - indexFirst == 1)
                {
                    return GcdBySteinValue(array[indexFirst], array[indexSecond]);
                }

                return GcdBySteinValue(FindGcd(indexFirst, (indexFirst + indexSecond) / 2), FindGcd((indexFirst + indexSecond) / 2, indexSecond));
            }
        }
        /// <summary>
        /// find GCD by Stein
        /// </summary>
        /// <param name="numberFirst"></param>
        /// <param name="numberSecond"></param>
        /// <returns></returns>
        private static int GcdBySteinValue(int numberFirst, int numberSecond)
        {
            numberFirst = Math.Abs(numberFirst);
            numberSecond = Math.Abs(numberSecond);
            if (numberFirst == numberSecond)
            {
                return numberFirst;
            }
            if (numberFirst == 0 || numberSecond == 0)
            {
                return numberFirst + numberSecond;
            }
            if ((~numberFirst & 1) != 0)
            {
                if ((numberSecond & 1) != 0)
                    return GcdBySteinValue(numberFirst >> 1, numberSecond);
                else
                    return GcdBySteinValue(numberFirst >> 1, numberSecond >> 1) << 1;
            }
            if ((~numberSecond & 1) != 0)
                return GcdBySteinValue(numberFirst, numberSecond >> 1);
            if (numberFirst > numberSecond)
                return GcdBySteinValue((numberFirst - numberSecond) >> 1, numberSecond);
            return GcdBySteinValue((numberSecond - numberFirst) >> 1, numberFirst);
        }
        #endregion Task2,D4_Task2

    }
}

