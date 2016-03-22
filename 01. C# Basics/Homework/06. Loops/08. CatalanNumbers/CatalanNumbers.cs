using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        byte n;

        do
        {
            Console.Write("Input n (0 <= n <= 100): ");
        }
        while (!byte.TryParse(Console.ReadLine(), out n) || n < 0 || n > 100);

        BigInteger firstFactorial = 1;
        BigInteger secondFactorial = 1;
        BigInteger thirdFactorial = 1;

        for (int i = 2 * n; i > 1; i--)
        {
            firstFactorial *= i;    
        }

        for (int i = n + 1; i > 1; i--)
        {
            secondFactorial *= i;
        }

        for (int i = n; i > 1; i--)
        {
            thirdFactorial *= i;
        }

        Console.WriteLine("\nCatalan number {0} is: {1}\n", n, firstFactorial / (secondFactorial * thirdFactorial));
    }
}