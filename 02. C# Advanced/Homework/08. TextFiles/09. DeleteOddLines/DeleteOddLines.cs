using System;
using System.IO;
using System.Text;

//Problem 1. Odd lines
//Write a program that reads a text file and prints on the console its odd lines.
class DeleteOddLinesTest
{
    static void DeleteOddLines(string filePath)
    {
        var result = new StringBuilder();

        string line = null;
        int lineCount = 1;
        using (var reader = new StreamReader(filePath))
        {
            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (lineCount % 2 == 0)
                {
                    result.Append(line);
                    result.Append('\n');
                }
                lineCount++;
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

        DeleteOddLines(filePath);

        Console.WriteLine("\nOdd lines deleted.\n");
    }
}