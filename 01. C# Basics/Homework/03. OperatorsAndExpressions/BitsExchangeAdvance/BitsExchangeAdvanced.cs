using System;

class BitsExchangeAdvanced
{
    static void Main()
    {
        Console.Write("Input a number: ");
        uint number = uint.Parse(Console.ReadLine());

        Console.WriteLine("\nThe number in binary: {0}\n", Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.Write("How many bits do you want to exchange: ");
        sbyte bitCount = sbyte.Parse(Console.ReadLine());

        Console.Write("\nStarting bit for frist set: ");
        sbyte firstStart = sbyte.Parse(Console.ReadLine());

        Console.Write("\nStarting bit for second set: ");
        sbyte secondStart = sbyte.Parse(Console.ReadLine());

        //check for out of range
        if (firstStart < 0 || secondStart < 0 || firstStart + bitCount - 1 > 31 || secondStart + bitCount - 1 > 31 || bitCount < 1)
        {
            Console.WriteLine("\nOut of range!\n");
            return;
        }

        //check for overlapping
        if (!(firstStart > secondStart + bitCount - 1 || firstStart + bitCount - 1 < secondStart))
        {
            Console.WriteLine("\nOverlapping!\n");
            return;
        }

        uint[] firstSetValues = new uint[bitCount];
        uint[] secondSetValues = new uint[bitCount];

        uint mask;

        //puts the values of the bits in arrays
        for (int i = 0, countPos = firstStart; i < bitCount; i++, countPos++)
        {
            mask = 1U << countPos;
            firstSetValues[i] = (number & mask) >> countPos;
        }

        for (int i = 0, countPos = secondStart; i < bitCount; i++, countPos++)
        {
            mask = 1U << countPos;
            secondSetValues[i] = (number & mask) >> countPos;
        }

        //changes the value of the bits
        for (int i = 0, countPos = secondStart; i < bitCount; i++, countPos++)
        {
            if (firstSetValues[i] == 0)
            {
                number &= ~(1U << countPos);
            }
            else
            {
                number |= (1U << countPos);
            }
        }

        for (int i = 0, countPos = firstStart; i < bitCount; i++, countPos++)
        {
            if (secondSetValues[i] == 0)
            {
                number &= ~(1U << countPos);
            }
            else
            {
                number |= (1U << countPos);
            }
        }
        
        Console.WriteLine("\nResult in binary: {0}\n", Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("Result in decimal: {0}\n", number);
    }
}