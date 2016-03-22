using System;
using System.Numerics;

//Problem 10. N Factorial
//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as an array of digits by given integer number.
class NFactorialTest
{
    static void Main()
    {
        //I don't really see the point of the Hint. O_O

        BigInteger result = 1;

        for (int i = 1; i <= 100; i++)
        {
            result *= i;
            Console.WriteLine(result);
        }
    }
}