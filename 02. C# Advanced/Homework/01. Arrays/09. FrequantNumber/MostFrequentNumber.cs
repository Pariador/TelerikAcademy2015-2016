using System;
using System.Collections.Generic;
//Problem 9. Frequent number
//Write a program that finds the most frequent number in an array.
class MostFrequentNumber
{
    static void Main()
    {
        //inout
        Console.Write("Input the length the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLength];

        List<int> uniqueNumbers = new List<int>();

        //input the array adding each unique element of it to a list
        Console.WriteLine("\nInput the elements of the array:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());

            if (!uniqueNumbers.Contains(array[i]))
            {
                uniqueNumbers.Add(array[i]);
            }
        }


        //counts each unique element of the array
        int uniqueCount = uniqueNumbers.Count;

        int[] counts = new int[uniqueCount];

        for (int i = 0; i < uniqueCount; i++)
        {
            for (int j = 0; j < arrayLength; j++)
            {
                if (uniqueNumbers[i] == array[j])
                {
                    counts[i]++;
                }
            }
        }


        //finds the largest count and then its index and uses that for the answer
        int[] countsClone = new int[uniqueCount];

        counts.CopyTo(countsClone, 0);

        Array.Sort(countsClone);

        int answerIndex = Array.IndexOf(counts, countsClone[uniqueCount - 1]);

        Console.WriteLine("\n{0} is the most frequent number with {1} occurrences.\n", uniqueNumbers[answerIndex], counts[answerIndex]);
    }
}