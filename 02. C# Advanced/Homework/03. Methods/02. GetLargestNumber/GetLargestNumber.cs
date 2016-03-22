using System;

//Problem 2. Get largest number
//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
class GetLargestNumber
{
    static int GetMax(int firstNumber, int SecondNumber)
    {
        return firstNumber > SecondNumber ? firstNumber : SecondNumber;
    }

    static void Main()
    {
        Console.Write("Input first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("\nInput second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("\nInput third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        int firstCompare = GetMax(firstNumber, secondNumber);
        int secondCompare = GetMax(firstNumber, thirdNumber);
        int thirdCompare = GetMax(secondNumber, thirdNumber);

        if (firstCompare == secondCompare || firstCompare == thirdCompare)
        {
            Console.WriteLine("\n{0}\n", firstCompare);
        }
        else
        {
            Console.WriteLine("\n{0}\n", thirdCompare);
        }
    }
}