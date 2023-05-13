using GridMethodDiff;
var y = RungeKutta.Euler(2, 3, (t, y) => (2 * t - 5) / t / t * y + 5, 4);
double h = 0.01;
int a1 = (int)(0.2 / h),
    a2 = (int)(0.4 / h),
    a3 = (int)(0.6 / h),
    a4 = (int)(0.8 / h),
    a5 = (int)(1 / h);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

y = RungeKutta.RK4(2, 3, (t, y) => (2 * t - 5) / t / t * y + 5, 4);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

y = RungeKutta.RK2(2, 3, (t, y) => (2 * t - 5) / t / t * y + 5, 4);

Console.WriteLine($"{y[a1]} {y[a2]} {y[a3]} {y[a4]} {y[a5]}");

Console.ReadKey();