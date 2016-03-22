using System;
using System.Text;

class DirectHexToBinary
{
    static string HexToBinary(string hex)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex[i].ToString().ToLower())
            {
                case "0":
                    result.Append("0000");
                    break;
                case "1":
                    result.Append("0001");
                    break;
                case "2":
                    result.Append("0010");
                    break;
                case "3":
                    result.Append("0011");
                    break;
                case "4":
                    result.Append("0100");
                    break;
                case "5":
                    result.Append("0101");
                    break;
                case "6":
                    result.Append("0110");
                    break;
                case "7":
                    result.Append("0111");
                    break;
                case "8":
                    result.Append("1000");
                    break;
                case "9":
                    result.Append("1001");
                    break;
                case "a":
                    result.Append("1010");
                    break;
                case "b":
                    result.Append("1011");
                    break;
                case "c":
                    result.Append("1100");
                    break;
                case "d":
                    result.Append("1101");
                    break;
                case "e":
                    result.Append("1110");
                    break;
                case "f":
                    result.Append("1111");
                    break;
                default:
                    Console.WriteLine("\nERROR SWITCH HEX TO BINARY!!!\n");
                    break;
            }
        }

        return result.ToString();
    }
    static void Main()
    {
        Console.Write("Input number in Hex: ");
        string hex = Console.ReadLine();

        Console.WriteLine("{0}\n", HexToBinary(hex));
    }
}