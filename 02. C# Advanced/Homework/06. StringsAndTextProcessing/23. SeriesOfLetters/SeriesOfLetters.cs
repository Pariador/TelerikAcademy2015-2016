using System;
using System.Text;

//Problem 23. Series of letters
//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
class SeriesOfLettersTest
{
    static string RemoveLetterSeries(string str)
    {
        StringBuilder result = new StringBuilder(str);

        for (int i = 1; i < result.Length;)
        {
            if (char.IsLetter(result[i]) && result[i] == result[i - 1])
            {
                result.Remove(i, 1);
            }
            else
            {
                i++;
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Input a string:");
        string str = Console.ReadLine();

        Console.WriteLine("\nResult:\n{0}\n", RemoveLetterSeries(str));
    }
}