using SLAE;

var m1 = new Matrix(new List<List<double>>
        {
            new List<double> { 5, -1, 3 },
            new List<double> { 1, -4, 2 },
            new List<double> { 2, -1, 5 },
        });

var m3 = new Matrix(new List<List<double>>
        {
            new List<double> { 1, 2, 3 },
            new List<double> { 1, -1, 1 },
            new List<double> { 1, 3, -1 },
        });
var m2 = new Matrix(new List<List<double>>
        {
            new List<double> { 1, 3, -2, -2 },
            new List<double> { -1, -2, 1, 2 },
            new List<double> { -2, -1, 3, 1 },
            new List<double> { -3, -2, 3, 3 },
        });
var m4 = new Matrix(new List<List<double>>
        {
            new List<double> { 2, 3, -1, 1 },
            new List<double> { 8, 12, -9, 8 },
            new List<double> { 4, 6, 3, -2 },
            new List<double> { 2, 3, 9, -7 },
        });
//Console.WriteLine(m3.Rank);
var freeVector3 = new List<double>() { 1, 3, 3, 3 };
var freeVector2 = new List<double>() { 2, 0, -2 };
var freeVector = new List<double>() { -3, 2, -2, -1 };
//Console.WriteLine(new Gauss(m3, freeVector2).Solve().Result);
Console.WriteLine(new Gauss(m2, freeVector).Solve().Result);
