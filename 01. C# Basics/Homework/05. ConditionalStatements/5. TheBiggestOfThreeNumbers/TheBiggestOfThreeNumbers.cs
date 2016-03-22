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


        if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", firstNumber);     
        }
        else if(secondNumber >= firstNumber && secondNumber >= thirdNumber)
        {
            Console.WriteLine("\n{0} is the biggest number.\n", secondNumber);
        }
        else
        {
            Console.WriteLine("\n{0} is the biggest number.\n", thirdNumber);
        }
    }
}