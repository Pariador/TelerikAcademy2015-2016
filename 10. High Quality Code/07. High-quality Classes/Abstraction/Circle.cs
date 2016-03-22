namespace Abstraction
{
    using System;

    public class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius has to be greater than 0.");
                }

                this.radius = value;
            }
        }

        public double CalcPerimeter()
        {
            return (2 * Math.PI) * this.Radius;
        }

        public double CalcArea()
        {
            double radiusSquered = this.Radius * this.Radius; 
            return Math.PI * radiusSquered;
        }
    }
}