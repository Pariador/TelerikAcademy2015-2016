using System;
using System.Collections.Generic;
//Problem 15. Prime numbers
//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
class SieveOfEratosthenesAlgorithm
{
    static void Main()
    {
        //Using lists and removing elements from them turns out to be way to slow for 10 000 000 numbers.

        //initialize list of integers
        int searchTo = 1000;
        List<int> numbers = new List<int>();

        for (int i = 2; i <= searchTo; i++)
        {
            numbers.Add(i);
        }


        //find primes
        int value;
        for (int i = 0; i < numbers.Count; i++)
        {
            value = numbers[i];

            while (value <= numbers[numbers.Count - 1])
            {
                value += numbers[i];
                numbers.Remove(value);
            }         
        }
        
        //output
        Console.WriteLine("Prime numbers <= {0:N0}:", searchTo);
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write("{0, -8}", numbers[i]);
        }
        Console.WriteLine('\n');
    }
}