using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAE.SLAE_Solutions
{
    internal class NoneSolution : ISolution
    {
        public SolutionsCount SolutionsCount => SolutionsCount.None;

        public string Result => "Нет решений"; // no solution
    }
}
