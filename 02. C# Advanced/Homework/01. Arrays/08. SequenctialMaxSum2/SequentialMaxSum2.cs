using System;
//Problem 8. Maximal sum
//Write a program that finds the sequence of maximal sum in given array.
class SequentialMaxSum2
{
    static void Main()
    {
        //My solution with 2 for loops.

        //input
        Console.Write("Input length of int array: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        Console.WriteLine("\nInput the elements of the array:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Input element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        //FIND
        int currentSum = array[0];
        int maxSum = array[0];
        int endIndex = 0;
        for (int i = 0; i < length; i++)
        {
            currentSum += array[i];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                endIndex = i;
            }
        }

        currentSum = array[endIndex];
        maxSum = array[endIndex];
        int startIndex = endIndex;
        for (int i = endIndex - 1; i >= 0; i--)
        {
            currentSum += array[i];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = i;
            }
        }

        //output
        Console.WriteLine("\nMaximum sequential sum:");
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (i != endIndex)
            {
                Console.Write("{0}, ", array[i]);
            }
            else
            {
                Console.Write( array[i]);
            }
        }

        Console.WriteLine('\n');
    }
}