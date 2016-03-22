namespace CohesionAndCoupling.Drawing
{
    using System;

    public class Cuboid : Rectangle
    {
        double depth;

        public Cuboid(double width, double height, double depth)
            : base(width, height)
        {
            this.Depth = depth;
        }


        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth has to be greater than zero.");
                }

                this.depth = value;
            }
        }

        public override double CalcValume()
        {
            return base.CalcValume() * this.Depth;
        }

        protected override double CalcSumOfEverySideSquered()
        {
            return base.CalcSumOfEverySideSquered() + (this.Depth * this.Depth);
        }
    }
}