using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

class ProblemOne
{
    static void Main()
    {
        var buider = new StringBuilder();
        string[] words = Console.ReadLine().Split(new char[]{' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries);
        BigInteger[] decimalNumbers = new BigInteger[words.Length];
        string[] result = new string[words.Length];

        BigInteger number = 0;

        for (int i = 0; i < words.Length; i++)
        {
            for (int digit = words[i].Length - 1, power = 0; digit >= 0; digit--, power++)
            {
                number += (words[i][digit] - 'a') * (BigInteger)Math.Pow(17, power);
            }

            decimalNumbers[i] = number;
            number = 0;
        }

        //decimalNumbers[0] = 18446744073709551615;
        BigInteger remainder = 0;
        for (int i = 0; i < decimalNumbers.Length; i++)
        {
            while (decimalNumbers[i] != 0)
            {
                remainder = decimalNumbers[i] % 26;
                decimalNumbers[i] /= 26;
                buider.Insert(0, (char)(remainder + 'a'));
            }
            

            result[i] = buider.ToString();
            buider.Clear();
            //strBuilder.Insert(0, ' ');
            remainder = 0;
        }
        //strBuilder.Remove(0, 1);

        //for (int i = 0; i < result.Length; i++)
        //{
        //    Console.Write(result[i]);
        //    if (i != result.Length - 1)
        //    {
        //        Console.Write(' ');
        //    }

        //}

        foreach (var num in result)
        {
            buider.Append(num);
            buider.Append(' ');
        }
        buider.Remove(buider.Length - 1, 1);
        Console.WriteLine(buider.ToString());
    }
}