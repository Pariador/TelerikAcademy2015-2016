using System;

class MultiplicationSign
{
    static void Main()
    {
        Console.Write("Input first real numver: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput second real numver: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput third real numver: ");
        double thirdNumber = double.Parse(Console.ReadLine());


        double result = firstNumber * secondNumber * thirdNumber;

        if (result < 0)
        {
            Console.WriteLine("\nResult: -\n");
        }
        else if (result > 0)
        {
            Console.WriteLine("\nResult: +\n");
        }
        else
        {
            Console.WriteLine("\nResult: 0\n");
        }
    }
}