using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

class ProblemThree
{
    public static int[,] matrix;
    public static int pawnRow = 0;
    public static int pawnCol = 0;
    static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    static BigInteger MovePawn(int row, int col)
    {
        BigInteger result = 0;
        if (pawnRow > row)
        {
            while (pawnRow != row)
            {
                pawnRow--;
                if (matrix[pawnRow, pawnCol] != 0)
                {
                    result += (BigInteger)Math.Pow(2, matrix[pawnRow, pawnCol]);
                    matrix[pawnRow, pawnCol] = 0;
                }
            }
        }
        else if (pawnRow < row)
        {
            while (pawnRow != row)
            {
                pawnRow++;
                if (matrix[pawnRow, pawnCol] != 0)
                {
                    result += (BigInteger)Math.Pow(2, matrix[pawnRow, pawnCol]);
                    matrix[pawnRow, pawnCol] = 0;
                }
            }
        }

        if (pawnCol > col)
        {
            while (pawnCol != col)
            {
                pawnCol--;
                if (matrix[pawnRow, pawnCol] != 0)
                {
                    result += (BigInteger)Math.Pow(2, matrix[pawnRow, pawnCol]);
                    matrix[pawnRow, pawnCol] = 0;
                }
            }
        }
        else if (pawnCol < col)
        {
            while (pawnCol != col)
            {
                pawnCol++;
                if (matrix[pawnRow, pawnCol] != 0)
                {
                    result += (BigInteger)Math.Pow(2, matrix[pawnRow, pawnCol]);
                    matrix[pawnRow, pawnCol] = 0;
                }
           }
        }

        return result;
    }

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        pawnRow = rows - 1;
        matrix = new int[rows, cols];
        
        for (int row = rows - 1, startValue = 0; row >= 0; row--, startValue++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = startValue + col;
            }
        }

        int posCount = int.Parse(Console.ReadLine());
        int coef = Math.Max(rows, cols);
        int[] codes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int goRow = 0;
        int goCol = 0;
        BigInteger result = 0;
        for (int i = 0; i < codes.Length; i++)
        {
            goRow = codes[i] / coef;
            goCol = codes[i] % coef;
            result += MovePawn(goRow, goCol);
        }

        Console.WriteLine(result + 1);
    }
}