using System;
using System.IO;
using System.Text;

//Problem 2. Concatenate text files
//Write a program that concatenates two text files into another text file.
class ConcatenameTextFilesTest
{
    static void ConcatenateTextFiles(params string[] textFiles)
    {
        var result = new StringBuilder();

        using (var reader = new StreamReader(textFiles[0]))
        {
            result.Append(reader.ReadToEnd());
        }
        for (int i = 1; i < textFiles.Length; i++)
        {
            using (var reader = new StreamReader(textFiles[i]))
            {
                result.Append('\n');
                result.Append(reader.ReadToEnd());
            }
        }

        using(var writer = new StreamWriter("ConcatenatedTextFiles.txt"))
        {
            writer.Write(result.ToString());
        }
    }

    static void Main()
    {
        //should work for any number of text files
        ConcatenateTextFiles(@"..\..\FirstTextFile.txt", @"..\..\SecondTextFile.txt");
        Console.WriteLine("Files concatenated.\nThe result is in the same directory as the .exe.\n");
    }
}