using System;
//Problem 7. Selection sort
//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
//Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
class SelectionSort
{
    static void Main()
    {
        //Sorting an int array using Slection Sort.

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
       

        //sort
        int hold;
        int lowestNumIndex = 0;
        for (int i = 0; i < length - 1; i++)
        {
            lowestNumIndex = i;
            for (int j = i + 1; j < length; j++)
            {
                if (array[j] < array[lowestNumIndex])
                {
                    lowestNumIndex = j;
                }
            }

            hold = array[i];
            array[i] = array[lowestNumIndex];
            array[lowestNumIndex] = hold;
        }


        //output
        Console.WriteLine("\nSorted array in ascending order:");
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Element {0}: {1}", i, array[i]);
        }
        Console.WriteLine();
    }
}