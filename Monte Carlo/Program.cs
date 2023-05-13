using Monte_Carlo;

Console.WriteLine(MonteCarlo.Integral(x => 1 / Math.Sqrt(x * x * x + 1), 0, 1));
Console.WriteLine(MonteCarlo.IntegralClassic());
Console.WriteLine(MonteCarlo.PI());

Console.ReadKey();