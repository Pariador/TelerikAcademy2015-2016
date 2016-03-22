using System;

class Trapezoids
{
    static void Main()
    {
        Console.Write("Input the first side of a trapezoid: ");
        double sideA = double.Parse(Console.ReadLine());

        Console.Write("\nInput the second side of a trapezoid: ");
        double sideB = double.Parse(Console.ReadLine());

        Console.Write("\nInput the height of a trapezoid: ");
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("\nThe area of the trapezoid is: {0}\n", ((sideA + sideB) / 2) * height);
    }
}