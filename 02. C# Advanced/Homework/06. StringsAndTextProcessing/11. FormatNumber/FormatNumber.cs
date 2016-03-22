using System;

//Problem 11. Format number
//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols.
class FormatNumber
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("\nAs decimal: {0}", num);
        Console.WriteLine("\nAs hexadecimal: {0 :X}", num);
        Console.WriteLine("\nAs percentage: {0 :P}", num);
        Console.WriteLine("\nIn scientific notation: {0 :E}\n", num);
    }
}