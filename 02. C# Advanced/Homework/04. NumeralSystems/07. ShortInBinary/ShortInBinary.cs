using System;

//Problem 8. Binary short
//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
class ShortInBinary
{
    public static void PrintShortToBinary(short number)
    {
        bool negative = false;

        if (number < 0)
        {
            negative = true;
        }

        long hold;

        //if nagative make it positive - 1
        if (negative)
        {
            hold = -(number) - 1;
        }
        else
        {
            hold = number;
        }

        byte[] remainders = new byte[16];

        for (int i = 0; i < 16; i++)
        {

            remainders[i] = (byte)(hold % 2);
            hold /= 2;
        }

        //if negative invert the bit values
        if (negative)
        {
            for (int i = 0; i < 16; i++)
            {
                if (remainders[i] == 0)
                {
                    remainders[i] = 1;
                }
                else
                {
                    remainders[i] = 0;
                }
            }
        }


        //find the last 1 so no usless zeroes are printed
        int lastOnePos = 0;

        for (int i = 15; i >= 0; i--)
        {
            if (remainders[i] == 1)
            {
                lastOnePos = i;
                break;
            }
        }

        //print the number
        Console.WriteLine("\nThe number in binary: ");
        for (int i = lastOnePos; i >= 0; i--)
        {
            Console.Write(remainders[i]);
        }

        Console.WriteLine('\n');
    }
    static void Main()
    {
        short intShort = 0;

        do
        {
            Console.Write("Input an Int16: ");
        } while (!short.TryParse(Console.ReadLine(), out intShort));
        

        PrintShortToBinary(intShort);
    }
}