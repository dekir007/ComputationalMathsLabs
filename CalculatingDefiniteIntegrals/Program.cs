using CalculatingDefiniteIntegrals;

double a = 0, b = 1;
Func<double, double> f = x => 1 / Math.Sqrt(x*x*x + 1);

Console.WriteLine($"Метод прямоугольников : {Integrals.Rectangle(f, a, b)}");
Console.WriteLine($"Метод трапеций :        {Integrals.Trapezoid(f, a, b)}");
Console.WriteLine($"Метод Симпсона :        {Integrals.Simpson(f, a, b)}");

Console.ReadKey();