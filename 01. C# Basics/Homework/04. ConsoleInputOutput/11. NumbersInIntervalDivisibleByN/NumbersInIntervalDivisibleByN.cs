using System;

class NumbersInIntervalDivisibleByN
{
    static void Main()
    {
        Console.Write("Interval start: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("\nInterval end: ");
        int end = int.Parse(Console.ReadLine());


        int divisibleNumberCount = 0;

        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                divisibleNumberCount++;
            }
        }

        Console.WriteLine("\nThere are {0} numbers divisible by 5 in the interval {1} - {2}.\n", divisibleNumberCount, start, end);
    }
}