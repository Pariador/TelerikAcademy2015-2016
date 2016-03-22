using System;

class MinAndMaxAndSumAndAverageOfNumbers
{
    static void Main()
    {
        Console.Write("How many numbers do you want to enter? ");
        int numberCount = int.Parse(Console.ReadLine());

        int[] numbers = new int[numberCount];

        Console.WriteLine();

        for (int i = 0; i < numberCount; i++)
        {
            Console.Write("Number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int minValue = numbers[0];
        int maxValue = numbers[0];
        int sum = 0;

        foreach (int num in numbers)
        {
            if (num < minValue)
            {
                minValue = num;
            }

            if (num > maxValue)
            {
                maxValue = num;
            }

            sum += num;
        }

        Console.WriteLine("\nMin Value: {0}\n", minValue);
        Console.WriteLine("Max Value: {0}\n", maxValue);
        Console.WriteLine("Sum: {0}\n", sum);
        Console.WriteLine("Average: {0:0.00}\n", sum / (double) numberCount);
    }
}