namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) : base(height, width)
        {
            ;
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }
    }
}