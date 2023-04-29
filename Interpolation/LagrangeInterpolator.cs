using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    internal class LagrangeInterpolator : CommonInterpolator
    {
        public LagrangeInterpolator(double[] x, double[] y) : base(x, y)
        {
        }

        public override double CalculateValue(double x0, bool extra = false)
        {
            double res = 0;
            var k = (int i) => {
                double result = 1;
                for (int j = 0; j < count; j++)
                {
                    result *= i != j ? (x[i] - x[j]) : (x0 - x[i]);
                }
                return result;
            }; // k(i)

            double p = 1; // П_(n+1)
            for (int i = 0; i < count; i++)
            {
                p *= (x0 - x[i]);
            }

            double maxDerivative = double.MinValue;
            for (int i = 0; i < count; i++)
            {
                var ki = k(i);

                if (ki == 0)
                {
                    Console.WriteLine($"Лагранж для неравностоящих: {y[i]}" + " ; погрешность " + 0);
                    return y[i];
                }
                maxDerivative = Math.Max(maxDerivative, Math.Abs(p / ki));
                res += y[i] / ki;
            }

            double nfact = 1; // fact
            for (int i = 2; i <= count+1; i++)
            {
                nfact *= i;
            }
            double remainder = maxDerivative * p / nfact; // погрешность
            res *= p;
            Console.WriteLine($"Лагранж для неравноотстоящих: {res}" + (extra ? "" : " ; погрешность " + Math.Abs(remainder)));
            return res;
        }
    }
}
