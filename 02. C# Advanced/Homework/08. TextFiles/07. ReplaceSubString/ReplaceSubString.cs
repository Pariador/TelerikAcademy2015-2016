using System;
using System.IO;
using System.Text;

//Problem 7. Replace sub-string
//Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
//Ensure it will work with large files (e.g. 100 MB).
class ReplaceSubStringTest
{
    static void ReplaceAll(string start, string replacement, string filePath)
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

                line = line.Replace(start, replacement);

                result.Append(line);
                result.Append('\n');
            }
        }

        using (var writer = new StreamWriter(filePath))
        {
            writer.Write(result.ToString().TrimEnd(new char[]{' ', '\n'}));
        }
    }

    static void Main()
    {
        Console.Write("Input file path: ");
        string filePath = Console.ReadLine();

        Console.Write("\nInput string to replace: ");
        string start = Console.ReadLine();

        Console.Write("\nInput replacement string: ");
        string replacement = Console.ReadLine();

        ReplaceAll(start, replacement, filePath);

        Console.WriteLine("\nReplacement complete.\n");
    }
}