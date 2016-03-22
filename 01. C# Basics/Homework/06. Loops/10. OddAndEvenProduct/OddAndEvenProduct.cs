using System;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Write("Write numbers: ");
        string[] numbers = Console.ReadLine().Split(' ');

        int evenProduct = 1;
        int oddProduct = 1;

        int count = 0;
        foreach (string num in numbers)
        {
            count++;

            if (count % 2 == 0)
            {
                evenProduct *= int.Parse(num);
            }
            else
            {
                oddProduct *= int.Parse(num);
            }
        }

        Console.WriteLine("\nOdd and even numbers have the same product? {0}\n", evenProduct == oddProduct? "Yes." : "No.");
    }
}