using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    internal class NewtonInterpolator : CommonInterpolator
    {
        private Dictionary<string, double> difs = new Dictionary<string, double>();

        public NewtonInterpolator(double[] x, double[] y) : base(x, y)
        {
        }

        public override double CalculateValue(double x0, bool extra = false)
        {
            double res = y[0];


            double a = 1; // ну а как тебя назвать-то?
            string indexes = "0"; // в полиноме нужно последовательно вычислять [x_0,x_1], [x_0,x_1,x_2], [x_0,x_1,x_2, x_3]...
            double s = 0;
            for (int i = 0; i < count - 1; i++)
            {
                a *= (x0 - x[i]);
                indexes += (i + 1);
                s = a * dif(indexes);
                res += s;
            }

            Console.WriteLine($"Ньютон для  неравноотстоящих: {res}" + (extra ? "" : " ; погрешность " + s));
            return res;
        }

        public double dif(string xs)
        {
            // считаем разделенные разности рекурсивно, запоминая в словаре уже вычисленные значения
            if (difs.ContainsKey(xs))
            {
                return difs[xs];
            }
            else
            {
                var imax = (int)char.GetNumericValue(xs[xs.Length - 1]);
                var i0 = (int)char.GetNumericValue(xs[0]);
                if (xs.Length == 2)
                {
                    var i1 = (int)char.GetNumericValue(xs[1]);
                    return (y[i1] - y[i0]) / (x[i1] - x[i0]);
                }
                var d1 = xs.Substring(1);
                var d2 = xs.Substring(0, xs.Length - 1);
                difs[xs] = (dif(d1) - dif(d2)) / (x[imax] - x[i0]);
                return difs[xs];
            }
        }
    }
}
