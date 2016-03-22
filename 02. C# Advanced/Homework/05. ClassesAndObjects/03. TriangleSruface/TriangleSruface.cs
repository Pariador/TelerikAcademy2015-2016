using System;

//Problem 4. Triangle surface
//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.
class TriangleSrufacetTest
{
    static double AreaSideHeight(double side, double height)
    {
        return (side * height) / 2;
    }

    static double AreaThreeSides(double a, double b, double c)
    {
        double halfPerimeter = (a + b + c) / 2;

        return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
    }

    static double AreaTwoSidesOneAngle(double a, double b, double radian)
    {
        return a * b * (Math.Sin(radian) / 2);
    }

    static void Main()
    {
        Console.WriteLine("Find Area by:");
        Console.WriteLine("1: Side and Height.");
        Console.WriteLine("2: Three sides.");
        Console.WriteLine("3: Two sides and an angle.");

        Console.Write("\nInput: ");
        int input = int.Parse(Console.ReadLine());

        if (input == 1)
        {
            Console.Write("\nInput side: ");
            double side = double.Parse(Console.ReadLine());

            Console.Write("\nInput height to side: ");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("\nArea: {0 :0.00}\n", AreaSideHeight(side, height));
        }
        else if (input == 2)
        {
            Console.Write("\nInput side a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("\nInput side b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("\nInput side c: ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine("\nArea: {0 :0.00}\n", AreaThreeSides(a, b, c));
        }
        else if (input == 3)
        {
            Console.Write("\nInput side a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("\nInput side b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("\nInput side radian: ");
            double radian = double.Parse(Console.ReadLine());

            Console.WriteLine("\nArea: {0 :0.00}\n", AreaTwoSidesOneAngle(a, b, radian));
        }
        else
        {
            Console.WriteLine("\nWrong input.\n");
        }
    }
}