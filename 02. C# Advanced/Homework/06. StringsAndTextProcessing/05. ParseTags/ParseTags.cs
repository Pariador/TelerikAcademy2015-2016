using System;
using System.Text;
using System.Collections.Generic;

//Problem 5. Parse tags
//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
//The tags cannot be nested.
//Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
class ParseTagsTest
{
    static string TaggedToUpper(string text)
    {
        if (String.IsNullOrEmpty(text))
        {
            throw new ArgumentOutOfRangeException("Argument text can not be empty or Null.");
        }

        StringBuilder result = new StringBuilder(text);

        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        int openIndex = -1;
        int closeIndex = -1;
        string edit = null;
        string change = null;
        while (true)
        {
            openIndex = text.IndexOf(openTag, openIndex + 1);
            if (openIndex == -1)
            {
                break;
            }
            closeIndex = text.IndexOf(closeTag, closeIndex + 1);

            edit = text.Substring(openIndex, (closeIndex + 9) - openIndex);
            change = edit.Substring(8, edit.Length - 17);
            result = result.Replace(edit, change.ToUpper());
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Input a string to be changed:");
        string str = Console.ReadLine();

        try
        {
            Console.WriteLine("\nResult:\n{0}\n", TaggedToUpper(str));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The string can not be Empty or Null.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}