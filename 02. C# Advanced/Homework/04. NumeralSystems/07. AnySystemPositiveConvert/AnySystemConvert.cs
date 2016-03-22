using System;
using System.Text;

//Problem 7. One system to any other
//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).
class AnySystemConvert
{
    static int ToDecimal(string number, int numBase)
    {
        int result = 0;

        for (int i = number.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            switch (number[i].ToString().ToLower())
            {
                case "0":
                    continue;
                case "1":
                    result += 1 * (int)Math.Pow(numBase, pow);
                    break;
                case "2":
                    result += 2 * (int)Math.Pow(numBase, pow);
                    break;
                case "3":
                    result += 3 * (int)Math.Pow(numBase, pow);
                    break;
                case "4":
                    result += 4 * (int)Math.Pow(numBase, pow);
                    break;
                case "5":
                    result += 5 * (int)Math.Pow(numBase, pow);
                    break;
                case "6":
                    result += 6 * (int)Math.Pow(numBase, pow);
                    break;
                case "7":
                    result += 7 * (int)Math.Pow(numBase, pow);
                    break;
                case "8":
                    result += 8 * (int)Math.Pow(numBase, pow);
                    break;
                case "9":
                    result += 9 * (int)Math.Pow(numBase, pow);
                    break;
                case "a":
                    result += 10 * (int)Math.Pow(numBase, pow);
                    break;
                case "b":
                    result += 11 * (int)Math.Pow(numBase, pow);
                    break;
                case "c":
                    result += 12 * (int)Math.Pow(numBase, pow);
                    break;
                case "d":
                    result += 13 * (int)Math.Pow(numBase, pow);
                    break;
                case "e":
                    result += 14 * (int)Math.Pow(numBase, pow);
                    break;
                case "f":
                    result += 15 * (int)Math.Pow(numBase, pow);
                    break;
                default:
                    Console.WriteLine("ERROR ToDecimal() SWITCH!!!");
                    break;
            }
        }

        return result;
    }
    static string FromDecimal(int number, int numBase)
    {
        StringBuilder result = new StringBuilder();

        int digit = 0;

        while (number != 0)
        {
            digit = number % numBase;
            number /= numBase;

            if (digit < 10)
            {
                result.Insert(0, digit);
            }
            else
            {
                switch (digit)
                {
                    case 10:
                        result.Insert(0, 'a');
                        break;
                    case 11:
                        result.Insert(0, 'b');
                        break;
                    case 12:
                        result.Insert(0, 'c');
                        break;
                    case 13:
                        result.Insert(0, 'd');
                        break;
                    case 14:
                        result.Insert(0, 'e');
                        break;
                    case 15:
                        result.Insert(0, 'f');
                        break;
                    default:
                        Console.WriteLine("\nERROR FromDecimal() SWITCH!!!\n");
                        break;
                }
            }
        }


        return result.ToString();
    }

    static void Main()
    {
        //Works for positve 32 bit nubmers.

        Console.Write("Base of input (2 <= base <= 16): ");
        int inputBase = int.Parse(Console.ReadLine());

        Console.Write("\nInput: ");
        string number = Console.ReadLine();

        Console.Write("\nBase of output (2 <= base <= 16): ");
        int outputBase = int.Parse(Console.ReadLine());


        Console.WriteLine("\nThe number in base {0}: {1}\n", outputBase, FromDecimal(ToDecimal(number, inputBase), outputBase));
    }
}