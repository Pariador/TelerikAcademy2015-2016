using System;

class BeerTime
{
    static void Main()
    {
        Console.Write("Input a time: ");
        DateTime time = DateTime.Parse(Console.ReadLine());

        //Check if beer time.
        if (time.Hour >= 13 || time.Hour < 3)
        {
            Console.WriteLine("\nBEER TIME!!!\n");
        }
        else 
        {
            Console.WriteLine("\nNon-beer time. :(\n");
        }
    }
}