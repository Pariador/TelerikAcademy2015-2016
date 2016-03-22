using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.Write("Input First Number: ");
        double numOne = double .Parse(Console.ReadLine());

        Console.Write("\nInput Second Number: ");
        double numTwo = double .Parse(Console.ReadLine());

        Console.Write("\nInput Third Number: ");
        double numThree = double .Parse(Console.ReadLine());

        Console.WriteLine("\nThe sum of the three numbers is: {0}\n", numOne + numTwo + numThree);
    }
}