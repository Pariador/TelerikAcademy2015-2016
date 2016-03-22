using System;

//Problem 3. English digit
//Write a method that returns the last digit of given integer as an English word.
class EnglishDigit
{
    static string LastDigitAsWord(int number)
    {
        if (number < 0)
        {
            number = -(number);
        }

        int lastDigit = number % 10;

        switch (lastDigit)
        {
            case 0:
                return "Zero";
            case 1:
                return "One";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            default:
                return "Error LastDigitWord Switch";
        }
    }
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\nThe last digit in {0} is: {1}\n", number, LastDigitAsWord(number));
    }
}