public class MyFrac {
    private long nominator_, denominator_;
    public long Nominator {
        get => nominator_;
        private set => nominator_ = value;
    }
    public long Denominator {
        get => denominator_;
        private set {
            if (value == 0)
                throw new ArgumentException("denominator cannot be zero");
            denominator_ = value;
        }
    }

    public MyFrac(long numerator, long denominator) {
        long g = Gcd(numerator, denominator);

        Nominator = numerator / g;
        Denominator = denominator / g;
        
        if (Denominator < 0) {
            Nominator = -Nominator;
            Denominator = -Denominator;
        }
    }

    private static long Gcd(long nom, long denom) {
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

    public override string ToString() => $"{Nominator}/{Denominator}";

    public string ToStringWithIntPart() {
        string sign = (Nominator * Denominator < 0) ? "-" : "";
        long integerPart = Math.Abs(Nominator) / Denominator;
        long fractionalPart = Math.Abs(Nominator) % Denominator;

        if (integerPart == 0)
            return $"{sign}{fractionalPart}/{Denominator}";
        else if (fractionalPart == 0)
            return $"{sign}{integerPart}";
        else
            return $"{sign}{integerPart} + {fractionalPart}/{Denominator}";
    }

    public double ToDouble() => (double)Nominator / Denominator;

    //
    public static MyFrac operator +(MyFrac f1, MyFrac f2) {
        long nom = f1.Nominator * f2.Denominator + f2.Nominator * f1.Denominator;
        long denom = f1.Denominator * f2.Denominator;
        return new MyFrac(nom, denom);
    }

    public static MyFrac operator -(MyFrac f1, MyFrac f2) {
        long nom = f1.Nominator * f2.Denominator - f2.Nominator * f1.Denominator;
        long denom = f1.Denominator * f2.Denominator;
        return new MyFrac(nom, denom);
    }

    public static MyFrac operator *(MyFrac f1, MyFrac f2) {
        long nom = f1.Nominator * f2.Nominator;
        long denom = f1.Denominator * f2.Denominator;
        return new MyFrac(nom, denom);
    }

    public static MyFrac operator /(MyFrac f1, MyFrac f2) {
        long nom = f1.Nominator * f2.Denominator;
        long denom = f1.Denominator * f2.Nominator;
        return new MyFrac(nom, denom);
    }
}	
