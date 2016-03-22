using System;

class BitsExchange
{
    static void Main()
    {
        Console.Write("Input a number: ");
        uint number = uint.Parse(Console.ReadLine());

        Console.WriteLine("\nThe number in binary: {0}\n", Convert.ToString(number, 2).PadLeft(32, '0'));

        uint[] bitValues = new uint[6];


        uint mask = 1 << 3;
        bitValues[0] = (number & mask) >> 3;

        mask = 1 << 4;
        bitValues[1] = (number & mask) >> 4;

        mask = 1 << 5;
        bitValues[2] = (number & mask) >> 5;
        
        mask = 1 << 24;
        bitValues[3] = (number & mask) >> 24;

        mask = 1 << 25;
        bitValues[4] = (number & mask) >> 25;

        mask = 1 << 26;
        bitValues[5] = (number & mask) >> 26;


        if (bitValues[0] == 0)
        {
            number &= ~(1U << 24);
        }
        else
        {
            number |= (1U << 24);
        }

        if (bitValues[1] == 0)
        {
            number &= ~(1U << 25);
        }
        else
        {
            number |= (1U << 25);
        }

        if (bitValues[2] == 0)
        {
            number &= ~(1U << 26);
        }
        else
        {
            number |= (1U << 26);
        }

        if (bitValues[3] == 0)
        {
            number &= ~(1U << 3);
        }
        else
        {
            number |= (1U << 3);
        }

        if (bitValues[4] == 0)
        {
            number &= ~(1U << 4);
        }
        else
        {
            number |= (1U << 4);
        }

        if (bitValues[5] == 0)
        {
            number &= ~(1U << 5);
        }
        else
        {
            number |= (1U << 5);
        }

        Console.WriteLine("Result in binary: {0}\n", Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("Result in decimal: {0}\n", number);
    }
}