using System;

class CalculateSomething
{
    static void Main()
    {
        Console.Write("Input n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("\nInput x: ");
        int x = int.Parse(Console.ReadLine());

        decimal sum = 1;

        //Calculates: S = 1 + 1!/x + 2!/x2 + … + n!/x^n.

        for (int i = 1; i <= n; i++)
        {
            ulong factorial = 1;

            for (int q = i; q > 1; q--)
			{
                factorial *= (ulong) q;
			}
            
            sum += factorial / (decimal) Math.Pow(x, i);
        }

        Console.WriteLine("\nSum = {0:0.00000}\n", sum);
    }
}