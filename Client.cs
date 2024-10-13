public class Program {
    public static void Main() {
        Matrix a = new Matrix(new double[,] {{5, 2}, {1, 7}});
        Matrix b = new Matrix("5\n 6");

        Console.WriteLine("Matrix A:");
        Console.WriteLine(a);
        Console.WriteLine("Matrix B:");
        Console.WriteLine(b);

        Matrix product = a * b;
        Console.WriteLine("Matrix A * B:");
        Console.WriteLine(product);

        Matrix transposed = a.GetTransponedCopy();
        Console.WriteLine("Transposed Matrix A:");
        Console.WriteLine(transposed);

        double det = a.CalcDeterminant();
        Console.WriteLine($"Determinant of Matrix A: {det}");

        Matrix c = new Matrix(["1 2 3", "4 5 6", "7 8 9"]);
        Console.WriteLine("Matrix C:");
        Console.WriteLine(c);

        Console.WriteLine($"C(1,1) is {c[1, 1]}");
        c[1, 1] = -1;
        Console.WriteLine("Changed C(1,1) to -1,\nMatrix C:");
        Console.WriteLine(c);
        Console.WriteLine($"Determinant of Matrix C: {c.CalcDeterminant()}");
    }
}
