public struct FracStruct {
    public long nominator, denominator;

    public FracStruct(long nom, long denom) {
        long g = FracStruct.gcd(nom, denom);

        nominator = nom / g;
        denominator = denom / g;
        
        if (denominator < 0) {
            nominator = -nominator;
            denominator = -denominator;
        }
    }

    private static long gcd(long nom, long denom) {
        long gcd = 0;
        long a = Math.Abs(nom);
        long b = Math.Abs(denom);

        while (b != 0) {
            gcd = b;
            b = a % b;  
            a = gcd;
        }

        return gcd;
    }

    public override readonly string ToString() {
        return $"{nominator}/{denominator}";
    }
    
    public static string ToStringWithIntPart(FracStruct f) {
        string sign = (f.nominator * f.denominator < 0) ? "-" : "";
        long before_p = f.nominator / f.denominator;
        long after_p = f.nominator % f.denominator;

        if (before_p == 0)
            return $"{sign}{after_p}/{f.denominator}";
        else if (after_p == 0)
            return $"{sign}{before_p}";
        else
            return $"{sign}{before_p} + {Math.Abs(after_p)}/{f.denominator}";
    }

    public static double DoubleValue(FracStruct f) {
        return (double)f.nominator / f.denominator;
    }

    public static FracStruct Plus(FracStruct f1, FracStruct f2) {
        long nom = f1.nominator * f2.denominator + f2.nominator * f1.denominator;
        long denom = f1.denominator * f2.denominator;
        return new FracStruct(nom, denom);
    }

    public static FracStruct Minus(FracStruct f1, FracStruct f2) {
        long nom = f1.nominator * f2.denominator - f2.nominator * f1.denominator;
        long denom = f1.denominator * f2.denominator;
        return new FracStruct(nom, denom);
    }

    public static FracStruct Multiply(FracStruct f1, FracStruct f2) {
        long nom = f1.nominator * f2.nominator;
        long denom = f1.denominator * f2.denominator;
        return new FracStruct(nom, denom);
    }

    public static FracStruct Divide(FracStruct f1, FracStruct f2) {
        long nom = f1.nominator * f2.denominator;
        long denom = f1.denominator * f2.nominator;
        return new FracStruct(nom, denom);
    }

    public static FracStruct CalcExpr1(int n) {
        FracStruct f3 = new(0, 1);
        for (int i = 1; i <= n; i++)
            f3 = Plus(f3, new FracStruct(1, i * (i + 1)));
        return f3;
    }

    public static FracStruct CalcExpr2(int n) {
        FracStruct f3 = new(1, 1);
        for (int i = 2; i <= n; i++)
            f3 = Multiply(f3, new FracStruct(i * i - 1, i * i));
        return f3;
    }
}	