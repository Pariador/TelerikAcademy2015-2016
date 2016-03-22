using System;

//Problem 2. Enter numbers
//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
class EnterNumbers
{
    static int ReadNumber(int start, int end)
    {
        try
        {
            int result = int.Parse(Console.ReadLine());

            if (start > end || start > result || end < result)
            {
                throw new ArgumentOutOfRangeException();
            }

            return result;
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }

    static void Main()
    {
        try
        {
            Console.Write("Input start value: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("\nInput end value: ");
            int end = int.Parse(Console.ReadLine());

            int[] arr = new int[10];

            Console.WriteLine("\nInput:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Input number {0}: ", i + 1);
                arr[i] = ReadNumber(start, end);
            }

            Console.WriteLine("\nEntered numbers is range ({0} - {1}):", start, end);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Number {0}: {1}", i, arr[i]);
            }
            Console.WriteLine();
        }
        catch (Exception)
        {
            Console.WriteLine("\nInvalid input.\n");
        }
    }
}