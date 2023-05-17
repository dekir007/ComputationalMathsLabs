using SLAE.SLAE_Solutions;

namespace SLAE
{
    internal class Gauss
    {
        private Matrix SystemMatrix;
        private Matrix Extended;

        public Gauss(Matrix system, List<double> free)
        {
            SystemMatrix = system;
            Extended = system.GetExtended(free);
        }

        public SolutionsCount GetCountOfSolutions()
        {
            if (!IsSolvable())
            {
                return SolutionsCount.None;
            }

            if (SystemMatrix.Rank == SystemMatrix.ColumnsCount)
            {
                return SolutionsCount.Single;
            }

            return SolutionsCount.Infinity;
        }

        public bool IsSolvable()
        {
            return SystemMatrix.Rank == Extended.Rank;
        }

        public ISolution Solve()
        {
            var solutionsCount = GetCountOfSolutions();
            switch (solutionsCount)
            {
                case SolutionsCount.None:
                    return new NoneSolution();

                case SolutionsCount.Single:
                    return SolveSingle();

                case SolutionsCount.Infinity:
                    return SolveInfinite();

                default:
                    throw new Exception("There are only three cases");
            }
        }

        private ISolution SolveSingle()
        {
            Extended = Extended.ToUpperTriangle();
            Extended = Extended.ToLowerTriangle();

            for (int i = 0; i < Extended.RowsCount; i++)
            {
                Extended[i][^1] /= Extended[i][i];
                Extended[i][i] = 1d;
            }

            return new SingleSolution(Extended.nums.Select(x => x.Last()).ToList());
        }

        private ISolution SolveInfinite()
        {
            Extended = Extended.ToUpperTriangle();
            Extended = Extended.ToLowerTriangle();

            List<double> mainDiagonal = Extended.GetMainDiagonal();
            var extras = new List<int>(); // "лишние" переменные, через которые будем выражать беск. кол-во решений
            for (int i = 0; i < mainDiagonal.Count; i++)
            {
                double coeff = mainDiagonal[i];
                if (coeff == 0 || coeff == double.NaN)
                    extras.Add(i);
            }

            for (int i = 0; i < Extended.RowsCount; i++)
            {
                var divisor = Extended[i][i];
                for (int j = 0; j < Extended.ColumnsCount; j++)
                {
                    Extended[i][j] /= divisor;
                } // делим всю строку на коэфф при элементе главной диагонали
                Extended[i, i] = 1d;
            }
            
            var infSolutions = new InfiniteSolutions();
            for (int i = 0; i < Extended.RowsCount; ++i)
            {
                if (extras.Contains(i))
                {
                    continue;
                }

                infSolutions.AddSolution(i, Extended[i][^1]);

                foreach (var extra in extras)
                {
                    if (Math.Abs(Extended[i][extra]) < 1e-8)
                    {
                        continue;
                    }
                    infSolutions.AddComponentToSolution(i, Extended[i][extra] * -1d, extra);
                }
            }

            return infSolutions;
        }
    }
}
