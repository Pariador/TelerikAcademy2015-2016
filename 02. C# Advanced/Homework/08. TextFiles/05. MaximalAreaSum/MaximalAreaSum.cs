using System;
using System.IO;
using System.Linq;

//Problem 5. Maximal area sum
//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.
class MaximalAreaSumTest
{
    static void Main()
    {
        Console.Write("Input file path: ");
        string inputPath = Console.ReadLine();

        int matrixSize; 
        int[,] matrix;
        char[] separators = new char[] { ' ', '\n' };
        using (var reader = new StreamReader(inputPath))
        {
            matrixSize = int.Parse(reader.ReadLine().Trim(separators));

            matrix = new int[matrixSize, matrixSize];

            int[] currentRow;
            for (int row = 0; row < matrixSize; row++)
            {
                currentRow = reader.ReadLine()
                            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x))
                            .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            //for (int row = 0; row < matrixSize; row++)
            //{
            //    for (int col = 0; col < matrixSize; col++)
            //    {
            //        Console.Write(matrix[row, col]);
            //    }
            //    Console.WriteLine();
            //}
        }

        int currentSum = 0;
        int maximalSum = matrix[0, 0] + matrix[0, 1] + matrix[1, 0] + matrix[1, 1];
        for (int row = 0; row < matrixSize - 1; row++)
        {
            for (int col = 0; col < matrixSize - 1; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > maximalSum)
                {
                    maximalSum = currentSum;
                }
            }
        }

        using (var writer = new StreamWriter(@"..\..\MaximalNumber.txt"))
        {
            writer.Write(maximalSum);
        }
    }
}