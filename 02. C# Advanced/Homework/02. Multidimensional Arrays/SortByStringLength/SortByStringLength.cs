using System;

//Problem 5. Sort by string length
//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
class SortByStringLength
{
    static void SortStringsByLength(string[] arr)
    {
        //Sorts the array by the length of its elements using selection sort
        int length = arr.Length;

        string hold;
        for (int findNow = 0; findNow < length - 1; findNow++)
        {
            for (int search = findNow + 1; search < length; search++)
            {
                if (arr[search].Length < arr[findNow].Length)
                {
                    hold = arr[search];
                    arr[search] = arr[findNow];
                    arr[findNow] = hold;
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("Input length of array: ");
        int length = int.Parse(Console.ReadLine());

        string[] arr = new string[length];

        Console.WriteLine("\nInput array:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Input element {0}: ", i);
            arr[i] = Console.ReadLine();
        }

        SortStringsByLength(arr);

        Console.WriteLine("\nThe array sorted by length:");
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Element {0}: {1}", i , arr[i]);
        }
        Console.WriteLine();
    }
}