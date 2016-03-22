using System;

class SumOfNumbers
{
    static void Main()
    {
        Console.Write("How many numbers do you want to add up?: ");
        int numbersCount = int.Parse(Console.ReadLine());

        double sum = new double();

        Console.WriteLine();
        for (int i = 0; i < numbersCount; i++)
        {
            Console.Write("Input number {0}: ", i + 1);
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nThe sum is: {0}\n", sum);
    }
}