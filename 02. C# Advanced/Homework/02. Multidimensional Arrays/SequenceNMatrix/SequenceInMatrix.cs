using System;
//Problem 3. Sequence n matrix
//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.
class SequenceInMatrix
{
    static void Main()
    {
        //input
        Console.Write("How many rows do you want in the matrix: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("\nHow many columns do you want in your matrix: ");
        int m = int.Parse(Console.ReadLine());

        string[,] matrix = new string[n, m];

        string read;
        string[] hold = new string[m];
        Console.WriteLine("\nEnter the matrix {0} elements per line seperated by space:", m);
        for (int row = 0; row < n; row++)
        {
            read = Console.ReadLine();
            hold = read.Split(' ');

            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = hold[col];
            }
        }

        //searches every single element checking its subsequent rows, cols and diagonals
        int maxCount = 1;
        int currentCount = 1;
        int startRow = 0;
        int startCol = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                //check rows
                for (int checkRow = row + 1; checkRow < n; checkRow++)
                {
                    if (matrix[row, col] != matrix[checkRow, col])
                    {
                        break;
                    }
                    currentCount++;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    startRow = row;
                    startCol = col;
                }
                currentCount = 1;

                //check cols
                for (int checkCol = col + 1; checkCol < m; checkCol++)
                {
                    if (matrix[row, col] != matrix[row, checkCol])
                    {
                        break;
                    }
                    currentCount++;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    startRow = row;
                    startCol = col;
                }
                currentCount = 1;

                //check diagonal left to right
                for (int move = 1; move + row < n && col + move < m; move++)
                {
                    if (matrix[row, col] != matrix[row + move, col + move])
                    {
                        break;
                    }
                    currentCount++;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    startRow = row;
                    startCol = col;
                }

                currentCount = 1;

                //check diagonal right to left
                for (int move = 1; move + row < n && col - move >= 0; move++)
                {
                    if (matrix[row, col] != matrix[row + move, col - move])
                    {
                        break;
                    }
                    currentCount++;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    startRow = row;
                    startCol = col;
                }

                currentCount = 1;
            }
        }

        //output
        Console.WriteLine("\nThe matrix:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("{0, -7} ", matrix[row, col]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nMaximal Sequence:");
        for (int i = 0; i < maxCount; i++)
        {
            Console.Write(matrix[startRow, startCol]);

            if (i != maxCount - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('\n');
    }
}