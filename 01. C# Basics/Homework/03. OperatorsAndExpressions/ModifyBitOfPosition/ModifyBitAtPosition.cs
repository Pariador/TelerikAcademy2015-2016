using System;

class ModifyBitAtPosition
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\nThe number in binary:\n{0}", Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.Write("\nIndex of bit to change: "); 
        byte index = byte.Parse(Console.ReadLine());

        Console.Write("\nChage bit value to: ");
        byte value = byte.Parse(Console.ReadLine());

        if (value == 0)
        {
            number &= ~(1 << index);
        }
        else
        {
            number |= 1 << index;
        }

        Console.WriteLine("\nThe number has been changed to:\n\nBinary:\n{0}\n\nDecimal: {1}\n", Convert.ToString(number, 2).PadLeft(32, '0'), number);
    }
}