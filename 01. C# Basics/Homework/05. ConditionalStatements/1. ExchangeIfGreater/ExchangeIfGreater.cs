using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Input first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            double hold = firstNumber;

            firstNumber = secondNumber;

            secondNumber = hold;

            Console.WriteLine("\nValues exchanged.\n");
        }
        else 
        {
            Console.WriteLine("\nValues not exchanged.\n");
        }

        Console.WriteLine("First Number: {0}\n", firstNumber);
        Console.WriteLine("Second Number: {0}\n", secondNumber);
    }
}