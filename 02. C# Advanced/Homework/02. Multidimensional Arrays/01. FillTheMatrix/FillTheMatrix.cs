using System;

//Problem 1. Fill the matrix of size (n, n)
class FillTheMatrix
{
    static void Main()
    {
        //input
        Console.Write("Imput N:");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        //assignment 1a
        for (int col = 0, values = 1; col < n; col++)
        {
            for (int row = 0; row < n; row++, values++)
            {
                matrix[row, col] = values;
            }
        }

        //output
        Console.WriteLine("\nAssaignment 1a:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }
            Console.WriteLine();

        }
        Console.WriteLine('\n');

        //assignment 1b
        for (int col = 0, values = 1; col < n; col++)
        {
            if (col % 2 != 0)
            {
                for (int row = n - 1; row >= 0; row--, values++)
                {
                    matrix[row, col] = values;
                }
            }
            else
            {
                for (int row = 0; row < n; row++, values++)
                {
                    matrix[row, col] = values;
                }
            }
        }

        //output
        Console.WriteLine("Assaignment 1b:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }
            Console.WriteLine();

        }
        Console.WriteLine('\n');

        //assignment 1c
        for (int row = n - 1, values = 1; row >= 0; row--)
        {
            for (int row2 = row, col = 0; row2 < n; row2++, col++)
            {
                matrix[row2, col] = values;
                values++;
            }
        }


        for (int row = 0, values = n * n; row < n - 1; row++)
        {
            for (int row2 = row, col = n - 1; row2 >= 0; row2--, col--)
            {
                matrix[row2, col] = values;
                values--;
            }
        }

        //output
        Console.WriteLine("Assaignment 1c:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine('\n');

        //assignment 1d
        int theValues = 1;
        int maxValue = n * n;
        int downAndLeft = n - 1;
        int upAndRight = 0;
        int r = 0;
        int c = 0;
        int count = 0;
        while (theValues < maxValue)
        {
            while (r < downAndLeft)
            {
                matrix[r, c] = theValues;
                r++;
                theValues++;
            }

            while (c < downAndLeft)
            {
                matrix[r, c] = theValues;
                c++;
                theValues++;
            }

            downAndLeft -= 1;

            while (r > upAndRight)
            {
                matrix[r, c] = theValues;
                r--;
                theValues++;
            }

            upAndRight += 1;

            while (c > upAndRight)
            {
                matrix[r, c] = theValues;
                c--;
                theValues++;
            }

            count++;
        }
        matrix[r, c] = maxValue;
        //output
        Console.WriteLine("Assaignment 1d:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}