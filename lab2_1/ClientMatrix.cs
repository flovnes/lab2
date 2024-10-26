public class Program {
    public static void Main() {
        Matrix a = new Matrix(new double[,] {
            {5, 2, 3, 1},
            {1, 7, 2, 4},
            {3, 1, 8, 2},
            {2, 4, 1, 6}
        });

        Matrix b = new Matrix("5 2\n 3 1\n6 4\n 2 5");

        Console.WriteLine("Matrix A:");
        Console.WriteLine(a);
        Console.WriteLine("Matrix B:");
        Console.WriteLine(b);

        Matrix product = a * b;
        Console.WriteLine("Matrix A * B:");
        Console.WriteLine(product);

        double det = a.CalcDeterminant();
        Console.WriteLine($"Determinant of Matrix A: {Math.Round(det)}");

        Matrix transposed = a.GetTransponedCopy();
        Console.WriteLine("Transposed Matrix A:");
        Console.WriteLine(transposed);

        det = transposed.CalcDeterminant();
        Console.WriteLine($"Determinant of Transposed Matrix A: {Math.Round(det)}");


        Random rnd = new();
        string[] rows = new string[10];
        for (int i = 0; i < 10; i++)
            rows[i] = string.Join("\t", Enumerable.Range(0, 10).Select(_ => rnd.Next(-3, 16)));
        Matrix c = new(rows);
        
        Console.WriteLine("Matrix C:");
        Console.WriteLine(c);
        for (int i = 0; i < 1000000; i++)
            c.CalcDeterminant();
        Console.WriteLine($"Determinant of Matrix C: {Math.Round(c.CalcDeterminant())}");

        Console.WriteLine($"C(2,2) is {c[1, 1]}");
        c[1, 1] = -1;
        Console.WriteLine("Changed C(2,2) to -1,\nMatrix C:");
        Console.WriteLine(c);
        Console.WriteLine($"Determinant of Matrix C: {Math.Round(c.CalcDeterminant())}");


    }
}
