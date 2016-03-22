using System;

//Problem 1. Square root
//Write a program that reads an integer number and calculates and prints its square root.
//If the number is invalid or negative, print Invalid number.
//In all cases finally print Good bye.
//Use try-catch-finally block.
class SquereRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Input a number: ");
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Console.WriteLine("\nResult: {0}", Math.Sqrt(num));
            }
        }
        catch (Exception)
        {
            Console.WriteLine("\nInvalid number.");
        }
        finally
        {
            Console.WriteLine("\nGood Bye.\n");
        }
    }
}