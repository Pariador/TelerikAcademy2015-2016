using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Input a number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput a second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine("\nThe geater one of the two is: {0}\n", firstNumber > secondNumber? firstNumber : secondNumber);
    }
        
}