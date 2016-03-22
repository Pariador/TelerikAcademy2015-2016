using System;
//Problem 3. Compare char arrays
//Write a program that compares two char arrays lexicographically (letter by letter).
class CompareCharArrays
{
    static void Main()
    {
        //input
        Console.Write("Input the length of both arrays: ");
        int arrayLength = int.Parse(Console.ReadLine());
        char[] firstArray = new char[arrayLength];

        Console.WriteLine("\nInput the elements of the first array:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            firstArray[i] = char.Parse(Console.ReadLine());
        }

        char[] secondArray = new char[arrayLength];

        Console.WriteLine("\nInput the elements of the second array:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            secondArray[i] = char.Parse(Console.ReadLine());
        }

        //compare
        bool areSame = true;
        for (int i = 0; i < arrayLength; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                Console.WriteLine("\nMismatch found at element {0}!", i);
                Console.WriteLine("Element in first array: {0}", firstArray[i]);
                Console.WriteLine("Element in second array: {0}\n", secondArray[i]);
                areSame = false;
                break;
            }
        }

        if (areSame == true)
        {
            Console.WriteLine("\nThe arrays are the same.\n");
        }
    }
}