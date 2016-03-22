using System;

class ValueExchange
{
    static void Main()
    {
        int a = 5;

        int b = 10;

        Console.WriteLine("Before value of a: {0}\nBefore value of b: {1}\n", a ,b);

        int hold = a;

        a = b;

        b = hold;

        Console.WriteLine("After value of a:{0}\nAfter value of b: {1}\n", a, b);
    }
}