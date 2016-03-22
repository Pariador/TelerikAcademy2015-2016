using System;
//Problem 4. Maximal sequence
//Write a program that finds the maximal sequence of equal elements in an array.
class MaximalSequence
{
    static void Main()
    {
        //input
        Console.Write("Input the length the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLength];

        Console.WriteLine("\nInput the elements of the first array:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }


        //find maximal sequence
        int? maxSequenceNumber = null;
        int maxSequenceCount = 0;

        int? hold = null;
        int count = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            if (hold != array[i])
            {
                hold = array[i];
                count = 1;
            }
            else
            {
                count++;
            }

            if (count > maxSequenceCount)
            {
                maxSequenceCount = count;
                maxSequenceNumber = hold;
            }
        }


        //output
        Console.WriteLine("\nMaximal sequence:");

        for (int i = 1; i <= maxSequenceCount; i++)
        {
            if (i != maxSequenceCount)
            {
                Console.Write("{0}, ", maxSequenceNumber);
            }
            else
            {
                Console.WriteLine("{0}\n", maxSequenceNumber);
            }
        }
    }
}