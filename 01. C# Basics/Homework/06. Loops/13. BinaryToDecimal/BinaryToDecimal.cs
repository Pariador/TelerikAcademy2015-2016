using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Input number in binary: ");
        string binaryNumber = Console.ReadLine();

        long totalNumber = 0;

        for (int i = binaryNumber.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            if (binaryNumber[i] == '0')
            {
                continue;
            }
            else
            {
                totalNumber += (long) Math.Pow(2, pow);
            }
        }

        Console.WriteLine("\nThe number in decimal: {0}\n", totalNumber);
    }
}