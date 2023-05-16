using SLAE;

var m1 = new Matrix(new List<List<double>>
        {
            new List<double> { 5, -1, 3 },
            new List<double> { 1, -4, 2 },
            new List<double> { 2, -1, 5 },
        });
var m2 = new Matrix(new List<List<double>>
        {
            new List<double> { 1, -1, 2 },
            new List<double> { 2, -2, 4 },
            new List<double> { -1, 1, -2 },
        });
var m3 = new Matrix(new List<List<double>>
        {
            new List<double> { 1, 2, 3 },
            new List<double> { 1, -1, 1 },
            new List<double> { 1, 3, -1 },
        });
//Console.WriteLine(m3.Rank);
var freeVector = new List<double>() { 2, 0, -2 };
Console.WriteLine(string.Join(" " , new Gauss(m3, freeVector).Solve().results));
