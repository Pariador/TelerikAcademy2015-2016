using System;

class RandomizeNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Randomize numbers from 1 to : ");
        int num = int.Parse(Console.ReadLine());

        int?[] array = new int?[num];

        for (int i = 0; i < num; i++)
        {
            array[i] = i + 1;
        }

        Random rnd = new Random();

        Console.WriteLine("\nRandom number series:");

        //randoms indexes until it gets them all
        for (int count = 0, index; count < num; count++)
        {
            do
            {
                index = rnd.Next(0, num);
            } while (array[index] == null);

            Console.Write("{0} ", array[index]);
            array[index] = null;
        }

        Console.WriteLine('\n');
    }
}