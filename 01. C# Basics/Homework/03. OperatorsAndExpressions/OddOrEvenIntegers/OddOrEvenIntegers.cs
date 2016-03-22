using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\nOdd?: {0}\n", number % 2 == 0 ? false : true);
    }
}