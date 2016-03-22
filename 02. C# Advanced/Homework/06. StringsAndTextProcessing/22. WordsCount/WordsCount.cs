using System;
using System.Linq;
using System.Collections.Generic;

//Problem 22. Words count
//Write a program that reads a string from the console and 
//lists all different words in the string along with information how many times each word is found.
class WordsCountTest
{
    static Dictionary<string, int> WordsCount(string str)
    {
        string[] allWords = str.Split(new char[] { ' ', '.', ',', '!', '?', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
        var uniqueWords = new HashSet<string>();

        foreach (var word in allWords)
        {
            uniqueWords.Add(word);
        }

        var wordsAndCounts = new Dictionary<string, int>();

        foreach (var word in uniqueWords)
        {
            wordsAndCounts.Add(word, allWords.Count(x => x == word));
        }

        return wordsAndCounts;
    }

    static void Main()
    {
        //The search is case sensitive.
        Console.WriteLine("Input string:");
        string str = Console.ReadLine();

        Dictionary<string, int> result = WordsCount(str);

        Console.WriteLine("\nResult:");
        foreach (var word in result)
        {
            Console.WriteLine("{0}: {1}", word.Key, word.Value);
        }
        Console.WriteLine();
    }
}