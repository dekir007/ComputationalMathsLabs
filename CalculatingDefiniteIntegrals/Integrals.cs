using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingDefiniteIntegrals
{
    internal static class Integrals
    {
        public static double Rectangle(Func<double, double> func, double left, double right, double h = 0.0001)
        {
            if (right - left < h)
            {
                return 0;
            }

            double sum = 0d;

            for (int i = 0; i < (int)((right - left) / h); i++)
            {
                sum += func(left + i * h + h / 2);
            }

            return sum * h;
        }

        public static double Trapezoid(Func<double, double> func, double left, double right, double h = 0.0001)
        {
            if (right - left < h)
            {
                return 0;
            }

            double sum = 0d;

            for (int i = 1; i < (int)((right - left) / h) - 1; i++)
            {
                sum += func(left + i * h);
            }

            return (sum + 0.5 * (func(left) + func(right))) * h;
        }

        public static double Simpson(Func<double, double> func, double left, double right, double h = 0.0001)
        {
            if (right - left < h)
            {
                return 0;
            }

            double sum = 0d;

            for (int i = 0; i < (int)((right - left) / h); i++)
            {
                sum += func(left + h * i) * (i.IsOdd() ? 2 : 4);
            }

            return sum * h / 3;
        }

        private static bool IsOdd(this int i) => (i & 1) == 0;
    }
}
