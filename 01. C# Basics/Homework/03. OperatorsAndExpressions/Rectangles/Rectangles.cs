using System;

class Rectangles
{
    static void Main()
    {
        Console.Write("Input the width of a rectangle: ");
        double width = double.Parse(Console.ReadLine());

        Console.Write("\nInput the height of a rectangle: ");
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("\nThe perimeter of the rectangle is {0}.\n", 2 * width + 2 * height);

        Console.WriteLine("The area of the rectangle is {0}.\n", width * height);
    }
}