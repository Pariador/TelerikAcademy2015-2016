using System;

//Problem 3. Correct brackets
//Write a program to check if in a given expression the brackets are put correctly.
class CorrectBracketsTest
{
    static bool CorrectBrackets(string expression)
    {
        int openCount = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                openCount++;
            }
            else if (expression[i] == ')')
            {
                if (openCount > 0)
                {
                    openCount--;
                }
                else
                {
                    return false;
                }
            }
        }

        return openCount == 0;
    }

    static void Main()
    {
        Console.Write("Input expression: ");
        string expression = Console.ReadLine();

        Console.WriteLine("\nThe brackets {0} proper.\n", CorrectBrackets(expression)? "are":"aren't");
    }
}