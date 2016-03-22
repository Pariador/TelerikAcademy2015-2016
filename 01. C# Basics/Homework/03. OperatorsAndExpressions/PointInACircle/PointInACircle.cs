using System;

class PointInACircle
{
    static void Main()
    {
        Console.Write("Input the X coordinate: "); 
        double x = double.Parse(Console.ReadLine());
        
        Console.Write("\nInput the Y coordinate: ");
        double y = double.Parse(Console.ReadLine());

        Console.WriteLine("\nIs the point in circle K((0, 0), 2)?: {0}\n", Math.Pow(x, 2) + Math.Pow(y, 2) <= 4);
    }
}