using System;
using System.Text;

//Problem 2. Reverse string
//Write a program that reads a string, reverses it and prints the result at the console.
//Example:
//input	    output
//sample	elpmas
class ReverseStringTest
{
    static string ReverseString(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Input a string: ");
        string str = Console.ReadLine();

        Console.WriteLine("\nThe string in reverse: {0}\n", ReverseString(str));
    }
}