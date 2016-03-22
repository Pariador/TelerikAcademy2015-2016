using System;
using System.IO;

//Problem 4. Compare text files
//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines.
class CompareTextFiles
{
    static void Main()
    {
        Console.Write("Input first file path: ");
        string firstFilePath =  Console.ReadLine();

        Console.Write("\nInput second file path: ");
        string secondFilePath = Console.ReadLine();

        int sameLines = 0;
        int differentLines = 0;
        string firstLine = null;
        string secondLine = null;
        using(var firstReader = new StreamReader(firstFilePath))
        {
            using (var secondReader = new StreamReader(secondFilePath))
            {
                while (true)
                {
                    firstLine = firstReader.ReadLine();
                    secondLine = secondReader.ReadLine();
                    if (firstLine == null || secondLine == null)
                    {
                        break;
                    }

                    if (firstLine == secondLine)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                }
            }
        }

        Console.WriteLine("\nSame lines: {0}\nDifferent line: {1}\n", sameLines, differentLines);
    }
}