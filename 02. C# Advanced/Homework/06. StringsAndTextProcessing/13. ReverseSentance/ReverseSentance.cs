using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

//Problem 13. Reverse sentence
//Write a program that reverses the words in given sentence.
class ReverseSentance
{
    static string ReverseSentace(string sentance)
    {
        var builder = new StringBuilder();
        var punctuation = new Queue<string>();
        var words = new Stack<string>();
        char[] symbols = {' ', '.', '!', '?'};

        builder.Append((char)(sentance[0] + ' '));
        for (int i = 1; i < sentance.Length; i++)
        {
            if (symbols.Contains(sentance[i]))
            {
                words.Push(builder.ToString());
                punctuation.Enqueue(sentance[i].ToString());
                builder.Clear();
                continue;
            }
            else if (sentance[i] == ',')
            {
                words.Push(builder.ToString());
                punctuation.Enqueue(", ");
                builder.Clear();
                i += 2;
            }

            builder.Append(sentance[i]);
        }

        foreach (var word in words)
        {
            builder.Append(word);
            builder.Append(punctuation.Dequeue());
        }

        builder[0] = (char)(builder[0] - ' ');
        return builder.ToString();
    }

    static void Main()
    {
        Console.Write("Input a sentance: ");
        string sentance = Console.ReadLine();

        sentance = ReverseSentace(sentance);

        Console.WriteLine("\nThe sentance reversed:");
        Console.WriteLine("{0}\n", sentance);
    }
}