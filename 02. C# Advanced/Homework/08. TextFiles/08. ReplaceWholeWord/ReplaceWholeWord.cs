using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

//Problem 8. Replace whole word
//Modify the solution of the previous problem to replace only whole words (not strings).
class ReplaceWholeWordTest
{
    static void ReplaceAllWords(string start, string replacement, string filePath)
    {
        var result = new StringBuilder();

        string line = null;
        using (var reader = new StreamReader(filePath))
        {
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = ReplaceWords(start, replacement, line);

                result.Append(line);
                result.Append('\n');
            }
        }

        using (var writer = new StreamWriter(filePath))
        {
            writer.Write(result.ToString().TrimEnd(new char[] { ' ', '\n' }));
        }
    }

    static string ReplaceWords(string start, string replacement, string text)
    {
        var words = new Queue<string>();
       // var betweenWords = new Queue<string>();
        var builder = new StringBuilder();
        char[] nonWordChars= {' ', ',', '!', '?', '.', '\n', '\t'};
       // bool wordFirst = true;
        //bool firstTime = true;

        for (int i = 0; i < text.Length; i++)
        {
            if (nonWordChars.Contains(text[i]))
            {
                if (builder.Length != 0)
	            {
		            words.Enqueue(builder.ToString());
                    builder.Clear();
	            }

                while (i < text.Length && nonWordChars.Contains(text[i]))
                {
                    builder.Append(text[i]);
                    i++;
                }
                words.Enqueue(builder.ToString());
                builder.Clear();
            }

            if (i < text.Length)
            {
                builder.Append(text[i]);
            }
        }
        if (builder.Length != 0)
	    {
		    words.Enqueue(builder.ToString());
            builder.Clear();
	    }

        foreach (var word in words)
        {
            if (word == start)
            {
                builder.Append(replacement);
            }
            else
            {
                builder.Append(word);
            }
        }

        return builder.ToString();
    }
            
    static void Main()
    {
        Console.Write("Input file path: ");
        string filePath = Console.ReadLine();

        Console.Write("\nInput word to replace: ");
        string start = Console.ReadLine();

        Console.Write("\nInput replacement word: ");
        string replacement = Console.ReadLine();

        ReplaceAllWords(start, replacement, filePath);

        Console.WriteLine("\nReplacement complete.\n");
    }
}