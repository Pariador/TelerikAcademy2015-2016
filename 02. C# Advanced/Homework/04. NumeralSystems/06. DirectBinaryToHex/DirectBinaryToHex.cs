using System;
using System.Text;

//Problem 6. binary to hexadecimal
//Write a program to convert binary numbers to hexadecimal numbers (directly).
class DirectBinaryToHex
{
    static string BinaryToHex(string binaryNum)
    {
        StringBuilder result = new StringBuilder();

        int length = binaryNum.Length;

        if (length % 4 != 0)
        {
            StringBuilder zeroPadded = new StringBuilder();
            zeroPadded.Append(binaryNum);

            while (zeroPadded.Length % 4 != 0)
            {
                zeroPadded.Insert(0, '0');
            }

            binaryNum = zeroPadded.ToString();
        }

        StringBuilder hexDigit = new StringBuilder();

        for (int i = 0; i < length - 2; i += 4)
        {
            for (int j = 0; j < 4; j++)
            {
                hexDigit.Append(binaryNum[i  + j]);
            }

            switch (hexDigit.ToString())
            {
                case "0000":
                    result.Append('0');
                    break;
                case "0001":
                    result.Append('1');
                    break;
                case "0010":
                    result.Append('2');
                    break;
                case "0011":
                    result.Append('3');
                    break;
                case "0100":
                    result.Append('4');
                    break;
                case "0101":
                    result.Append('5');
                    break;
                case "0110":
                    result.Append('6');
                    break;
                case "0111":
                    result.Append('7');
                    break;
                case "1000":
                    result.Append('8');
                    break;
                case "1001":
                    result.Append('9');
                    break;
                case "1010":
                    result.Append('a');
                    break;
                case "1011":
                    result.Append('b');
                    break;
                case "1100":
                    result.Append('c');
                    break;
                case "1101":
                    result.Append('d');
                    break;
                case "1110":
                    result.Append('e');
                    break;
                case "1111":
                    result.Append('f');
                    break;
                default:
                    Console.WriteLine("\nERROR BinaryToHex() SWITCH!!!\n");
                    break;
            }

            hexDigit.Clear();
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Input a number in binary: ");
        string binaryNum  = Console.ReadLine();

        Console.WriteLine("{0}\n", BinaryToHex(binaryNum));
    }
}