using GridMethodDiff;
double h = 0.01;
double a = 2, b = 3, y0 = 4;
Func<double, double, double> g = (t, y) => (2 * t - 5) / t / t * y + 5;

//g = (t, y) => t * t - 2 * y;
var y = RungeKutta.Euler(a, b, g, y0, h);
int a1 = (int)(0.2 / h),
    a2 = (int)(0.4 / h),
    a3 = (int)(0.6 / h),
    a4 = (int)(0.8 / h),
    a5 = (int)(1 / h);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

y = RungeKutta.RK4(a, b, g, y0, h);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

y = RungeKutta.RK2(a, b, g, y0, h);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

Console.ReadKey();