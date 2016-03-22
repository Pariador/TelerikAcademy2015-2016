using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Input a number of type long in decimal: ");
        long number = long.Parse(Console.ReadLine());

        //The program is the same as 14. DecimalToBinary, but at the end the number is printed as hexadecimal from binary

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

        //go through the binary number and print it in hexadecimal

        while ((lastOnePos + 1) % 4 != 0)
        {
            lastOnePos++;
        }

        Console.WriteLine("\nThe number in hex: ");
        for (int i = lastOnePos; i >= 0; i -= 4)
        {
            byte total = 0;

            for (int q = i, pow = 3; q > i - 4; q--, pow--)
            {
                if (remainders[q] == 0)
	            {   
		            continue;
	            }
                else
                {
                    total += (byte) Math.Pow(2, pow);
                }
            }

            if (total > 9)
            {
                switch (total)
                {
                    case 10:
                        Console.Write('A');
                        break;
                    case 11:
                        Console.Write('B');
                        break;
                    case 12:
                        Console.Write('C');
                        break;
                    case 13:
                        Console.Write('D');
                        break;
                    case 14:
                        Console.Write('E');
                        break;
                    case 15:
                        Console.Write('F');
                        break;
                    default:
                        Console.WriteLine("\nError in swtich.\n");
                        break;
                }
            }
            else 
            {
                Console.Write(total);
            }
        }

        Console.WriteLine('\n');
    }
}