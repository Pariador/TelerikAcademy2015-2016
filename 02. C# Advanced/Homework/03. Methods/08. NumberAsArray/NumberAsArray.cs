using System;
//Problem 8. Number as array
//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

class NumberAsArrayTest
{
    static int TwoNumberDecimalAddition(int firstNum, int secondNum)
    {
        //there is really no need for this but the problem says I haz to put in an array :(
        char[] arrNumOne = firstNum.ToString().ToCharArray();
        char[] arrNumTwo = secondNum.ToString().ToCharArray();

        //indices used to go through the arrays last to first element
        int digitIndexOne = arrNumOne.Length - 1;
        int digitIndexTwo = arrNumTwo.Length - 1;

        //How it works: 123 + 456 = ((1 + 4) * 10^2) + ((2 + 5) * 10^1) + ((3 + 6) * 10^0)
        int firstAdd = 0;
        int secondAdd = 0;

        int powerOfTen = 1;
        int result = 0;

        while (digitIndexOne >= 0 || digitIndexTwo >= 0)
        {
            if (digitIndexOne < 0)
            {
                firstAdd = 0;
            }
            else
            {
                firstAdd = int.Parse(arrNumOne[digitIndexOne].ToString());
                digitIndexOne--;
            }

            if (digitIndexTwo < 0)
            {
                secondAdd = 0;
            }
            else
            {
                secondAdd = int.Parse(arrNumTwo[digitIndexTwo].ToString());
                digitIndexTwo--;
            }

            result += ((firstAdd + secondAdd) * powerOfTen);

            powerOfTen *= 10;
        }

        return result;
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine(TwoNumberDecimalAddition(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));   
        }
    }
}