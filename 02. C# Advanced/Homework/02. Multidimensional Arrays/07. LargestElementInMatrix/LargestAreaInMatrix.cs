using System;
using System.Collections.Generic;
//Problem 7.* Largest area in matrix
//Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.

class LargestAreaInMatrix
{
    //checks the adjacent elements (one element above, to the right, below and to the left, not diagonally) of an element in a matrix
    //if the element is equal to the starting element and has not been searched it counts it, adds it to the list of searched elements
    //and it runs DebthFirstSearch on it
    //the starting element should be added to searched and counted in count before DebthFirstSearch is called.
    //each array in searched should have only 2 elements marking a position in the matrix that has alredy been searched
    //element[0] = row / element[1] = col
    static void DebthFirstSearch(int[,] matrix, int startRow, int startCol, List<int[]> searched, ref int count)
    {
        int searchRow = startRow - 1;
        int searchCol = startCol;
        bool isOutOfRange = searchRow < 0;
        bool isEqual = false;

        if (!isOutOfRange)
        {
            isEqual = matrix[searchRow, searchCol] == matrix[startRow, startCol];
        }

        bool isSearched = false;

        //above elemennt ------------------------------------------------------------
        //check isSearched
        for (int i = 0; i < searched.Count; i++)
		{
            if (searchRow == searched[i][0] && searchCol == searched[i][1])
            {
                isSearched = true;
                break;
            }
		}

        //check above elemennt
        if (!isSearched && !isOutOfRange && isEqual)
        {
            count++;
            searched.Add(new int[]{searchRow, searchCol});
            DebthFirstSearch(matrix, searchRow, searchCol, searched, ref count);
        }

        //right element -------------------------------------------------------------
        searchRow = startRow;
        searchCol = startCol + 1;
        isOutOfRange = searchCol > matrix.GetLength(1) - 1;

        if (!isOutOfRange)
        {
            isEqual = matrix[searchRow, searchCol] == matrix[startRow, startCol];
        }
        
        isSearched = false;
        //check isSearched
        for (int i = 0; i < searched.Count; i++)
        {
            if (searchRow == searched[i][0] && searchCol == searched[i][1])
            {
                isSearched = true;
                break;
            }
        }

        if (!isSearched && !isOutOfRange && isEqual)
        {
            count++;
            searched.Add(new int[] { searchRow, searchCol });
            DebthFirstSearch(matrix, searchRow, searchCol, searched, ref count);
        }

        //down element ------------------------------------------------------------
        searchRow = startRow + 1;
        searchCol = startCol;
        isOutOfRange = searchRow > matrix.GetLength(0) - 1;

        if (!isOutOfRange)
        {
            isEqual = matrix[searchRow, searchCol] == matrix[startRow, startCol];
        }
        
        isSearched = false;
        //check isSearched
        for (int i = 0; i < searched.Count; i++)
        {
            if (searchRow == searched[i][0] && searchCol == searched[i][1])
            {
                isSearched = true;
                break;
            }
        }

        if (!isSearched && !isOutOfRange && isEqual)
        {
            count++;
            searched.Add(new int[] { searchRow, searchCol });
            DebthFirstSearch(matrix, searchRow, searchCol, searched, ref count);
        }

        //left element ------------------------------------------------------------
        searchRow = startRow;
        searchCol = startCol - 1;
        isOutOfRange = searchCol < 0;

        if (!isOutOfRange)
        {
            isEqual = matrix[searchRow, searchCol] == matrix[startRow, startCol];
        }
        
        isSearched = false;
        //check isSearched
        for (int i = 0; i < searched.Count; i++)
        {
            if (searchRow == searched[i][0] && searchCol == searched[i][1])
            {
                isSearched = true;
                break;
            }
        }

        if (!isSearched && !isOutOfRange && isEqual)
        {
            count++;
            searched.Add(new int[] { searchRow, searchCol });
            DebthFirstSearch(matrix, searchRow, searchCol, searched, ref count);
        }
    }


    static void Main()
    {
        //int[,] matrix = {
        //                    {1,3,2,2,2,4},
        //                    {3,3,3,2,4,4},
        //                    {4,3,1,2,3,3},
        //                    {4,3,1,3,3,1},
        //                    {4,3,3,3,1,1}
        //                };

        Console.Write("Input rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("\nInput cols: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        string read;
        string[] hold = new string[cols];
        Console.WriteLine("\nEnter the matrix {0} elements per line seperated by space:", cols);
        for (int row = 0; row < rows; row++)
        {
            read = Console.ReadLine();
            hold = read.Split(' ');

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(hold[col]);
            }
        }

        //default values for everything are from the first element
        List<int[]> searched = new List<int[]>{ new int[] { 0, 0 } };
        int maxCount = 1;
        int maxCountValue = matrix[0, 0];
        DebthFirstSearch(matrix, 0, 0, searched, ref maxCount);

        //goes through all the elements in the matrix running DebthFirstSearch on each of them,
        //except if the element has alredy been searched, and then compares the current count of
        //found values to the max count
        int currentCount = 1;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int i = 0; i < searched.Count; i++)
                {
                    if (searched[i][0] == row && searched[i][1] == col)
                    {
                        break;
                    }

                    currentCount = 1;
                    searched.Add(new int[] { row, col });
                    DebthFirstSearch(matrix, row, col, searched, ref currentCount);

                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        maxCountValue = matrix[row, col];
                    }
                }
            }
        }

        //output
        Console.WriteLine("\nThe matrix:");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0, -7} ", matrix[row, col]);
            }
            Console.WriteLine();
        }

        Console.WriteLine(maxCount);
        Console.WriteLine(maxCountValue);
    }
}