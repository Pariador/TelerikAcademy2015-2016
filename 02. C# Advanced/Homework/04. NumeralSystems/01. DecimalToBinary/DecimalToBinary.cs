//Problem 1. Decimal to binary
//Write a program to convert decimal numbers to their binary representation.

namespace PrintIntInBinary
{
    using System;

    public class DecimalToBinary
    {
        public static void PrintIntToBinary(long number)
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

            byte[] remainders = new byte[64];

            for (int i = 0; i < 64; i++)
            {

                remainders[i] = (byte)(hold % 2);
                hold /= 2;
            }

            //if negative invert the bit values
            if (negative)
            {
                for (int i = 0; i < 64; i++)
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

            for (int i = 63; i >= 0; i--)
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
            Console.Write("Input a number of type long in decimal: ");
            long number = long.Parse(Console.ReadLine());

            PrintIntToBinary(number);
        }
    }
}