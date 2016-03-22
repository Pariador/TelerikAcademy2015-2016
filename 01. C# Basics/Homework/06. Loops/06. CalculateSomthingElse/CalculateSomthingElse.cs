using System;
using System.Numerics;

class CalculateSomthingElse
{
    static void Main()
    {
        Console.Write("Input n: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("\nInput k: ");
        int secondNUmber = int.Parse(Console.ReadLine());

        BigInteger firstFactorial = 1;
        BigInteger secondFactorial = 1;

       
        //Calculates n! / k!.
        for (int i = firstNumber, q = secondNUmber; i > 1 || q > 1; i--, q--)
        {
            if (i > 1)
            {
                firstFactorial *= i;
            }

            if (q > 1)
            {
                secondFactorial *= q;
            }
        }

        Console.WriteLine("\nResult: {0}\n", firstFactorial / secondFactorial);
    }
}