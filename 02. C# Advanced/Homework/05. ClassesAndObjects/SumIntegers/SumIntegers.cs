using System;

//Problem 6. Sum integers
//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.
class SumIntegers
{
    static int SumIntStr(string numbersStr)
    {
        int result = 0;

        string[] numbers = numbersStr.Split(' ');
        int length = numbers.Length;

        for (int i = 0; i < length; i++)
        {
            result += int.Parse(numbers[i]);
        }

        return result;
    }
    static void Main()
    {
        Console.Write("Enter ints seperated by space: ");
        string numbersStr = Console.ReadLine();

        Console.WriteLine("\nSum: {0}\n", SumIntStr(numbersStr));
    }
}