using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    internal class LagrangeEquidistantInterpolator : CommonInterpolator
    {
        protected double h;
        protected double x_0;
        protected List<int> combis;
        public LagrangeEquidistantInterpolator(double[] y, double _h, double _x_0 = 0) : base(y, y)
        {
            h = _h;
            x_0 = _x_0; // минимальный х
            //считаем комбинации C из n по 0, 1, 2...
            combis = Enumerable.Range(0, count).Select(z => Combination(count-1, z)).ToList();
        }

        public override double CalculateValue(double x0, bool extra = false)
        {
            double q = (x0 - x_0) / h;

            double nfact = 1; // factorial
            for (int i = 2; i < count; i++)
            {
                nfact *= i;
            }

            double qs = 1;
            for (int i = 0; i < count; i++)
            {
                qs *= (q - i);
                if (qs == 0) // x0 - известный узел
                {
                    Console.WriteLine($"Лагранж для   равностоящих: {y[i]}" + " ; погрешность " + 0);
                    return y[i];
                }
            }

            double sum = 0;

            double maxDerivative = double.MinValue;
            for (int i = 0; i < count; i++)
            {
                var tmp = combis[i] * ((count - i - 1) % 2 == 0 ? 1 : -1) / (q - i);
                sum += (y[i] * tmp);
                maxDerivative = Math.Max(maxDerivative, tmp);
            }

            double p = 1; // П_(n+1)
            for (int i = 0; i < count; i++)
            {
                p *= (x0 - (x_0 + i*h));
            }
            double remainder = (maxDerivative * qs / nfact) * p / (nfact * (count + 1)); // погрешность

            double res = qs * sum / nfact;
            Console.WriteLine($"Лагранж для   равноотстоящих: {res}" + (extra ? "" : " ; погрешность " + Math.Abs(remainder)));
            return res ;
        }

        //chatgpt
        private int Combination(int n, int k)
        {
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;

            int[,] C = new int[n + 1, k + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Math.Min(i, k); j++)
                {
                    if (j == 0 || j == i)
                        C[i, j] = 1;
                    else
                        C[i, j] = C[i - 1, j - 1] + C[i - 1, j];
                }
            }

            return C[n, k];
        }
    }
}
