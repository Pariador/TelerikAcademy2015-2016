using System;
//Problem 14. Quick sort
//Write a program that sorts an array of strings using the Quick sort algorithm.
class QuickSort
{
    static void Quicksort(int[] arr, int start, int endPivot)
    {
        if (start >= endPivot)
        {
            return;
        }
        int wall = start;
        int hold;
        for (int i = wall; i < endPivot; i++)
        {
            if (arr[i] < arr[endPivot])
            {
                hold = arr[i];
                arr[i] = arr[wall];
                arr[wall] = hold;
                wall++;
            }
        }

        hold = arr[endPivot];
        arr[endPivot] = arr[wall];
        arr[wall] = hold;

        Quicksort(arr, start , wall - 1);
        Quicksort(arr, wall + 1, endPivot);
    }
    static void Main()
    {
        //inout
        Console.Write("Input length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        

        for (int i = 0; i < length; i++)
        {
            Console.Write("Input element {0}: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        //quicksort
        Quicksort(numbers, 0, length - 1);

        //output
        Console.WriteLine("\nSorted sequence:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine('\n');
        
        
    }
}