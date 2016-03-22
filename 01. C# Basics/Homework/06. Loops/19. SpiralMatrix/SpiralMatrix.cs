using System;

class SpiralMatrix
{
    static void Main(string[] args)
    {
        int n;

        do
        {
            Console.Write("Input n (0 <= n <= 20): ");
        }
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 20);

        int[,] matrix = new int[n, n];

        int maxValue = n * n;

        int col = 0;
        int row = 0;
        int values = 1;

        int rightAndDown = n - 1;
        int leftAndUp = 0;

        //makes the matrix
        while (values < maxValue)
        {
            while (col < rightAndDown)
            {
                matrix[row, col] = values;
                values++;
                col++;
            }

            while (row < rightAndDown)
            {
                matrix[row, col] = values;
                values++;
                row++;
            }

            rightAndDown -= 1;

            while (col > leftAndUp)
            {
                matrix[row, col] = values;
                values++;
                col--;
            }

            leftAndUp += 1;

            while (row > leftAndUp)
            {
                matrix[row, col] = values;
                values++;
                row--;
            }
        }

        matrix[row, col] = maxValue;

        //output
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            for (int q = 0; q < n; q++)
            {
                Console.Write("{0, 3} ", matrix[i, q]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}