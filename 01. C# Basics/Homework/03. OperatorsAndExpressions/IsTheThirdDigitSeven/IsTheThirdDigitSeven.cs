using System;

class IsTheThirdDigitSeven
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Is the third digit of the number a 7? {0}", (number / 100) % 10 == 7);
    }
}