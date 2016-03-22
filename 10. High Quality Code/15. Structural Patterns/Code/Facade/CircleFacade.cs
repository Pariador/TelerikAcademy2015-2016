namespace Facade
{
    using System;

    public class Circle
    {
        public Circle(int x, int y, int radius)
        {
            this.Arc = new Arc(x, y, radius, 0, 2 * Math.PI, false);
        }

        private Arc Arc { get; set; }

        public int X
        {
            get
            {
                return this.Arc.X;
            }

            set
            {
                this.Arc.X = value;
            }
        }

        public int Y
        {
            get
            {
                return this.Arc.Y;
            }

            set
            {
                this.Arc.Y = value;
            }
        }

        public int Radius
        {
            get
            {
                return this.Arc.Radius;
            }

            set
            {
                this.Arc.Radius = value;
            }
        }

        public Arc Arc1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Draw()
        {
            this.Arc.Fill();
            this.Arc.Stroke();
        }
    }
}