using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        Console.Write("Input first real numver: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput second real numver: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput third real numver: ");
        double thirdNumber = double.Parse(Console.ReadLine());


        Console.WriteLine("\nDiscending Order:");

        if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
        {
            Console.WriteLine(firstNumber);

            if (secondNumber >= thirdNumber)
            {
                Console.WriteLine(secondNumber);
                Console.WriteLine("{0}\n", thirdNumber);
            }
            else 
            {
                Console.WriteLine(thirdNumber);
                Console.WriteLine("{0}\n", secondNumber);
            }
        }
        else if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
        {
            Console.WriteLine(secondNumber);

            if (firstNumber >= thirdNumber)
            {
                Console.WriteLine(firstNumber);
                Console.WriteLine("{0}\n", thirdNumber);
            }
            else
            {
                Console.WriteLine(thirdNumber);
                Console.WriteLine("{0}\n", firstNumber);
            }
        }
        else
        {
            Console.WriteLine(thirdNumber);

            if (firstNumber >= secondNumber)
            {
                Console.WriteLine(firstNumber);
                Console.WriteLine("{0}\n", secondNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
                Console.WriteLine("{0}\n", firstNumber);
            }
        }
    }
}