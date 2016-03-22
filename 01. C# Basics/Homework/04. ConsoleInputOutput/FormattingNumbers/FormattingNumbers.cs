using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.Write("Input a whole number: ");
        int intNumber = int.Parse(Console.ReadLine());

        Console.Write("\nInput a real number: ");
        double firstRealNumber = double.Parse(Console.ReadLine());

        Console.Write("\nInput a second real number: ");
        double secondRealNumber = double.Parse(Console.ReadLine());

        Console.Write("\n{0,-10:X}|", intNumber);
        Console.Write("{0, 10}|", Convert.ToString(intNumber, 2).PadLeft(10, '0'));
        Console.Write("{0,10:0.00}|", firstRealNumber);
        Console.Write("{0,-10:0.000}|\n\n", secondRealNumber);
    }

}