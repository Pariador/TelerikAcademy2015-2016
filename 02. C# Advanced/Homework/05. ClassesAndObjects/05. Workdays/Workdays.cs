using System;
using System.Threading;
using System.Globalization;

//Problem 5. Workdays
//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
class Workdays
{
    static int WorkdayCount(DateTime find)
    {
        int count = 0;

        DateTime currentDate = DateTime.Today;

        string day;
        while (currentDate <= find)
        {
            day = currentDate.DayOfWeek.ToString();
            if (day != "Saturday" && day != "Sunday")
            {
                count++;
            }

            currentDate = currentDate.AddDays(1);
        }

        return count;
    }

    static int WorkdayCount(DateTime find, DateTime[] holidays)
    {
        int count = 0;

        DateTime currentDate = DateTime.Today;

        int holidayCount = holidays.Length;

        string day;
        bool holiday = false;
        while (currentDate <= find)
        {
            for (int i = 0; i < holidayCount; i++)
            {
                if (holidays[i].Date == currentDate.Date)
                {
                    holiday = true;
                    break;
                }
            }

            day = currentDate.DayOfWeek.ToString();
            if (day != "Saturday" && day != "Sunday" && !holiday)
            {
                count++;
            }

            currentDate = currentDate.AddDays(1);

            holiday = false;
        }

        return count;
    }

    static void Main()
    {
        Console.Write("Input date (d.M.yyyy): ");
        DateTime find = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InstalledUICulture);

        Console.Write("\nDo you want to enter holiday dates (y/n): ");
        string answer = Console.ReadLine();

        if (answer == "y")
        {
            Console.Write("\nHow many: ");
            int holidayCount = int.Parse(Console.ReadLine());

            DateTime[] holidays =  new DateTime[holidayCount];

            for (int i = 0; i < holidayCount; i++)
            {
                Console.Write("Date {0}: ", i + 1);
                holidays[i] = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InstalledUICulture);
            }

            Console.WriteLine("\nWorkdays: {0}\n", WorkdayCount(find, holidays));
        }
        else
        {
            Console.WriteLine("\nWorkdays: {0}\n", WorkdayCount(find));
        }
        
    }
}