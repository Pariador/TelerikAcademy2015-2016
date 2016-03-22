using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter radius of circle: ");
        double radious = double.Parse(Console.ReadLine());

        Console.WriteLine("\nCircle circumference: {0:0.00}\n", 2 * Math.PI * radious);
        Console.WriteLine("Circle area: {0:0.00}\n", Math.PI * Math.Pow(radious, 2));
    }
}