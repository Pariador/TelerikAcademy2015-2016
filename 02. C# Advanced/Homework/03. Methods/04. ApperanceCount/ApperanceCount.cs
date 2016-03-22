using System;

//Problem 4. Appearance count
//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.
class ApperanceCountTest
{
    static int ApperanceCount(int[] arr, int find)
    {
        int count = 0;

        foreach  (int num in arr)
        {
            if (num == find)
            {
                count++;
            }
        }

        return count;
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

        Console.Write("\nNumber to count in the array: ");
        int find = int.Parse(Console.ReadLine());

        //ouput
        Console.WriteLine("\nThe number {0} is found {1} times in the array.\n", find, ApperanceCount(arr, find));
    }
}
