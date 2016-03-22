using System;

class FirstAndLastName
{
    static void Main()
    {
        string firstName;

        string lastName;

        Console.Write("What is your first name?: ");
        firstName = Console.ReadLine();

        Console.Write("\nWhat is your last name?: ");
        lastName = Console.ReadLine();

        Console.WriteLine("\nHi {0} {1}!\n", firstName, lastName);
    }
}