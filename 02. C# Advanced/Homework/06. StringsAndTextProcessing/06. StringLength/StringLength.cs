using System;
using System.Text;

//Problem 6. String length
//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
//Print the result string into the console.
class StringLength
{
    static void Main()
    {
        Console.WriteLine("Input a string of Max 20 chars:");
        string str = Console.ReadLine();

        Console.WriteLine("\nResult:");
        if (str.Length > 20)
        {
            Console.WriteLine("{0}\n", str.Substring(0, 20));
        }
        else if (str.Length < 20)
        {
            var result = new StringBuilder(str);

            while (result.Length != 20)
            {
                result.Append('*');
            }           
            Console.WriteLine("{0}\n", result);
        }
        else
        {
            Console.WriteLine("{0}\n", str);
        }
    }
}