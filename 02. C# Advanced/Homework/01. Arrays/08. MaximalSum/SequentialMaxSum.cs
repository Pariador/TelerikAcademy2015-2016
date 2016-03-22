using System;
//Problem 8. Maximal sum
//Write a program that finds the sequence of maximal sum in given array.
class SequentialMaxSum
{
    static void Main()
    {
        //Googled it to find a solution with one for.

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
        int startIndex = 0;
        int holdIndex = 0;
        for (int i = 1; i < length; i++)
        {
            currentSum += array[i];
            if (array[i] > currentSum)
            {
                currentSum = array[i];
                holdIndex = i;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = holdIndex;
            }
        }

        //output
        currentSum = 0;
        Console.WriteLine("\nMaximum sequential sum:");
        while (currentSum != maxSum)
        {
            currentSum += array[startIndex];
            if (currentSum != maxSum)
            {
                Console.Write("{0}, ", array[startIndex]);
            }
            else
            {
                Console.Write(array[startIndex]);
            }
            startIndex++;
        }

        Console.WriteLine('\n');
    }
}