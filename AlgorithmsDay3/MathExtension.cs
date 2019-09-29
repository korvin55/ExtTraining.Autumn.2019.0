using System;

namespace AlgorithmsDay3Task1
{
    public class MathExtension
    {
        public static double FindNthRoot(double a, int n, double accurancy)
        {
            if (accurancy <= 0)
            {
                throw new ArgumentException(nameof(accurancy) + "is negative");
            }
            if (n <= 0)
            {
                throw new ArgumentException(nameof(n) + "is negative");
            }
            if (a <= 0 && n % 2 == 0)
            {
                throw new ArgumentException("if degree is even, number can't be negative");
            }
            return SqrtA(a, n, accurancy);
        }

        static double SqrtA(double a, int n, double accurancy)
        {
            double x0 = a / n;
            double xk = x0 * (1 - ((1 - a / Math.Pow(x0, n)) / n));

            while (Math.Abs(xk - x0) > accurancy)
            {
                x0 = xk;
                xk = x0 * (1 - ((1 - a / Math.Pow(x0, n)) / n));

            }

            return xk;
        }

    }
}

