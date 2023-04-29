using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    internal class NewtonEquidistantInterpolator : CommonInterpolator
    {
        public NewtonEquidistantInterpolator(double[] x, double[] y) : base(x, y)
        {
        }

        public override double CalculateValue(double x0, bool extra = false)
        {
            bool left = x0 <= x[x.Length - 1] / 2;

            double[] difs = new double[y.Length];
            int j;
            y.CopyTo(difs, 0);
            // считаем разности delta y_0, ^2 y_0, ... для первой формы
            if (left)
            {
                // считаем верхушку пирамидки
                for (j = 0; j < difs.Length - 1; j++)
                {
                    for (int i = difs.Length - 1; i > j; i--)
                    {
                        difs[i] = (difs[i] - difs[i - 1]);
                    }
                }
            }
            else
            {
                // считаем низ пирамидки
                for (j = 0; j < difs.Length - 1; j++)
                {
                    for (int i = 0; i < difs.Length - j - 1; i++)
                    {
                        difs[i] = (difs[i + 1] - difs[i]);
                    }
                }
            }

            double h = 0.2;
            double q = x0 / h;
            double res;
            double a = 1; // ну а как тебя назвать-то?
            if (left)
            {
                res = difs[0];
                for (int i = 0; i < count - 1; i++)
                {
                    a *= (q - i) / (i + 1);
                    res += a * difs[i + 1];
                }
            }
            else
            {
                q = (x0 - x[count - 1]) / h;
                res = difs[count - 1];
                for (int i = 0; i < count-1; i++)
                {
                    a *= (q + i) / (i + 1);
                    res += a * difs[count - i - 2];
                }
            }

            Console.WriteLine($"Ньютон для    равноотстоящих: {res}" + (extra ? "" : " ; погрешность " + Math.Abs(a / (count + 1) * difs[left ? count - 1 : 0])));

            return res;
        }
    }
}
