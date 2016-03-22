using System;

//Problem 4. Binary search
//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
class BinarySearch
{
    static void Main()
    {
        //input
        Console.Write("Input length of int array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("\nInput array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input element {0}: ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nInput number to search for: ");
        int k = int.Parse(Console.ReadLine());


        //search
        Array.Sort(arr);

        int hold = k;
        int result = 0;
        do
        {
            result = Array.BinarySearch(arr, hold);

            if (hold < arr[0])
            {
                //output
                Console.WriteLine("\nNo item in the array wich is <= {0}.\n", k);
                return;
            }

            hold--;
        } while(result < 0);

        //output
        Console.WriteLine("\nThe bigest number that is <= {0}: {1}\n", k, arr[result]);
    }
}