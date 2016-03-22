using System;
using System.IO;
using System.Text;

//Problem 10. Extract text from XML
//Write a program that extracts from given XML file all the text without the tags.
class ExtractTextFromXML
{
    static void Main()
    {
        Console.Write("Input file path: ");
        string filePath = Console.ReadLine();
        StringBuilder result;
        using (var reader = new StreamReader(filePath))
        {
            result = new StringBuilder(reader.ReadToEnd());
        }

        int tagLength = 0;
        int tagStart = 0;
        int index = 0;
        while (true)
        {
            tagStart = result.ToString().IndexOf('<', 0);
            if (tagStart == -1)
            {
                break;
            }

            index = tagStart;
            while (true)
            {
                tagLength++;
                index++;
                if (index >= result.Length)
                {
                    break;
                }
                else if (result[index] == '>')
                {
                    tagLength++;
                    break;
                }
                
            }

            result.Remove(tagStart, tagLength);
            tagLength = 0;
        }

        using (var writer = new StreamWriter(filePath))
        {
            writer.Write(result.ToString().Trim(new char[]{'\n', '\r'}));
        }

        Console.WriteLine("\nExtracting Complete.\n");
    }
}