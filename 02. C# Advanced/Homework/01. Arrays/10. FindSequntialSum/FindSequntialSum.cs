using System;
//Problem 10. Find sum in array
//Write a program that finds in given array of integers a sequence of given sum S (if present).
class FindSequntialSum
{
    static void Main()
    {
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

        Console.Write("\nInput sequention sum to look for: ");
        int sum = int.Parse(Console.ReadLine());

        //find and output
        Console.WriteLine('\n');
        int currnetSum = 0;
        for (int i = 0; i < length - 1; i++)
        {
            if (array[i] == sum)
            {
                Console.Write("Element with index {0} is equal to the sum: {1} = {1}\n\n", i, sum);
            }
            currnetSum = array[i];
            for (int j = i + 1; j < length; j++)
            {
                currnetSum += array[j];
                if (currnetSum == sum)
                {
                    Console.WriteLine("Sequential sum found:");
                    for (int k = i; k <= j; k++)
                    {
                        if (k != j)
                        {
                            Console.Write("{0}, ", array[k]);
                        }
                        else
                        {
                            Console.Write(array[k]);
                        }
                    }
                    Console.WriteLine('\n');
                }
            }
        }
    }
}