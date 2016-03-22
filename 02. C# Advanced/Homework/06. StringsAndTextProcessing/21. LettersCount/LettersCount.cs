using System;
using System.Linq;
using System.Collections.Generic;

//Problem 21. Letters count
//Write a program that reads a string from the console and prints all different letters in the string along with 
//information how many times each letter is found.
class LettersCountTest
{
    static int CountChar(string str, char find)
    {
        int result = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (find == str[i])
            {
                result++;
            }
        }

        return result;
    }

    static Dictionary<char, int> LettersCount(string str)
    {
        var uniqueLetters = new HashSet<char>();

        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                uniqueLetters.Add(str[i]);
            }
        }

        var letterAndCount = new Dictionary<char, int>();
        foreach (var letter in uniqueLetters)
        {
            letterAndCount.Add(letter, CountChar(str, letter));
        }

        return letterAndCount;
    }

    static void Main()
    {
        //The search is case sensitive.
        Console.WriteLine("Input a string:");
        string str = Console.ReadLine();

        Dictionary<char, int> result = LettersCount(str);

        Console.WriteLine("\nResult:");
        foreach (var letter in result)
        {
            Console.WriteLine("{0}: {1}", letter.Key, letter.Value);
        }
        Console.WriteLine();
    }
}