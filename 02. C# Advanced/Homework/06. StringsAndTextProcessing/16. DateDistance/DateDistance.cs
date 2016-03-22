using System;
using System.Globalization;

//Problem 16. Date difference
//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
class DateDistanceTest
{
    static void Main()
    {
        Console.Write("Input first date (d.MM.yyyy): ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.Write("\nInput second date (d.MM.yyyy): ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

        int compare = firstDate.CompareTo(secondDate);

        if (compare == 1)
        {
            Console.WriteLine("\nDays Distance: {0}\n", (firstDate - secondDate).TotalDays);
        }
        else if (compare == -1)
        {
            Console.WriteLine("\nDays Distance: {0}\n", (secondDate - firstDate).TotalDays);
        }
        else
        {
            Console.WriteLine("\nDays Distance: 0\n");
        }
    }
}