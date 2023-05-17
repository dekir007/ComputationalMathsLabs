namespace SLAE.SLAE_Solutions
{
    internal class SingleSolution : ISolution
    {
        public string Result
        {
            get
            {
                string str = "";
                for (int i = 0; i < solutions.Count; i++)
                {
                    str += $"x{i+1} = {Math.Round(solutions[i], 10)}; ";
                }
                return str;
            }
        }

        public SolutionsCount SolutionsCount => SolutionsCount.Single;

        private List<double> solutions;

        public SingleSolution(List<double> _solutions)
        {
            solutions = _solutions;
        }
    }
}
