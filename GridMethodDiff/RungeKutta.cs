using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridMethodDiff
{
    internal class RungeKutta
    {
        public static List<double> Euler(double a, double b, Func<double, double, double> dy, double y0, double h = 0.01)
        {
            var n = (int)((b - a) / h);
            var y = Enumerable.Repeat(y0, n + 1).ToList();

            for (int i = 1; i <= n; i++)
            {
                y[i] = dy(a + h * i, y[i - 1]) * h + y[i - 1];
            }

            return y;
        }
        public static List<double> RK4(double a, double b, Func<double, double, double> g, double y0, double h = 0.01)
        {
            var n = (int)((b - a) / h);
            var y = Enumerable.Repeat(y0, n + 1).ToList();

            var xn = a + h;
            for (int i = 1; i <= n; i++)
            {
                var k1 = g(xn, y[i - 1]);
                var k2 = g(xn + h / 2, y[i - 1] + k1 * h / 2);
                var k3 = g(xn + h / 2, y[i - 1] + k2 * h / 2);
                var k4 = g(xn + h / 2, y[i - 1] + k3 * h / 2);

                y[i] = (k1 + 2 * k2 + 2 * k3 + k4) * h / 6 + y[i - 1];
                xn += h;
            }

            return y;
        }
        public static List<double> RK2(double a, double b, Func<double, double, double> g, double y0, double h = 0.01)
        {
            var n = (int)((b - a) / h);
            var y = Enumerable.Repeat(y0, n + 1).ToList();

            var xn = a + h;
            double alpha = 0.5; // midpoint method
            for (int i = 1; i <= n; i++)
            {
                var k1 = g(xn, y[i - 1]);
                var k2 = g(xn + h / 2, y[i - 1] + k1 * h / 2);

                y[i] = ((1-0.5/alpha)*k1 + 0.5/alpha * k2) * h  + y[i - 1];
                xn += h;
            }
            
            return y;
        }
    }
}
