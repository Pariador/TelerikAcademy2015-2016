using System;
//Problem 2. Maximal sum
//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
class MaximalSumIn3X3
{
    static void Main()
    {
        //input
        Console.Write("How many rows do you want in the matrix: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("\nHow many columns do you want in your matrix: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];

        if (n < 3 || m < 3)
        {
            Console.WriteLine("\nMatrix too small to search, it needs to be at least 3x3.\n");
        }

        string read;
        string[] hold = new string[m];
        Console.WriteLine("\nEnter the matrix {0} numbers per line seperated by space:", m);
        for (int row = 0; row < n; row++)
        {
            read = Console.ReadLine();
            hold = read.Split(' ');

            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = int.Parse(hold[col]);
            }
        }

        //find
        int currentSum = 0;
        int greatestSum = matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2];
        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < m - 2; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (currentSum > greatestSum)
                {
                    greatestSum = currentSum;
                }
            }
        }

        //output
        Console.WriteLine("\nThe greatest sum in a 3x3 space in the matrix is: {0}\n", greatestSum);
    }
}