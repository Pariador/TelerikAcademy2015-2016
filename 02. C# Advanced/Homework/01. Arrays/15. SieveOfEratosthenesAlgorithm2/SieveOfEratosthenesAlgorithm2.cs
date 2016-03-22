using System;
using System.Collections.Generic;
//Problem 15. Prime numbers
//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
class SieveOfEratosthenesAlgorithm2
{
    static void Main()
    {
        //This is much faster.

        //initialize list of integers
        int searchTo = 10000000;
        int?[] numbers = new int?[searchTo - 1];
        int length = numbers.Length;

        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 2;
        }


        //find primes
        int value;
        for (int i = 0; i < length; i++)
        {
            if (numbers[i] == null)
            {
                continue;
            }

            value = (int)numbers[i] * 2;

            while (value <= searchTo)
            {
                numbers[value - 2] = null;
                value += (int)numbers[i];
            }
        }

        //output
        Console.WriteLine("Prime numbers <= {0:N0}:", searchTo);
        for (int i = 0; i < length; i++)
        {
            if (numbers[i] == null)
            {
                continue;
            }
            else
            {
                Console.Write("{0, -9} ", numbers[i]);
            }

        }
        Console.WriteLine('\n');
    }
}