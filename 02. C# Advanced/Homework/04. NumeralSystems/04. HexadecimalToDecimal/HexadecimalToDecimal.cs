using System;

//Problem 4. Hexadecimal to decimal
//Write a program to convert hexadecimal numbers to their decimal representation.
class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Input number in hexadecimal: ");
        string hexNumber = Console.ReadLine();

        long totalNumber = 0;

        byte number;
        for (int i = hexNumber.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            if (hexNumber[i] == '0')
            {
                continue;
            }
            else
            {
                if (!byte.TryParse(hexNumber[i].ToString(), out number))
                {
                    switch (hexNumber[i])
                    {
                        case 'A':
                            number = 10;
                            break;
                        case 'B':
                            number = 11;
                            break;
                        case 'C':
                            number = 12;
                            break;
                        case 'D':
                            number = 13;
                            break;
                        case 'E':
                            number = 14;
                            break;
                        case 'F':
                            number = 15;
                            break;
                        default:
                            Console.WriteLine("\nError only case.\n");
                            break;
                    }
                }

                totalNumber += number * (long)Math.Pow(16, pow);
            }
        }

        Console.WriteLine("\nThe number in decimal: {0}\n", totalNumber);
    }
}