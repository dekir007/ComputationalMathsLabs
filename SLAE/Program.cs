//slae
//	testNone
//	testSingle
//	testInfinite1
//	testInfinite2
//	variant11

//seidel
//	variant11


#define slae
#define variant11
using SLAE;


#if slae

#if testNone

//no solution
var m = new Matrix(new List<List<double>>
        {
            new List<double>{ 4, -3, 2, -1 },
            new List<double>{ 3, -2, 1, -3 },
            new List<double>{ 5, -3, 1, -8 }
        });
var fv = new List<double>() { 8, 7, 1 };
#endif
#if testSingle
		//SINGLE SOLUTION
		var m = new Matrix(new List<List<double>>
		{
			 new List<double>{ 1, 2, 3 },
			 new List<double>{ 1, -1, 1 },
			 new List<double>{ 1, 3, -1 },
		});
		var fv = new List<double>()  { 2, 0, -2 };
		
#endif
#if testInfinite1
	//INFINITE SOLUTIONS
	var m = new Matrix(new List<List<double>>
		{
			 new List<double>{ 1, 3, -2, -2 },
			 new List<double>{ -1, -2, 1, 2 },
			 new List<double>{ -2, -1, 3, 1 },
			 new List<double>{ -3, -2, 3, 3 }
		});
		var fv = new List<double>() { -3, 2, -2, -1 };
#endif
#if testInfinite2
	//INFINITE SOLUTIONS
	var m = new Matrix(new List<List<double>>
		{
			 new List<double> { 1, 3, -2, -2 }
		});
		var fv = new List<double>()  { -3 };
#endif
#if variant11
//VARIANT 11
var m = new Matrix(new List<List<double>>
        {
            new List<double>{ 1, -2, 16, 0 },
            new List<double>{ 0, 12, 1, -1 },
            new List<double>{ 0, 2, 0, 16 },
            new List<double>{ 10, -1, 0, 1 },
        });
var fv = new List<double> { 0, -28, 29, 31};

#endif

Console.WriteLine(new Gauss(m, fv).Solve().Result);
Console.WriteLine(new Seidel(m, fv).Solve(0.001).Result);

#endif
#if seidel

#if variant11
//VARIANT 11
var m = new Matrix(new List<List<double>>
        {
             new List<double>{ 5, -1, 3 },
             new List<double>{ 1, -4, 2 },
             new List<double>{ 2, -1, 5 },
        });
var fv = new List<double>() { 5, 20, 10 };
#endif

Console.WriteLine(new Seidel(m, fv).Solve(0.01).Result);

#endif

