using System;

class From1ToN
{
    static void Main()
    {
        Console.Write("Input n and see all the numbers in the interval [1..n]: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine();
    }
}