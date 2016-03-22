using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\n{0} can be devided by both 7 and 5?: {1}\n", number, number % 5 == 0 && number % 7 == 0);
    }
}