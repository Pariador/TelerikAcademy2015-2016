using System;

class RandomizedNumbersInRange
{
    static void Main()
    {
        Console.Write("How many random numbers: ");
        int num = int.Parse(Console.ReadLine());

        Console.Write("\nMinimum value?: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("\nMaximum value?: ");
        int max = int.Parse(Console.ReadLine()) + 1;

        Random rnd = new Random();

        Console.WriteLine("\nRandom number series:");
        for (int i = 0; i < num; i++)
        {
            Console.Write("{0} ", rnd.Next(min, max));
        }

        Console.WriteLine('\n');
    }
}