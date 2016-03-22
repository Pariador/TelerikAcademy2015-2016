using System;
using System.Text;
using System.Collections.Generic;

//Problem 10. Unicode characters
//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.
class UnicodeCharactersTest
{
    static void Main()
    {
        Console.Write("Input a string: ");
        string str = Console.ReadLine();

        if (String.IsNullOrEmpty(str))
	    {
		    Console.WriteLine("\nString can not be empty or null.\n");
	    }

        var result = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            result.Append("\\u");
            result.Append(((short)str[i]).ToString("X").PadLeft(4, '0'));
        }

        Console.WriteLine("Result:");
        Console.WriteLine("{0}\n", result);
    }
}