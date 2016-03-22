using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("\nIndex of bit position to check: ");
        byte index = byte.Parse(Console.ReadLine());

        int mask = 1 << index;

        int check = (number & mask) >> index;

        Console.WriteLine("\nThe value of bit #3 of the number is {0}.\n", check);
    }
}