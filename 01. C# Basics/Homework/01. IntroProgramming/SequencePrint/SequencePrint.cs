using System;

class SequencePrint
{
    static void Main()
    {
        for (int i = 0; i < 10; i++) //loops 10 times
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