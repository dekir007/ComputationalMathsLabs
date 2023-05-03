double a = 2, b = 3;

Func<double, double, double> d = (t, y) => (2 * t - 5) / t / t * y + 5;

double h = 0.01;

var n = (int)((b - a) / h);
var y = Enumerable.Repeat(4d, n+1).ToList();

for (int i = 1; i <= n; i++)
{
    y[i] = d(a + h * i, y[i - 1]) * h + y[i - 1];
}
Console.WriteLine($"{y[20]} {y[40]} {y[60]} {y[80]} {y[100]}");
Console.ReadKey();