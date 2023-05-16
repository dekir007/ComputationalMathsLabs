using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public (SolutionsCount count, List<double> results) Solve()
        {
            List<double> results = new List<double>();
            var solutionsCount = GetCountOfSolutions();
            switch (solutionsCount)
            {
                case SolutionsCount.None:
                    break;
                case SolutionsCount.Single:
                    results = SolveSingle();
                    break;
                case SolutionsCount.Infinity:
                    results = SolveInfinite();
                    break;
                default:
                    throw new Exception("There are only three cases");
            }
            return (solutionsCount, results);
        }

        private List<double> SolveSingle()
        {
            Extended = Extended.ToUpperTriangle();
            Extended = Extended.ToLowerTriangle();

            for (int i = 0; i < Extended.RowsCount; i++)
            {
                Extended[i][^1] /= Extended[i][i];
                Extended[i][i] = 1d;
            }

            return Extended.nums.Select(x => x.Last()).ToList();
        }

        private List<double> SolveInfinite()
        {
            return new List<double>();
        }
    }
}
