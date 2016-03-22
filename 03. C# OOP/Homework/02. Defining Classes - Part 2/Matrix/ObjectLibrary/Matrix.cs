namespace Matrix.ObjectLibrary
{
    using System;
    using System.Linq;
    using System.Numerics;

    [Version(1, 0)]
    public class Matrix<T> where T : IComparable
    {
        //All types that T is allowed to be. Used in the constructor to check what type of matrix is being constructed and if it isn't part of this array an
        //exception is thrown.
        private static readonly Type[] validTypes = { typeof(byte[,]), typeof(sbyte[,]), typeof(short[,]), typeof(ushort[,]), typeof(int[,]), typeof(uint[,]),
                                                        typeof(long[,]), typeof(ulong[,]), typeof(float[,]), typeof(double[,]), typeof(decimal[,]), typeof(BigInteger) };

        public Matrix(int row, int col)
        {
            if (row <= 0 || col <= 0)
            {
                throw new ArgumentOutOfRangeException("There can't be a matrix with fewer than one row and one column.");
            }

            this.Matrx = new T[row, col];

            if (!Matrix<T>.validTypes.Contains(this.Matrx.GetType()))
            {
                throw new Exception("Type must be an integer or floting - point type.");
            }
        }

        public int Length
        {
            get
            {
                return this.Matrx.Length;
            }
        }
        private T[,] Matrx { get; set; }

        public T this[int row, int col]
        {
            get
            {
                return this.Matrx[row, col];
            }
            set
            {
                this.Matrx[row, col] = value;
            }
        }

        //Only matrices of the same size can be added or subtracted.
        //The result is a new matrix each element of wich is the result
        //of addtion or subraction of the corresponding element in the matrices.
        //Dynamic is safely used since it is imposible for a matrix object to be in a
        //state where T does't have the (+, -, *) operators.
        [Version(1, 0)]
        public static Matrix<T> Add(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            int rows = firstMatrix.GetLength(0);
            int cols = firstMatrix.GetLength(1);

            if (rows != secondMatrix.GetLength(0) || cols != secondMatrix.GetLength(1))
            {
                throw new ArgumentException("Only matrices with the same dimensions can be added.");
            }

            var result = new Matrix<T>(rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                }
            }

            return result;
        }
        public static Matrix<T> Subtract(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            int rows = firstMatrix.GetLength(0);
            int cols = firstMatrix.GetLength(1);

            if (rows != secondMatrix.GetLength(0) || cols != secondMatrix.GetLength(1))
            {
                throw new ArgumentException("Only matrices with the same dimensions can be subtracted.");
            }

            var result = new Matrix<T>(rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                }
            }

            return result;
        }
        //To multiply two matrices the first must have a number of colums equal to the number of rows in the second matrix.
        //The result will have the number of rows in the first matrix and the number of colums in the second.
        public static Matrix<T> Multiply(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            int rowsAndCols = firstMatrix.GetLength(1);

            if (rowsAndCols != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("To multiply two matrices the first must have a number of colums equal to the number of rows in the second matrix.");
            }

            int resultRows = firstMatrix.GetLength(0);
            int resultCols = secondMatrix.GetLength(1);

            var result = new Matrix<T>(resultRows, resultCols);

            for (int row = 0; row < resultRows; row++)
            {
                for (int col = 0; col < resultCols; col++)
                {
                    T temp = default(T);
                    for (int i = 0; i < rowsAndCols; i++)
		        	{
                        temp += (dynamic)firstMatrix[row, i] * secondMatrix[i, col];
		        	}

                    result[row, col] = temp;
                }
            }

            return result;
        }
        public int GetLength(int dimension)
        {
            return this.Matrx.GetLength(dimension);
        }
        //Checks if the current matrix a zero element.
        private bool HasZeroElements()
        {
            for (int row = 0; row < this.GetLength(0); row++)
            {
                for (int col = 0; col < this.GetLength(1); col++)
                {
                    if (this[row, col].CompareTo(default(T)) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //These operators use the obove defined methods.
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            return Matrix<T>.Add(firstMatrix, secondMatrix);
        }
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            return Matrix<T>.Subtract(firstMatrix, secondMatrix);
        }
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            return Matrix<T>.Multiply(firstMatrix, secondMatrix);
        }
        public static bool operator false(Matrix<T> matrix)
        {
            return matrix.HasZeroElements();
        }
        public static bool operator true(Matrix<T> matrix)
        {
            return !matrix.HasZeroElements();
        }
        public static bool operator !(Matrix<T> matrix)
        {
            return matrix ? false : true;
        }
    }
}