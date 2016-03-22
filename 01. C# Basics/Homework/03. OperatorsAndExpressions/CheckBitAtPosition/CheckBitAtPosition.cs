using System;

class CheckBitAtPosition
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("\nIdex of bit position to check: ");
        byte index = byte.Parse(Console.ReadLine());

        int mask = 1 << index;

        int check = (number & mask) >> index;

        Console.WriteLine("\nIs the value of the value of that bit 1?: {0}\n", check == 1 ? true : false);
    }
}