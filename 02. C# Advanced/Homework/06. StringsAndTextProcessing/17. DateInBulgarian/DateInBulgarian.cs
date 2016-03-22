using System;
using System.Text;
using System.Globalization;
using System.Threading;

//Problem 17. Date in Bulgarian
//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
class DateInBulgarian
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        var culture = CultureInfo.GetCultureInfo("bg-BG");
        Console.Write("Input a Date and Time: ");
        DateTime bgDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", culture);

        Console.WriteLine("\nResult:");
        Console.WriteLine("{0 :dd.MM.yyyy HH:mm:ss}", bgDate);
        Console.WriteLine("Day of the week: {0}\n", culture.DateTimeFormat.GetDayName(bgDate.DayOfWeek));
    }//02.03.2004 20:30:25
}