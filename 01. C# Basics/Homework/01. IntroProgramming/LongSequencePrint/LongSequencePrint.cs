using System;

class LongSequencePrint
{
    static void Main()
    {
        Console.SetBufferSize(Console.WindowWidth, 1001); //increases the lines that can ve shown from 300 to 1001

        for (int i = 0; i < 1000; i++) //loops 1000 times
        {
            if ((i + 2) % 2 == 0) //checks for even numbers
            {
                Console.WriteLine("Print {0}: {1}", i + 1, i + 2);
            }

            else
            {
                Console.WriteLine("Print {0}: -{1}", i + 1, i + 2);
            }
        }
    }
}