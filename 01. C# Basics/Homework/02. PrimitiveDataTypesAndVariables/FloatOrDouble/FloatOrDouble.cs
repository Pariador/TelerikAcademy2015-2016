using System;

class FloatOrDouble
{
    static void Main()
    {
        double firstDouble = 34.567839023;
       
        float firstFloat = 12.345f;

        double secondDouble = 8923.1234857;

        float secondFlaot = 3456.091f;

        Console.WriteLine("First Value (double): {0}\nSecond Value (float): {1}\nThird Value (double): {2}\nForth Value (flaot): {3}\n",
                           firstDouble, firstFloat, secondDouble, secondFlaot);
    }
}