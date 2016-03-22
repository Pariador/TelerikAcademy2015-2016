using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static BigInteger MultiplyDigits(string num)
    {
        BigInteger result = 1;

        for (int i = num.Length - 1; i >= 0; i--)
        {
            if (num[i] != '0')
            {
                result *= int.Parse(num[i].ToString());
            }
        }

        return result;
    }

    static void Main()
    {
        var numbers = new List<string>();
        string line = null;

        line = Console.ReadLine();
        while (line != "END")
        {   
            numbers.Add(line);
            line = Console.ReadLine();
        }

        BigInteger result = 1;
        if (numbers.Count <= 10)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    result *= MultiplyDigits(numbers[i]);
                }
            }

            Console.WriteLine(result);
        }
        else
        {
            BigInteger secondResult = 1;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 != 0)
                {
                    result *= MultiplyDigits(numbers[i]);
                }
            }

            for (int i = 10; i < numbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    secondResult *= MultiplyDigits(numbers[i]);
                }
            }

            Console.WriteLine(result);
            Console.WriteLine(secondResult);
        }
    }
}