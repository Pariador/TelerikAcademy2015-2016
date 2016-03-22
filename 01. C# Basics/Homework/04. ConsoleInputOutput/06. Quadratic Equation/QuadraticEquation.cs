using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("\nInput b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("\nInput c: ");
        double c = double.Parse(Console.ReadLine());

        
        double discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant > 0)
        {
            Console.WriteLine("\nTwo roots:");
            Console.WriteLine("x1 = {0}", (-b - Math.Sqrt(discriminant)) / (2 * a));
            Console.WriteLine("x2 = {0}\n", (-b + Math.Sqrt(discriminant)) / (2 * a));
        }
        else if (discriminant < 0)
        {
            Console.WriteLine("\nNo real roots.\n");
        }
        else 
        {
            Console.WriteLine("\nOne root:");
            Console.WriteLine("x = {0}\n", -b / (2 * a));
        }
    }
}