using System;

//Problem 6. First larger than neighbours
//Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
//Use the method from the previous exercise.
class FirstLargerThanNeighboursTest
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

    static int FirstLargerThanNeighbors(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (LargerThanNeighbors(arr, i))
            {
                return i;
            }
        }

        return -1;
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

        //output
        int result = FirstLargerThanNeighbors(arr);
        Console.WriteLine("\nFirst element in the array that is bigger than its neighbors: {0}\n", result == -1 ? "No such element." : result.ToString());
    }
}