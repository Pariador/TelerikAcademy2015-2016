namespace CohesionAndCoupling.Drawing
{
    using System;

    public class Point2D
    {
        public static readonly Point2D Origin = new Point2D(0, 0);

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public static double CalcDistance(Point2D first, Point2D second)
        {
            double differenceX = first.X - second.X;
            double differenceY = first.Y - second.Y;

            double differenceXSquered = differenceX * differenceX;
            double differenceYSquered = differenceY * differenceY;

            double distance = Math.Sqrt(differenceXSquered + differenceYSquered);
            return distance;
        }

        public static double DistanceFromOrigin(Point2D point)
        {
            return Point2D.CalcDistance(Point2D.Origin, point);
        }
    }
}