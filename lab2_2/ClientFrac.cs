class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("MyFrac Examples:");

        MyFrac f1 = new MyFrac(1, 2);
        MyFrac f2 = new MyFrac(3, 4);
        MyFrac f3 = new MyFrac(-5, 6);

        Console.WriteLine($"f1: {f1}");
        Console.WriteLine($"f2: {f2}");
        Console.WriteLine($"f3: {f3}");

        Console.WriteLine($"f1 with integer part: {f1.ToStringWithIntPart()}");
        Console.WriteLine($"f2 with integer part: {f2.ToStringWithIntPart()}");
        Console.WriteLine($"f3 with integer part: {f3.ToStringWithIntPart()}");

        Console.WriteLine($"f1 as double: {f1.ToDouble()}");

        MyFrac sum = f1 + f2;
        MyFrac difference = f1 - f2;
        MyFrac product = f1 * f2;
        MyFrac quotient = f1 / f2;

        Console.WriteLine($"f1 + f2 = {sum}");
        Console.WriteLine($"f1 - f2 = {difference}");
        Console.WriteLine($"f1 * f2 = {product}");
        Console.WriteLine($"f1 / f2 = {quotient}");

        MyFrac f4 = new MyFrac(1234, 5678);
        Console.WriteLine($"f4: {f4}");
        Console.WriteLine($"f4 with integer part: {f4.ToStringWithIntPart()}");

        MyFrac f5 = new MyFrac(-15, 7);
        MyFrac f6 = new MyFrac(8, -3);
        Console.WriteLine($"f5: {f5}");
        Console.WriteLine($"f6: {f6}");
        Console.WriteLine($"f5 * f6 = {f5 * f6}");

        int n = 10;
        MyFrac f7 = new MyFrac(0, 1);
        for (int i = 1; i <= n; i++)
            f7 += new MyFrac(1, i * (i + 1));
        Console.WriteLine($"f7 = {f7}");

        MyFrac f8 = new MyFrac(1, 1);
        for (int i = 2; i <= n; i++)
            f8 *= new MyFrac(i * i - 1, i * i);
        Console.WriteLine($"f8 = {f8}");
    }
}