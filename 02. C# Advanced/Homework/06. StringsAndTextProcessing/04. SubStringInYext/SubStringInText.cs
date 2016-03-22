using System;

//Problem 4. Sub-string in text
//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
//Example:
//The target sub-string is in
//The text is as follows: We are living in an yellow submarine. We don't have anything else. 
//inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
//The result is: 9
class SubStringInText
{
    static int StringApperanceCount(string search, string find)
    {
        if (String.IsNullOrEmpty(search))
        {
           throw new ArgumentOutOfRangeException("String find can not be empty or Null.");
        }

        int count = 0;

        int index = 0;

        while (true)
        {
            index = search.IndexOf(find, index + 1);
            if (index == - 1)
            {
                break;
            }
            count++;
        }

        return count;
    }
    static void Main()
    {
        Console.WriteLine("Input a string to be searched:");
        string str = Console.ReadLine();
        //"The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        Console.Write("\nInput a string to search for: ");
        string find = Console.ReadLine();

        try
        {
            Console.WriteLine("\nTimes found: {0}\n", StringApperanceCount(str, find));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("\nFind can not be empty!\n");
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}