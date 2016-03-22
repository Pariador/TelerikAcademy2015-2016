using System;

//Problem 1. Say Hello
//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.
class SayHello
{
    static void Hello(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static void Main()
    {
        Console.Write("What's your name?: ");
        string name = Console.ReadLine();

        Console.WriteLine();
        Hello(name);
        Console.WriteLine();
    }
}