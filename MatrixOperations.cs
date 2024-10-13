public partial class Matrix {
    public static Matrix operator +(Matrix a, Matrix b) {
        if (a.Height != b.Height || a.Width != b.Width)
            throw new ArgumentException("different dimensions");

        double[,] result = new double[a.Height, a.Width];
        for (int i = 0; i < a.Height; i++)
            for (int j = 0; j < a.Width; j++)
                result[i, j] = a[i, j] + b[i, j];

        return new Matrix(result);
    }

    public static Matrix operator *(Matrix a, Matrix b) {
        if (a.Width != b.Height)
            throw new ArgumentException("different column count");

        double[,] result = new double[a.Height, b.Width];
        for (int i = 0; i < a.Height; i++)
            for (int j = 0; j < b.Width; j++)
                for (int k = 0; k < a.Width; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return new Matrix(result);
    }

    private double[,] GetTransponedArray() {
        double[,] transposed = new double[Width, Height];
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                transposed[j, i] = data[i, j];
        return transposed;
    }

    public Matrix GetTransponedCopy() => new(GetTransponedArray());
    public void TransponeMe() => data = GetTransponedArray();
}
