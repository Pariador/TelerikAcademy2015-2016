using System;
using System.IO;

//Problem 1. Odd lines
//Write a program that reads a text file and prints on the console its odd lines.
class OddLines
{
    static void Main()
    {
        Console.Write("Input file path: ");
        string path = Console.ReadLine();

        string line = null;

        int lineCount = 1;
        using (var reader = new StreamReader(path))
        {
            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (lineCount % 2 != 0)
                {
                    Console.WriteLine("Line {0}: {1}", lineCount, line);
                }
                lineCount++;
            }
        }
        
    }
}