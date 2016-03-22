using System;

//Problem 2. Random numbers
//Write a program that generates and prints to the console 10 random values in the range [100, 200].
static class RandomNumbersTest
{
    static Random rnd = new Random();

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Random Number {0}: {1}", i + 1, rnd.Next(100, 201));
        }
    }
}