namespace BitShiftMatrix
{
    using System;
    using System.Linq;
    using System.Numerics;

    public static class Solve
    {
        public static BigInteger GetPositionValue(int row, int col, int rows)
        {
            int power = ((rows - 1) - row) + col;

            return BigInteger.Pow(2, power);
        }

        internal static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int codesCount = int.Parse(Console.ReadLine());
            int[] codes = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            int row = rows - 1;
            int col = 0;
            bool[,] field = new bool[rows, cols];
            field[row, col] = true;
            BigInteger result = 1;

            int key = Math.Max(rows, cols);
            foreach (var code in codes)
            {
                int destinationRow = code / key;
                int destinationCol = code % key;

                while (col != destinationCol)
                {
                    if (col < destinationCol)
                    {
                        col++;
                    }
                    else if (col > destinationCol)
                    {
                        col--;
                    }

                    if (!field[row, col])
                    {
                        result += Solve.GetPositionValue(row, col, rows);
                    }

                    field[row, col] = true;
                }

                while (row != destinationRow)
                {
                    if (row < destinationRow)
                    {
                        row++;
                    }
                    else if (row > destinationRow)
                    {
                        row--;
                    }

                    if (!field[row, col])
                    {
                        result += Solve.GetPositionValue(row, col, rows);
                    }

                    field[row, col] = true;
                }

            }

            Console.WriteLine(result);
        }
    }
}