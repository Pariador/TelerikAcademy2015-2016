using System;
//Problem 11. Binary search
//Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.
class BinarySearch
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

        Console.Write("\nValue to search for: ");
        int find = int.Parse(Console.ReadLine());

        //sort ascending
        Array.Sort(array);

        //binary search
        int iMin = 0;
        int iMax = array.Length - 1;
        int iMid = 0;
        bool found = false;
        if (array[iMax] == find)
        {
            Console.WriteLine("\nThe element with value {0} was found on index {1}.\n", find, iMax);
            return;
        }
        else if (array[iMin] == find)
        {
            Console.WriteLine("\nThe element with value {0} was found on index {1}.\n", find, iMin);
            return;
        }
        while (!found)
        {
            if (iMax == iMin + 1)
            {
                break;
            }

            iMid = (iMin + iMax) / 2;

            if (find < array[iMid])
            {
                iMax = iMid;
            }
            else if (find > array[iMid])
            {
                iMin = iMid;
            }
            else
            {
                found = true;
            }
        }

        //output
        if (found == true)
        {
            Console.WriteLine("\nThe element with value {0} was found on index {1}.\n",find , iMid);
        }
        else
        {
            Console.WriteLine("\nElement not found in array.\n");
        }
        
    }
}