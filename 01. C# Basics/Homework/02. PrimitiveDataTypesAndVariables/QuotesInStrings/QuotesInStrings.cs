using System;

class QuotesInStrings
{
    static void Main()
    {
        string firstString = "The \"use\" of quotations causes difficulties.";
        string secondString = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine("First String: {0}\nSecond String: {1}\n", firstString, secondString);
    }
}