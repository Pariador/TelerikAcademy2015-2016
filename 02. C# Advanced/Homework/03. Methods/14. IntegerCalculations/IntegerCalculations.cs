using System;

//Problem 14. Integer calculations
//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.
class IntegerCalculationsTest
{
    static int IntMax(params int[] numbers)
    {
        int maxNumber = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
        }

        return maxNumber;
    }

    static int IntMin(params int[] numbers)
    {
        int minNumber = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < minNumber)
            {
                minNumber = numbers[i];
            }
        }

        return minNumber;
    }

    static long IntSum(params int[] numbers)
    {
        long total = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            total += numbers[i];
        }

        return total;
    }

    static double IntAVG(params int[] numbers)
    {

        return (double)IntSum(numbers) / numbers.Length;
    }

    static long IntProduct(params int[] numbers)
    {
        long product = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    static void Main()
    {
        Console.WriteLine("Max: {0}", IntMax(1, 33, 3, 4, 5, 6, 7, 8, 99999, 0, -1512));
        Console.WriteLine("Min: {0}", IntMin(-6, 1, 0, -51, 1341212, -7));
        Console.WriteLine("Sum: {0}", IntAVG(1, 2, 3, 4, 5, 6, 7, 8, 99999, 2000000, 0, -1512));
        Console.WriteLine("AVG: {0}", IntSum(1, 2, 3, 4, -10));
        Console.WriteLine("Product: {0}\n", IntProduct(5, 4, 3, 2, 1));
    }
}