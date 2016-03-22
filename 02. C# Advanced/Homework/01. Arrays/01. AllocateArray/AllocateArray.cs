using System;
//Problem 1. Allocate array

//Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
//Print the obtained array on the console.
class AllocateArray
{
    static void Main()
    {
        int[] values = new int[20];
        int length = values.Length;


        for (int i = 0; i < length; i++)
        {
            values[i] = i * 5;
        }

        Console.WriteLine("Array:");
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Element {0}: {1}", i, values[i]);
        }

        Console.WriteLine();
    }
}