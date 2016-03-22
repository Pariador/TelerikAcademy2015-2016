using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("How many Fibonacci numbers do you want to see: ");
        int fibonacciCount = int.Parse(Console.ReadLine());

        int firstSeed = 0;
        int secondSeed = 1;

        for (int i = 0; i < fibonacciCount; i++)
        {
            if (i == 0)
            {
                Console.Write("{0}", firstSeed);
            }
            else if (i == 1)
            {
                Console.Write(", {0}", secondSeed);
            }
            else
            {
                if (i % 2 == 0)
                {
                    firstSeed += secondSeed;
                    Console.Write(", {0}", firstSeed);
                }
                else
                {
                    secondSeed += firstSeed;
                    Console.Write(", {0}", secondSeed);
                }
            }
        }

        Console.WriteLine('\n');
    }
}