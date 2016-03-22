using System;

class ExtractBit3
{
    static void Main()
    {
        Console.Write("Input a number: ");
        uint number = uint.Parse(Console.ReadLine());

        uint mask = 1U << 3;

        uint check = (number & mask) >> 3;

        Console.WriteLine("\nThe value of bit #3 of the number is {0}.\n", check);
    }
}