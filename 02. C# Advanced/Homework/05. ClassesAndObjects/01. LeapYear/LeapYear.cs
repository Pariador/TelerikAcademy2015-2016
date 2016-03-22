using System;

//Problem 1. Leap year
//Write a program that reads a year from the console and checks whether it is a leap one.
//Use System.DateTime.
class LeapYear
{
    static bool IsLeap(int year)
    {
        //if (year is not divisible by 4) then (it is a common year)
        //else
        //if (year is not divisible by 100) then (it is a leap year)
        //else
        //if (year is not divisible by 400) then (it is a common year)
        //else (it is a leap year)

        bool isLeap = false;

        if (year % 4 != 0) //(year is not divisible by 4)
        {
            isLeap = false; //it is a common year
        }
        else if (year % 100 != 0) //(year is not divisible by 100)
        {
            isLeap = true; //(it is a leap year)
        }
        else if (year % 400 != 0) //if (year is not divisible by 400) then 
        {
            isLeap = false; //(it is a common year)
        }
        else
        {
            isLeap = true;
        }

        return isLeap;
    }
    static void Main()
    {
        //And after I wrote IsLeap() I realized there is a DateTime.IsLeap(year)....oh well :)

        Console.Write("Input a year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("\n{0}\n", IsLeap(year) ? "It is a leap year." : "It isn't a leap year.");
    }
}