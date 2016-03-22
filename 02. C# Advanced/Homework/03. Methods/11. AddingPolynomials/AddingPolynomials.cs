using System;

//Problem 11. Adding polynomials
//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.
//Example:
//x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

class AddingPolynomialsTest
{
    static void Main()
    {
        Console.WriteLine("Input polynomials represented by their coefficients like:\nx^2 + 5 = 1x^2 + 0x^1 + 5*x^0 => {5, 0, 1}");

        //input
        Console.Write("\nFirst polynomial (seperate with space): ");
        string str = Console.ReadLine();
        string[] strArr = str.Split(' ');
        
        int firstLength = strArr.Length;
        int[] firstPoly = new int[firstLength];

        for (int i = 0; i < firstLength; i++)
        {
            firstPoly[i] = int.Parse(strArr[i]);
        }


        Console.Write("\nSecond polynomial (seperate with space): ");
        str = Console.ReadLine();
        strArr = str.Split(' ');

        int secondLength = strArr.Length;
        int[] secondPoly = new int[secondLength];

        for (int i = 0; i < secondLength; i++)
        {
            secondPoly[i] = int.Parse(strArr[i]);
        }


        //add up in the array that is bigger
        bool firstIsBigger = true;
        int biggerLength = firstLength;
        int shorterLength = secondLength;

        if (firstLength < secondLength)
        {
            firstIsBigger = false;
            biggerLength = secondLength;
            shorterLength = firstLength;
        }

        for (int i = 0; i < shorterLength; i++)
        {
            if (firstIsBigger)
            {
                firstPoly[i] += secondPoly[i];
            }
            else
            {
                secondPoly[i] += firstPoly[i];
            }
        }

        //output
        Console.Write("\nResult: ");
        for (int i = biggerLength - 1; i >= 0; i--)
        {
            if (firstIsBigger)
            {
                Console.Write("({0}*X^{1})", firstPoly[i], i);
            }
            else
            {
                Console.Write("({0}*X^{1})", secondPoly[i], i);
            }
            
            if (i != 0)
            {
                Console.Write('+');
            }
        }
        Console.WriteLine('\n');
    }
}