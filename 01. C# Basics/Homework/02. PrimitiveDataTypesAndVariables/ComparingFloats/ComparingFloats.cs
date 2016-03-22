using System;

class ComparingFloats
{
    static void Main()
    {
        double eps = 0.000001;

        Console.Write("Iput a: ");
        double a = -0.0000007;// double.Parse(Console.ReadLine());

        Console.Write("\nIput b: ");
        double b = 0.00000007;// double.Parse(Console.ReadLine());

        if (a > b)
        {
            if (a - b < eps)
            {
                Console.WriteLine("\nTrue\n");
            }

            else
            {
                Console.WriteLine("\nFalse\n");
            }
        }

        else if (b > a)
        {
            if (b - a < eps)
            {
                Console.WriteLine("\nTrue\n");
            }

            else 
            {
                Console.WriteLine("\nFalse\n");
            }
        }

    }
}