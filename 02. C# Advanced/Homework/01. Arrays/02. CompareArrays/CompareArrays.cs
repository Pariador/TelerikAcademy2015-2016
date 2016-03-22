using System;
//Problem 2. Compare arrays
//Write a program that reads two integer arrays from the console and compares them element by element.
class CompareArrays
{
    static void Main()
    {
        //input
        Console.Write("Input the length of the first array: ");
        int firstArrayLength = int.Parse(Console.ReadLine());
        int[] firstArray = new int[firstArrayLength];

        Console.WriteLine("\nInput the elements of the first array:");
        for (int i = 0; i < firstArrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }


        Console.Write("\nInput the length of the second array: ");
        int secondArrayLength = int.Parse(Console.ReadLine());
        int[] secondArray = new int[secondArrayLength];

        Console.WriteLine("\nInput the elements of the second array:");
        for (int i = 0; i < secondArrayLength; i++)
        {
            Console.Write("Input element {0}: ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }


        //check if the arrays hold the same values
        bool areSame = true;
        if (firstArrayLength != secondArrayLength)
        {
            Console.WriteLine("\nArrays don't hold the same values - one is bigger than the other.\n");
            areSame = false;
        }
        else
        {
            for (int i = 0; i < firstArrayLength; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine("\nDiference found at element {0}.\n", i);
                    Console.WriteLine("Arrays don't hold the same values.\n");
                    areSame = false;
                    break;
                }
            }
        }

        if (areSame == true)
        {
            Console.WriteLine("\nArrays hold the same values.\n");
        }


        //print the arrays
        int biggerLength = firstArrayLength;

        if (secondArrayLength > firstArrayLength )
        {
            biggerLength = secondArrayLength;
        }

        Console.WriteLine("First array:                   | Second array:");
        for (int i = 0; i < biggerLength; i++)
        {
            if (i >= secondArrayLength)
            {
                Console.WriteLine("Element {0, 5}: {1, 16}| Element {0}: {2}", i, firstArray[i], "No such element.");
            }
            else if (i >= firstArrayLength)
            {
                Console.WriteLine("Element {0, 5}: {1, 16}| Element {0}: {2}", i, "No such element.", secondArray[i]);
            }
            else
            {
                Console.WriteLine("Element {0, 5}: {1, 16}| Element {0}: {2}", i, firstArray[i], secondArray[i]);
            }
        }
        Console.WriteLine();
    }
}