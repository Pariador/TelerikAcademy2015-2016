using System;
//Problem 12. Index of letters
//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.
class IndexOfLetters
{
    static void Main()
    {
        char[] alphabet = new char[52];

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)(65 + i);
        }

        for (int i = 26; i < 52; i++)
        {
            alphabet[i] = (char)(71 + i);
        }


        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Console.WriteLine();
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < 52; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.WriteLine("The letter {0} has index {1} in the array.", word[i], j);
                }
            }
        }

        Console.WriteLine();
    }
}