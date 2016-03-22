using System;
//Problem 6. Maximal K sum
//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.
class MaximalKSum
{
    static void Main()
    {
        //input
        int length;
        do
        {
            Console.Write("Input length of array (> 0): ");
            length = int.Parse(Console.ReadLine());
        } while(length <= 0);

        int[] array = new int[length];

        Console.WriteLine("\nInput array:");
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        

        int numbersCount;
        do
        {
            Console.Write("\n(0 < K <= length): ");
            numbersCount = int.Parse(Console.ReadLine());
        } while (numbersCount > length || numbersCount <= 0);

        int[] biggestNumbers = new int[numbersCount];
        biggestNumbers[0] = int.MinValue;


        //finds the K biggest numbers in the array and puts them in a new K sized array.
        //every time a bigger number is found all others are moved one idex up (deleting the last one) and the new biggest one 
        //goeson in the [0] index.
        for (int i = 0; i < length; i++)
        {
            if (array[i] >= biggestNumbers[0])
            {
                for (int j = biggestNumbers.Length - 1; j >= 1; j--)
                {
                    biggestNumbers[j] = biggestNumbers[j - 1];
                }

                biggestNumbers[0] = array[i];
            }
        }


        //sums them up and outputs the sum
        int sum = 0;

        for (int i = 0; i < biggestNumbers.Length; i++)
        {
            sum += biggestNumbers[i];
        }

        Console.WriteLine("\nThe biggest sum of {0} numbers in the array is: {1}\n", numbersCount, sum);
    }
}