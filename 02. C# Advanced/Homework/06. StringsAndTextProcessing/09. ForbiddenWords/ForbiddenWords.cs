using System;
using System.Text;

//Problem 9. Forbidden words
//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.
class ForbiddenWords
{
    static string ReplaceForbiddenWords(string text, string[] words)
    {
        StringBuilder result = new StringBuilder(text);

        foreach (var word in words)
        {
            result.Replace(word, new String('*', word.Length));
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Input text:");
        string text = Console.ReadLine();

        Console.Write("\nHow many forbidden words do you want: ");
        int wordCount = int.Parse(Console.ReadLine());

        string[] words = new string[wordCount];
        Console.WriteLine("\nInput words:");
        for (int i = 0; i < wordCount; i++)
        {
            Console.Write("Input word {0}: ", i);
            words[i] = Console.ReadLine();
        }

        Console.WriteLine("\nResult:");
        Console.WriteLine("{0}\n", ReplaceForbiddenWords(text, words));
    }
}