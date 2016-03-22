using System;

class NumbersFrom1toN
{
    static void Main()
    {
        Console.Write("Write numbers from 1 to? ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine();

        for (int i = 1; i <= number; i++)
        {
            Console.Write("{0} ", i);
        }

        Console.WriteLine('\n');
    }
}