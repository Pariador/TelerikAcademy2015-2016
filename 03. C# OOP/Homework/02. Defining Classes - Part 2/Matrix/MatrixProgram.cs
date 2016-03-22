namespace Matrix
{
    using System;
    using ObjectLibrary;

    internal class MatrixProgram
    {
        public static void PrintMatrix(Matrix<int> matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
			{
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, -5}", matrix[row, col]);
                }
                Console.WriteLine();
			}
            Console.WriteLine();
        }

        static void Main()
        {
            //Some tests for the Matrix object.
            var firstMatrix = new Matrix<int>(4, 4);
            var secondMatrix = new Matrix<int>(4, 4);

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    firstMatrix[row, col] = col + row + 2;
                    secondMatrix[row, col] = firstMatrix[row, col] * 2;
                }
            }
            Console.WriteLine("First matrix:");
            PrintMatrix(firstMatrix);
            Console.WriteLine("Second matrix:");
            PrintMatrix(secondMatrix);
            Console.WriteLine("Addition:");
            PrintMatrix(firstMatrix + secondMatrix);
            Console.WriteLine("Subtraction:");
            PrintMatrix(firstMatrix - secondMatrix);
            Console.WriteLine("Multiplication:");
            PrintMatrix(firstMatrix * secondMatrix);

            if (firstMatrix)
            {
                Console.WriteLine("True Matrix");
            }
            firstMatrix[0, 0] = 0;

            if (firstMatrix)
            {
                Console.WriteLine(":(");
            }
            else
            {
                Console.WriteLine("False matrix");
            }

            if (!firstMatrix)
            {
                Console.WriteLine("It's true that the matrix is false.");
            }
            else
            {
                Console.WriteLine(":(");
            }

            var attributes = typeof(Matrix<int>).GetCustomAttributes(typeof(VersionAttribute), false);
            foreach (var attribute in attributes)
            {
                var verAttribute = (VersionAttribute)attribute;
                Console.WriteLine(verAttribute.ToString());
            }
        }
    }
}