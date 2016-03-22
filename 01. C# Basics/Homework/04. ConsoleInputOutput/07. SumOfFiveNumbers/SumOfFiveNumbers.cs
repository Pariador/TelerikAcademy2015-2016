using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Input:");
        string[] strNumbers = Console.ReadLine().Split(' ');

        double sum = new double();


        for (int i = 0; i < strNumbers.Length; i++)
        {
            sum += double.Parse(strNumbers[i]);
        }

        Console.WriteLine("\nThe sum of the numbers: {0}\n", sum);
    }
}