using System.Collections;
using System.Text;

namespace SLAE
{
    internal class Matrix : IEnumerable<List<double>>
    {
        public List<List<double>> nums;

        public Matrix(List<List<double>> _nums) 
        {
            nums = _nums;
        }

        public int Rank
        {
            get
            {
                var _data = ToUpperTriangle();

                int result = 0;
                foreach (var row in _data.nums)
                {
                    result += RowIsNotAllZero(row) ? 1 : 0;
                }

                return result;
            }
        }

        private static bool RowIsNotAllZero(List<double> row)
        {
            bool f = false;
            foreach (var elem in row)
            {
                if (elem != 0d)
                {
                    f = true;
                }
            }

            return f;
        }

        public int RowsCount => nums.Count();
        public int ColumnsCount => nums[0].Count();

        public static Matrix ToUpperTriangle(List<List<double>> matrix)
        {
            var _nums = matrix.Select(x => x.ToList()).ToList();

            for (int i = 1; i < _nums.Count(); i++)
            {
                for (int k = 0; k < i; k++)
                {
                    if (_nums[k][k] == 0d)
                    {
                        //меняем строчки
                        for (int j = k + 1; j < _nums.Count(); j++)
                        {
                            if (_nums[j][k] != 0d)
                            {
                                //swap j and k rows
                                var temp = _nums[k]; // for k
                                _nums[k] = _nums[j];
                                _nums[j] = temp;
                                break;
                            }
                        }

                    }
                    double multiplier = _nums[i][k] / _nums[k][k];

                    for (int j = 0; j < _nums[0].Count; j++)
                    {
                        _nums[i][j] -= _nums[k][j] * multiplier;
                    }
                }
                //Console.WriteLine(new Matrix(_nums));
            }
            return new Matrix(_nums);
        }
        public Matrix ToUpperTriangle()
        {
            return ToUpperTriangle(nums);
        }

        public static Matrix ToLowerTriangle(List<List<double>> matrix)
        {
            var _nums = matrix.Select(x => x.ToList()).ToList();

            for (int i = _nums.Count - 2; i >= 0; --i)
            {
                for (int k = _nums.Count - 1; k > i; --k)
                {
                    if (_nums[k][k] != 0d)
                    {
                        double multiplier = _nums[i][k] / _nums[k][k];
                        for (int j = 0; j < _nums[0].Count; j++)
                        {
                            _nums[i][j] -= _nums[k][j] * multiplier;
                        }
                    }
                    //Console.WriteLine(new Matrix(_nums));
                }
            }
            return new Matrix(_nums);
        }
        public Matrix ToLowerTriangle()
        {
            return ToLowerTriangle(nums);
        }

        public List<double> GetMainDiagonal()
        {
            var res = new List<double>();
            for (int i = 0; i < nums.Count(); ++i)
            {
                res.Add(nums[i][i]);
            }
            return res;
        }

        private List<List<double>> AddColumnToNums(List<double> column)
        {
            if (column.Count() != nums.Count())
            {
                throw new ArgumentException("The size of the input column must match the size of the matrix columns.");
            }
            var _nums = nums.Select(item => item.ToList()).ToList();
            for (int i = 0; i < _nums.Count(); ++i)
            {
                _nums[i].Add(column[i]);
            }
            return _nums;
        }

        public Matrix GetExtended(List<double> freeVector)
        {
            return new Matrix(AddColumnToNums(freeVector));
        }

        public List<double> this[int index]
        {
            get => nums[index];
            set => nums[index] = value;
        }
        public double this[int row, int column]
        {
            get => nums[row][column];
            set => nums[row][column] = value;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < nums.Count; i++)
            {
                str.AppendLine(string.Join("\t", nums[i]));
            }
            return str.ToString();
        }

        public IEnumerator<List<double>> GetEnumerator() => nums.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => nums.GetEnumerator(); 
    }
}
