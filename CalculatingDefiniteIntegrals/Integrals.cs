namespace CalculatingDefiniteIntegrals
{
    internal static class Integrals
    {
        public static double Rectangle(Func<double, double> func, double a, double b, int n = 8)
        {
            Func<double, double> integral = (double n) =>
            {
                double sum = 0d;
                
                var h = (b - a) / n;
                
                for (int i = 0; i < n; i++)
                {
                    sum += func(a + (i + 0.5) * h );
                }
                return sum * h;
            };
            return integral(n);
        }

        public static double Trapezoid(Func<double, double> func, double a, double b, int n = 9)
        {
            Func<double, double> integral = (double n) =>
            {
                double sum = 0d;

                var h = (b - a) / n;

                for (int i = 0; i < n-1; i++)
                {
                    sum += func(a + (i + 1) * h);
                }
                return (sum + 0.5 * (func(a) + func(b))) * h;
            };
            return integral(n);
        }

        public static double Simpson(Func<double, double> func, double a, double b, int n = 4)
        {
            Func<double, double> integral = (double n) =>
            {
                double sum = func(a) + func(b);

                var h = (b - a) / n;

                for (int i = 0; i < n-1; i++)
                {
                    sum += func(a + h * (i + 1)) * (i.IsEven() ? 4 : 2);
                }

                return sum * h / 3;
            };

            return integral(n);
        }

        public static double Carlo(Func<double, double> func, double a, double b, int n = 750_000)
        {
            var sum = 0d;
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                sum += func((b - a) * rnd.NextDouble() + a);
            }
            return (sum / n * (b - a));
        }

        private static bool IsEven(this int i) => (i & 1) == 0;
    }
}
