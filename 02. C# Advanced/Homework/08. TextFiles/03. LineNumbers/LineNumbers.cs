using System;
using System.Text;
using System.IO;

//Problem 3. Line numbers
//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.
class LineNumbersTest
{
    static void NumberLines(string filePath)
    {
        var result = new StringBuilder();

        string line = null;
        int lineCount = 1;
        using(var reader = new StreamReader(filePath))
        {
            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                result.Append(String.Format("{0}. ", lineCount));
                result.Append(String.Format("{0}\n", line));
                lineCount++;
            }
        }

        using(var writer = new StreamWriter("NumberedFile.txt"))
        {
            writer.Write(result.ToString().TrimEnd(new char[]{' ', '\n'}));
        }
    }

    static void Main()
    {
        Console.Write("Input file path: ");
        string path = @"..\..\Read.txt";//Console.ReadLine();

        NumberLines(path);

        Console.WriteLine("\nFile numbered.\nThe result is in the same directory as the .exe.\n");
    }
}