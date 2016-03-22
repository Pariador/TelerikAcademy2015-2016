using System;

class StringsAndObjects
{
    static void Main()
    {
        string hello = "Hello";

        string world = "World!";

        object obj = hello + " " + world;

        string message = (string) obj;

        Console.WriteLine("Message: {0}\n", message);
    }
}