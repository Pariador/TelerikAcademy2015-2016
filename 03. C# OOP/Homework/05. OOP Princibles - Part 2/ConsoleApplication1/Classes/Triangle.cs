namespace Shapes
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(double height, double width) : base(height, width)
        {
            ;
        }

        public override double CalculateArea()
        {
            return (this.Height * this.Width) / 2;
        }
    }
}