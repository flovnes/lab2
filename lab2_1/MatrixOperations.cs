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
    public void TransponeMe() {
        data = GetTransponedArray();
        det = double.NaN;
    }

    public double CalcDeterminant() {
        if (!double.IsNaN(det))
            return det;

        if (Height != Width)
            throw new InvalidOperationException("non-square matrices.");

        double[,] a = new double[Height, Width];
        Array.Copy(data, a, data.Length);
        
        int n = Height;
        det = 1;

        for (int k = 0; k < n; k++) {
            int maxRow = k;
            double maxVal = Math.Abs(a[k, k]);
            
            for (int i = k + 1; i < n; i++) {
                if (Math.Abs(a[i, k]) > maxVal) {
                    maxVal = Math.Abs(a[i, k]);
                    maxRow = i;
                }
            }

            if (maxRow != k) {
                for (int j = k; j < n; j++) {
                    (a[k, j], a[maxRow, j]) = (a[maxRow, j], a[k, j]);
                }
                det = -det;
            }

            if (Math.Abs(a[k, k]) < 1e-10) {
                det = 0;
                return det;
            }

            for (int i = k + 1; i < n; i++) {
                double factor = a[i, k] / a[k, k];
                for (int j = k; j < n; j++) {
                    a[i, j] -= factor * a[k, j];
                }
            }
            
            det *= a[k, k];
        }

        return det;
    }
}
