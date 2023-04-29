using Interpolation;

var x = new double[] { 0, 0.2, 0.4, 0.6, 0.8 };
var y = new double[] { 1, 1.179, 1.31, 1.39, 1.414 };

var x0 = Double.Parse(Console.ReadLine());
bool extra = false;
if (x0 < x[0] || x0 > x[^1])
{
    Console.WriteLine("Случай экстраполяции!");
    extra = true;
}

var interpolators = new List<CommonInterpolator>() {
    new LagrangeInterpolator(x, y),
    new LagrangeEquidistantInterpolator(y, 0.2),
    new NewtonEquidistantInterpolator(x, y),
    new NewtonInterpolator(x, y),
};

foreach (CommonInterpolator interpolator in interpolators)
{
    interpolator.CalculateValue(x0, extra);
}

Console.ReadKey();