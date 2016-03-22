using System;

class AgeAfterTenYears
{
    static void Main()
    {
        byte age;

        Console.Write("How old are you now: ");

        age = byte.Parse(Console.ReadLine());

        Console.WriteLine("\nYou will be {0} years old after ten years.\n", age + 10);
    }
}

