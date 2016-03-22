namespace Abstraction
{
    using System;

    public static class FiguresExample
    {
        internal static void Main()
        {
            Circle circle = new Circle(5);
            double circleParameter = circle.CalcPerimeter();
            double circleArea = circle.CalcArea();
            Console.WriteLine("I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.", circleParameter, circleArea);

            Rectangle rect = new Rectangle(2, 3);
            double rectPerimeter = rect.CalcPerimeter();
            double rectArea = rect.CalcArea();
            Console.WriteLine("I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.", rectPerimeter, rectArea);
        }
    }
}