using System;
using System.Linq;

//Problem 24. Order words
//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
class OrderWordsTest
{
    static void Main()
    {
        Console.WriteLine("Input words separated by space:");
        string input = Console.ReadLine();

        string[] words = input.Trim().Split(' ');

        var result = words.OrderBy(x => x);

        Console.WriteLine("Result:");
        foreach (var word in result)
	    {
            Console.WriteLine(word);
	    }
        Console.WriteLine();
    }
}