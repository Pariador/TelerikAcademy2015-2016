using System;
using System.Text;

//Problem 7. Encode/decode
//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, etc. When the last key character is reached, the next is the first.
class EncodeSlashDecode
{
    static void Main()
    {
        //sometimes it doesn't work and I think it's because the console can't read and write some characters

        Console.Write("Input: ");
        string str = Console.ReadLine();

        Console.Write("\nKey: ");
        string key = Console.ReadLine();

        var result = new StringBuilder();
        for (int i = 0, j = 0; i < str.Length; i++, j++)
        {
            result.Append((char)((short)str[i] ^ (short)key[j]));

            if (j == key.Length - 1)
            {
                j = 0;
            }
        }

        Console.WriteLine("\nResult: ({0})\n", result);
    }
}