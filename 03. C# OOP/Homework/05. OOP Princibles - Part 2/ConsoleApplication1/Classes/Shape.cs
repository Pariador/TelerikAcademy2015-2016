namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private double height;
        private double width;

        protected Shape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height can't be equal or less than zero.");
                }

                this.height = value;
            }
        }
        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width can't be equal or less than zero.");
                }

                this.width = value;
            }
        }

        public abstract double CalculateArea();
    }
}