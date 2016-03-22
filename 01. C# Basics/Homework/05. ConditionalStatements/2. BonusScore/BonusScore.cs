using System;

class BonusScore
{
    static void Main()
    {
        Console.Write("Input score: ");
        double score = double.Parse(Console.ReadLine());

        if (score >= 1 && score <= 3)
        {
            Console.WriteLine("\nMultiplied Score: {0}\n", score * 10);
        }
        else if (score >= 4 && score <= 6)
        {
            Console.WriteLine("\nMultiplied Score: {0}\n", score * 100);
        }
        else if (score >= 7 && score <= 9)
        {
            Console.WriteLine("\nMultiplied Score: {0}\n", score * 1000);
        }
        else 
        {
            Console.WriteLine("\nInvalid Score.\n");
        }
    }
}