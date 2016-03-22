namespace CohesionAndCoupling.Drawing
{
    using System;

    public class Point3D : Point2D
    {
        public static readonly new Point3D Origin = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z) : base(x, y)
        {
            this.Z = z;
        }

        public double Z { get; set; }

        public static double CalcDistance(Point3D first, Point3D second)
        {
            double differenceX = first.X - second.X;
            double differenceY = first.Y - second.Y;
            double differenceZ = first.Z - second.Z;

            double differenceXSquered = differenceX * differenceX;
            double differenceYSquered = differenceY * differenceY;
            double differenceZSquered = differenceZ * differenceZ;

            double distance = Math.Sqrt(differenceXSquered + differenceYSquered + differenceZSquered);
            return distance;
        }

        public static double DistanceFromOrigin(Point3D point)
        {
            return Point2D.CalcDistance(Point3D.Origin, point);
        }
    }
}