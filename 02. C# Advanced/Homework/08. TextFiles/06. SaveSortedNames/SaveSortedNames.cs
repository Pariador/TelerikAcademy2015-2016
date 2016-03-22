using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

//Problem 6. Save sorted names
//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
class SaveSortedNamesTest
{
    static void Main()
    {
        Console.Write("Enter input file path: ");
        string inputPath =Console.ReadLine();

        var strings = new List<string>();
        using (var reader = new StreamReader(inputPath))
        {
            string line = null;
            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                strings.Add(line.Trim(new char[]{' ', '\n'}));
            }
        }

        strings.Sort();

        var result = new StringBuilder();
        foreach (var str in strings)
        {
            result.Append(str);
            result.Append('\n');
        }

        using (var writer = new StreamWriter(@"..\..\output.txt"))
        {
            writer.Write(result.ToString().TrimEnd());
        }

        Console.WriteLine("\nOutput file ready.\n");
    }
}