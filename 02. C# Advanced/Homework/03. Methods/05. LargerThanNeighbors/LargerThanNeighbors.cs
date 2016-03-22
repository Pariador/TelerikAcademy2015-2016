using System;

//Problem 5. Larger than neighbours
//Write a method that checks if the element at given position in given 
//array of integers is larger than its two neighbours (when such exist).
class LargerThanNeighborsTest
{
    static bool LargerThanNeighbors(int[] arr, int pos)
    {
        int lastPos = arr.Length - 1;

        if (pos == 0)
        {
            if (arr[0] > arr[1])
            {
                return true;
            }
            else
	        {
                return false;
	        }
            
        }
        else if (pos == lastPos)
        {
            if (arr[lastPos] > arr[lastPos - 1])
            {
                return true;
            }
            else
            {
                return false;
            }       
        }
        else if (arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        //input
        Console.Write("Input the length of an array: ");
        int length = int.Parse(Console.ReadLine());

        int[] arr = new int[length];

        Console.WriteLine("\nInput the array:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Input element {0}: ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nElement to check: ");
        int pos = int.Parse(Console.ReadLine());

        //ouput
        Console.WriteLine("\nThe number at position {0} is larger than its naighbors: {1}\n", pos, LargerThanNeighbors(arr, pos));
    }
}
