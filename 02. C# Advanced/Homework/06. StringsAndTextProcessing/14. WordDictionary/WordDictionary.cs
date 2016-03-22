using System;
using System.Linq;
using System.Collections.Generic;

//Problem 14. Word dictionary
//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary.
class WordDictionary
{
    static void Main()
    {
        var dictionary = new Dictionary<string, string>();
        dictionary.Add(".NET", "platform for applications from Microsoft");
        dictionary.Add("CLR", "managed execution environment for .NET");
        dictionary.Add("namespace", "hierarchical organization of classes");

        Console.Write("1. Use default dictionary.\n2. Make new dictionary.\nElse exit.\n\nInput: ");
        string answer = Console.ReadLine();
        if (answer == "2")
        {
            dictionary.Clear();
            Console.Write("\nHow many enries do you want: ");
            int entrieCount = int.Parse(Console.ReadLine());
            string entrie = null;
            string definition = null;

            for (int i = 0; i < entrieCount; i++)
            {
                Console.Write("\nEntrie: ");
                entrie = Console.ReadLine();
                Console.Write("Definition: ");
                definition = Console.ReadLine();
                dictionary.Add(entrie, definition);
            }
        }
        else if (answer != "1")
        {
            Console.WriteLine();
            return;
        }

        Console.Write("\nSearch dictionary for: ");
        string query = Console.ReadLine();

        if (String.IsNullOrEmpty(query))
        {
            Console.WriteLine("\nYou have entered no query.\n");
            return;
        }

        var result = dictionary.FirstOrDefault(x => x.Key == query);

        if (result.Value == null)
        {
            Console.WriteLine("\nNot found.\n");
        }
        else
        {
            Console.WriteLine("\nDefinition:");
            Console.WriteLine("{0}\n", result.Value);
        }
    }
}