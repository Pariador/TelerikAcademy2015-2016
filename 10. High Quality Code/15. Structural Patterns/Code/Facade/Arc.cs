namespace Facade
{
    using System;

    public class Arc
    {
        public Arc(int x, int y, int radius, double startAngle, double endAngle, bool counterClockWise)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.StartAngle = startAngle;
            this.EndAngle = endAngle;
            this.CounterClockWise = counterClockWise;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius { get; set; }

        public double StartAngle { get; set; }

        public double EndAngle { get; set; }

        public bool CounterClockWise { get; set; }

        public void Stroke()
        {
            Console.WriteLine("Stroked {0}.", this.ToString());
        }

        public void Fill()
        {
            Console.WriteLine("Filled {0}.", this.ToString());
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, R: {2}, SA: {3}, EA: {4}, CCW: {5}", this.X, this.Y, this.Radius, this.StartAngle, this.EndAngle, this.CounterClockWise);
        }
    }
}