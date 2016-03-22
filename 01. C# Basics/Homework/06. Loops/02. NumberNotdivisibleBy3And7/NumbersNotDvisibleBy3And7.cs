using System;

class NumbersNotDvisibleBy3And7
{
    static void Main()
    {
        Console.Write("Write numbers from 1 to? ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine();

        for (int i = 1; i <= number; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine('\n');
    }
}