namespace Monte_Carlo
{
    internal static class MonteCarlo
    {
        public static double Integral(Func<double, double> func, double a, double b, int n = 750_000)
        {
            var sum = 0d;
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                sum += func((b - a) * rnd.NextDouble() + a);
            }
            return (sum / n * (b - a));
        }

        public static double PI(int n = 750_000)
        {
            double circle = 0;
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();
                if (x*x+y*y <=1)
                {
                    circle++;
                }
            }
            return 4 * circle / n;
        }
    }
}
