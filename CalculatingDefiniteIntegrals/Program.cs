using CalculatingDefiniteIntegrals;

Func<double, double> f = x => 1 / Math.Sqrt(x*x*x + 1);

Console.WriteLine(Integrals.Rectangle(f, 0, 1));
Console.WriteLine(Integrals.Trapezoid(f, 0, 1));
Console.WriteLine(Integrals.Simpson(f, 0, 1));

Console.ReadKey();