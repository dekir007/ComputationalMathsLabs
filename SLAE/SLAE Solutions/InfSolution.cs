namespace SLAE.SLAE_Solutions
{
    internal class InfSolution
    {
        public List<(double coeff, int index)> solution;
        public double FreeValue;

        public InfSolution(double freeValue)
        {
            solution = new List<(double coeff, int index)>();
            FreeValue = freeValue;
        }

        public InfSolution(List<(double coeff, int index)> _solution, double freeValue)
        {
            solution = _solution;
            FreeValue = freeValue;
        }
        public string Result
        {
            get
            { // пусть отсортированы по индексам
                string str = "";
                bool first = true;
                foreach (var component in solution)
                {
                    // знаки для первого слагаемого не нужны, но для остальных надо ставить
                    // логично, что надо будет выводить по модулю, если знаки ставим сами
                    double roundedCoeff = Math.Round(component.coeff, 6);
                    str += $"{(!first ? (component.coeff > 0 ? "+ " : (component.coeff == 0 ? "" : "- ")) : "")}{( !first ? Math.Abs(roundedCoeff) : roundedCoeff)}*x{component.index + 1} ";
                    first = false;
                }
                str += $"{(FreeValue > 0 ? "+" : (FreeValue == 0 ? "" : "-"))} {Math.Abs(FreeValue)}";
                return str;
            }
        }
        public void Add(double coeff, int index)
        {
            solution.Add((coeff, index));
        }
    }
}
