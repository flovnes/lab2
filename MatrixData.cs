using System.Runtime.CompilerServices;

class Matrix {
    private double[,] matrix;
    public Matrix(double[,] arr) {
        matrix = new double[arr.GetLength(0),arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(0); i++) {
            for (int j = 0; j < arr.GetLength(1); j++) {
                matrix[i,j] = arr[i,j];
            }
        }
    }
    public Matrix(double[][] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].Length != arr[0].Length)
                throw new ArgumentException("non-rectangular jagged array");
        }

        matrix = new double[arr.Length, arr[0].Length];
        for (int i = 0; i < arr.Length; i++) {
            for (int j = 0; j < arr[0].Length; j++) {
                matrix[i,j] = arr[i][j];
            }
        }
    }
    public Matrix(string[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].Length != arr[0].Length)
                throw new ArgumentException("non-rectangular matrix");
            string[] values = arr[i].Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < values.Length; j++) {
                if (!double.TryParse(values[j], out matrix[i,j])) {
                    throw new ArgumentException("non-numeric value");
                }
            }
        }
        
        matrix = new double[arr.Length, arr[0].Length];
        for (int i = 0; i < arr.Length; i++) {
            for (int j = 0; j < arr[0].Length; j++) {
                matrix[i,j] = arr[i][j];
            }
        }
    }
    public Matrix(string str) {}
    public Matrix(Matrix m) {
    }
    public int Height {
        get {return matrix.GetLength(1);}
    }
    public int Width {
        get {return matrix.GetLength(0);}
    }
    public int getHeight() {
        return Height;
    }
    public int getWidth() {
        return Width;
    }
    public double this[int i, int j] {
        get {
            if (i >= 0 && i < Height)
            if (j >= 0 && j < Width)
                return matrix[i,j];
            return 0;
        }
        set {
            if ( i >= 0 && i < Height
            && j >= 0 && j < Width )
                matrix[i,j] = value;
        }
    }
}