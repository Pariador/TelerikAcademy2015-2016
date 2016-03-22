using System;
using System.Text;

//Problem 8. Extract sentences
//Write a program that extracts from a given text all sentences containing given word.
class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("Input text:");
        string search = Console.ReadLine();

        Console.Write("\nWord to search for: ");
        string find = Console.ReadLine();

        string findAtEnd = String.Format(" {0}.", find);
        find = String.Format(" {0} ", find);
        int countResults = 0;
        var result = new StringBuilder();
        int foundIndex = -1;
        int secondIndex = -1;
        int index = 0;
        while (true)
        {
            foundIndex = search.IndexOf(find, foundIndex + 1);
            if (foundIndex == -1)
            {
                secondIndex = search.IndexOf(findAtEnd, secondIndex + 1);
                foundIndex = secondIndex;

                if (secondIndex == -1)
                {
                    break;
                }
            }

            index = foundIndex;
            while (index >= 0 && search[index] != '.')
            {
                result.Insert(0, search[index]);
                index--;
            }

            index = foundIndex;
            while (true)
            {
                result.Append(search[index]);
                if (search[index] == '.')
                {
                    break;
                }
                index++;
            }

            countResults++;
            Console.WriteLine("\nResult {0}:", countResults);
            Console.WriteLine(result.ToString().TrimStart());
            result.Clear();
        }

        Console.WriteLine();
    }
}