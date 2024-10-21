public partial class Matrix {
    private double[,] data;
    private double det;
    public Matrix(double[,] arr) => data = (double[,]) arr.Clone();
    public Matrix(double[][] arr) {
        if (arr == null || arr.Length == 0 || arr[0] == null)
            throw new ArgumentException("no array");

        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].Length != arr[0].Length)
                throw new ArgumentException("non-rectangular jagged array");
        }

        int rows = arr.Length;
        int cols = arr[0].Length;

        data = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            Array.Copy(arr[i], 0, data, i * cols, cols);
    }
    public Matrix(string[] arr) {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("no array");

        var rows = arr.Length;
        var values = arr.Select(row => row.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)).ToArray();

        for (int i = 1; i < rows; i++)
            if (values[i].Length != values[0].Length)
                throw new ArgumentException("non-rectangular matrix");

        var cols = values[0].Length;

        data = new double[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++)
                if (!double.TryParse(values[i][j], out data[i, j]))
                    throw new ArgumentException("non-numeric value");
        }
    }
    public Matrix(string str) : this(str.Split('\n', StringSplitOptions.RemoveEmptyEntries)) {}
    public Matrix(Matrix m) : this(m.data) {}
    public int Height {
        get {return data.GetLength(0);}
    }
    public int Width {
        get {return data.GetLength(1);}
    }
    public int getHeight() => Height;
    public int getWidth() => Width;

    public double this[int i, int j] {
        get {
            if (i >= 0 && i < Height)
            if (j >= 0 && j < Width)
                return data[i,j];
            return 0;
        }
        set {
            if ( i >= 0 && i < Height
            && j >= 0 && j < Width )
                data[i,j] = value;
        }
    }
    public double getElement(int i, int j) {
        return this[i,j];
    }
    public void setElement(int i, int j, double value) {
        this[i,j] = value;
    }
    public override string ToString() {
        StringBuilder result = new StringBuilder("");
        for (int i = 0; i < Height; i++) {
            for (var j = 0; j < Width; j++)
                result.Append($"{this[i, j],3:F0} ");
            result.Append("\n");
        }
        return result.ToString();
    }
}
