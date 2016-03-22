using System;
using System.Numerics;

class MchooseN
{
    static void Main()
    {
        Console.Write("Total?: ");
        int total = int.Parse(Console.ReadLine());

        Console.Write("\nChoose?: ");
        int choose = int.Parse(Console.ReadLine());

        BigInteger firstFactorial = 1;
        BigInteger secondFactorial = 1;

        for (int i = 0, q = total; i < choose; i++, q--)
        {
            firstFactorial *= q;
        }

        for (int i = 1; i <= choose; i++)
        {
            secondFactorial *= i;
        }

        Console.WriteLine("\n{0} choose {1}: {2} combinations.\n", total, choose, firstFactorial / secondFactorial);
    }
}