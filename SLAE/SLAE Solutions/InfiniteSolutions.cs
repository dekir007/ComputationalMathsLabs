namespace SLAE.SLAE_Solutions
{
    internal class InfiniteSolutions : ISolution
    {
        public string Result
        {
            get
            { // пусть отсортированы по индексам
                string str = "";

                foreach (var solution in infSolutions)
                {
                    str += $"x{solution.Key + 1} = {solution.Value.Result}\n";
                }
                //for (int i = 0; i < infSolutions.Count; i++)
                //{
                //    InfSolution solution = infSolutions[i];
                //}
                return str;
            }
        }

        public SolutionsCount SolutionsCount => SolutionsCount.Infinity;

        private Dictionary<int, InfSolution> infSolutions;

        public InfiniteSolutions()
        {
            infSolutions = new Dictionary<int, InfSolution>();
        }

        public void AddSolution(int index, double freeValue)
        {
            infSolutions.Add(index, new InfSolution(freeValue));
        }

        public void AddComponentToSolution(int indexOfSolution, double coeff, int index)
        {
            infSolutions[indexOfSolution].Add(coeff, index);
        }

        public override string ToString()
        {
            return string.Join("\n", infSolutions);
        }
    }
}
