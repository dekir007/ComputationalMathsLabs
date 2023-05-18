using SLAE.SLAE_Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAE
{
    internal class Seidel
    {
        private Matrix SystemMatrix;
        private List<double> FreeVector;
        private List<double> Approximation;

        public Seidel(Matrix systemMatrix, List<double> freeVector)
        {
            SystemMatrix = systemMatrix;
            FreeVector = freeVector;
        }

        private double SumRowWithoutCur(int indexOfRow) // sum of a_ij * x_j and j!=i
        {
            return SystemMatrix[indexOfRow]
                .Zip(Approximation)
                .Select(elem => elem.First * elem.Second)
                .Where((elemValue, elemIndex) => elemIndex != indexOfRow)
                .Aggregate(0d, (accumulated, current) => accumulated + current);
        }

        public SingleSolution Solve(double eps)
        {
            double curEps = 0d;
            Approximation = FreeVector.Zip(SystemMatrix.GetMainDiagonal()).Select(elem => elem.First / elem.Second).ToList();
            do
            {
                var oldApproximation = new List<double>(Approximation); // copy

                for (int i = 0; i < Approximation.Count; i++)
                {
                    Approximation[i] = (FreeVector[i] - SumRowWithoutCur(i)) / SystemMatrix[i][i];
                }
                // ( x^k-x^(k-1) ) / x^k
                curEps = oldApproximation.Zip(Approximation).Select(x => (x.Second - x.First) / x.Second).Max();
            } 
            while (curEps > eps);
            
            return new SingleSolution(Approximation);
        }
    }
}
