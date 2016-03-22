namespace Abstraction
{
    using System;

    public class Rectangle : IFigure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width has to be greater than 0.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height has to be greater than 0.");
                }

                this.height = value;
            }
        }

        public double CalcPerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }

        public double CalcArea()
        {
            return this.Width * this.Height;
        }
    }
}