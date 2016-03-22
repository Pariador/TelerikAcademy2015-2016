using System;

class TrailingZeroesInN
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        //http://www.purplemath.com/modules/factzero.htm

        int maxPowOf5 = 0;

        int result = 1;

        while (result <= number)
        {
            maxPowOf5++;
            result = (int)Math.Pow(5, maxPowOf5);
        }

        maxPowOf5 -= 1;

        int zeroesCount = 0;
        for (int i = 1, hold = number; i <= maxPowOf5; i++)
        {
            zeroesCount += hold / (int)Math.Pow(5, i);
        }

        Console.WriteLine("\nTrailing zeroes of {0}!: {1}\n", number, zeroesCount);
    }
}