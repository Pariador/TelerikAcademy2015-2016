using System;

class InsideCircleOutsideRectangle
{
    static void Main()
    {
        Console.Write("Input the X coordinate: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("\nInput the Y coordinate: ");
        double y = double.Parse(Console.ReadLine());

        bool InCircle = Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2) <= 2.25;

        bool OutOfRectangle = y > 1 || y < -1 || x < -1 || x > 5;

        Console.WriteLine("\nIs the point in circle K((1, 1), 2) and out of rectangle\nR(top=1, left=-1, width=6, height=2)?: {0}\n", InCircle && OutOfRectangle? "Yes." : "No.");

    }
}