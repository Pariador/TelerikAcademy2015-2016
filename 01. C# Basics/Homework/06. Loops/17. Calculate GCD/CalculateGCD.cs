using System;

class CalculateGCD
{
    static void Main()
    {
        Console.Write("Input first number: ");
        int divident = int.Parse(Console.ReadLine());

        Console.Write("\nInput second number: ");
        int divisor = int.Parse(Console.ReadLine());



        if (divident < 0)
        {
            divident = -(divident);
        }

        if (divisor < 0)
        {
            divisor = -(divisor);
        }



        int hold;

        if (divident < divisor)
        {
            hold = divident;
            divident = divisor;
            divisor = hold;
        }


        do
        {
            hold = divisor;
            divisor = divident % divisor;
            divident = hold;
        } while (divisor != 0);

        Console.WriteLine("\nGCD: {0}\n", divident);
    }
}