using System;

class NullValueArithmatic
{
    static void Main()
    {
        int? integer = null;

        double? realDouble = null;

        Console.WriteLine("An int with a null value: <{0}>\nA double with null value: <{1}>\n", integer, realDouble);

        integer = 32;

        realDouble = 3.14;

        Console.WriteLine("The same int with a value: <{0}>\nThe same double with a value: <{1}>\n", integer, realDouble);
    }
}