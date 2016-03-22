namespace CohesionAndCoupling.Drawing
{
    using System;

    public class Rectangle
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width has to be greater than zero.");
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height has to be greater than zero.");
                }

                this.height = value;
            }
        }

        public virtual double CalcValume()
        {
            return this.Width * this.Height;
        }

        public double CalcDiagonal()
        {
            return Math.Sqrt(this.CalcSumOfEverySideSquered());
        }

        protected virtual double CalcSumOfEverySideSquered()
        {
            return (this.Width * this.Width) + (this.Height * this.Height);
        }
    }
}