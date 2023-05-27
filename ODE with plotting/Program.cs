using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODE_with_plotting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double h = 0.2;
            double a = 2, b = 3, y0 = 4;
            Func<double, double, double> g = (t, _y) => (2 * t - 5) / t / t * _y + 5;
            List<double> y;
            int a1 = (int)(0.2 / h),
                a2 = (int)(0.4 / h),
                a3 = (int)(0.6 / h),
                a4 = (int)(0.8 / h),
                a5 = (int)(1 / h);
            //g = (t, y) => t * t - 2 * y;

            y = RungeKutta.Euler(a, b, g, y0, h);
            Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

            //y = RungeKutta.RK4(a, b, g, y0, h);
            //Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

            //y = RungeKutta.RK2(a, b, g, y0, h);
            //Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

            Plot.CreatePlotPicture(y, a, b);

            Process.Start("chart.png");

            Console.ReadKey();
        }
    }
}
