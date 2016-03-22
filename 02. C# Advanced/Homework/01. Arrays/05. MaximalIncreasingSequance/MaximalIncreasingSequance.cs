using System;
//Problem 5. Maximal increasing sequence
//Write a program that finds the maximal increasing sequence in an array.
class MaximalIncreasingSequance
{
    static void Main()
    {
        //input
        Console.Write("Input the length the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLength];

        Console.WriteLine("\nInput the elements of the array:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }


        //find maximal increasing sequence
        int startSequenceNumber = array[0];
        int maxSequenceCount = 0;

        int hold = array[0];
        int count = 0;
        for (int i = 1; i < arrayLength; i++)
        {
            if (array[i] == hold + 1)
            {
                count++;
            }
            else
            {
                count = 0;
            }

            hold = array[i];

            if (count > maxSequenceCount)
            {
                maxSequenceCount = count;
                startSequenceNumber = hold - count;
            }
        }

        //output
        Console.WriteLine("\nMaximal Increasing sequence:");

        for (int i = 0; i <= maxSequenceCount; i++)
        {
            if (i != maxSequenceCount)
            {
                Console.Write("{0}, ", startSequenceNumber + i);
            }
            else
            {
                Console.WriteLine("{0}\n", startSequenceNumber + i);
            }
        }
    }
}