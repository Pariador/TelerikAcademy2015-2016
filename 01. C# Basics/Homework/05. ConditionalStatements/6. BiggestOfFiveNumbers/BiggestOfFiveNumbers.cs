using System;

class TheBiggestOfThreeNumbers
{
    static void Main()
    {
        Console.Write("Input first real numver: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput second real numver: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput third real numver: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput forth real numver: ");
        double forthNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput fifth real numver: ");
        double fifthNumber = double.Parse(Console.ReadLine());


        if (firstNumber >= secondNumber && firstNumber >= thirdNumber && firstNumber >= forthNumber && firstNumber >= fifthNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", firstNumber);
        }
        else if (secondNumber >= firstNumber && secondNumber >= thirdNumber && secondNumber >= forthNumber && secondNumber >= fifthNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", secondNumber);
        }
        else if (thirdNumber >= firstNumber && thirdNumber >= secondNumber && thirdNumber >= forthNumber && thirdNumber >= fifthNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", thirdNumber);
        }
        else if (forthNumber >= firstNumber && forthNumber >= secondNumber && forthNumber >= thirdNumber && forthNumber >= fifthNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", forthNumber);
        }
        else
        {
            Console.WriteLine("\n{0} is the biggest number.\n", fifthNumber);
        }
    }
}