using System;

//Problem 9. Sorting array
//Write a method that returns the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.
class SortingArrayTest
{
    //returns the index of the biggest number in the array from a starting position if none is found returns the starting position
    static int MaxValueInInterval(int[] arr, int startPos)
    {
        int maxValueIndex = startPos;

        for (int i = startPos + 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[maxValueIndex])
            {
                maxValueIndex = i;
            }
        }

        return maxValueIndex;
    }

    //sorts an int array in descending order using MaxValueInInterval if ascending is true the array is reversed
    static void SelectionSort(int[] arr, bool ascending)
    {
        //sort in descending order
        int lastElement = arr.Length - 1;

        int hold = 0;
        int checkIndex = 0;
        for (int i = 0; i < lastElement; i++)
        {
            checkIndex = MaxValueInInterval(arr, i);

            if (arr[checkIndex] > arr[i])
            {
                hold = arr[i];
                arr[i] = arr[checkIndex];
                arr[checkIndex] = hold;
            }
        }

        //reverse if ascending == true
        if (ascending)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                hold = arr[i];
                arr[i] = arr[lastElement - i];
                arr[lastElement - i] = hold;
            }
        }
    }

    static void Main()
    {
        //input
        Console.Write("Input size of array: ");
        int length = int.Parse(Console.ReadLine());

        int[] arr = new int[length];//{9, 8, 7, 7, 6, 5, 4, 3, 2, 1, 0, 0 };//{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };//{ 1, 2, 10, 1, 2, 3, 4 };

        Console.WriteLine("\nInput array:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Input element {0}: ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nSort in ascending order? (y/n): ");
        bool ascending = Console.ReadLine() == "y" ? true : false;

        //sort
        SelectionSort(arr, ascending);
        
        //output
        Console.WriteLine("\nArray:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Element {0, -4}: {1}", i, arr[i]);
        }
        Console.WriteLine();
    }
}