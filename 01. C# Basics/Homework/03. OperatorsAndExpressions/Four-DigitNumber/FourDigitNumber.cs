using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Input a four digit number: "); 
        int number = int.Parse(Console.ReadLine());

        int[] digits = new int[4];

        for (int i = 0; i < 4; i++)
        {
            digits[i] = number % 10;

            number /= 10;
        }

        Console.WriteLine("\nThe sum of its digits is: {0}\n", digits[0] + digits[1] + digits[2] + digits[3]);

        Console.WriteLine("The number in reverse: {0}{1}{2}{3}\n", digits[0], digits[1], digits[2], digits[3]);

        Console.WriteLine("Last digit in first position: {0}{1}{2}{3}\n", digits[0], digits[3], digits[2], digits[1]);

        Console.WriteLine("Middle digits exchanged: {0}{1}{2}{3}\n", digits[3], digits[1], digits[2], digits[0]);
    }
}