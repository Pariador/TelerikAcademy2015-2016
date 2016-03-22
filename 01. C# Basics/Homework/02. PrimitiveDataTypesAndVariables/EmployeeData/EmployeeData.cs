using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "John";

        string lastName = "Doe";

        byte age = 27;

        char gender = 'm';

        string IDNumber = "8306112507";

        uint uniqueNumber = 27560000;

        Console.WriteLine("First Name (string): {0}\nSecond Name (string): {1}\nAge (byte): {2}\nGender (char): {3}\nPersonal ID number (string): {4}\nUnique Number (uint): {5}\n",
        firstName, lastName, age, gender, IDNumber, uniqueNumber);
    }
}