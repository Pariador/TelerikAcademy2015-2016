namespace Space3D.ObjectLibrary
{
    using System;

    //Represents a point in the Euclidian 3D space.
    public struct Point3D
    {
        private static readonly Point3D o = new Point3D(0, 0, 0);
        
        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //A Point3D object represnting the ceter point of a 3D Space
        public static Point3D O 
        {
            get
            {
                return o;
            }
        }

        //A point on each axis.
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //Overrides for some object methods.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Point3D)
            {
                Point3D point = (Point3D)obj;

                return (this.X == point.X) && (this.Y == point.Y) && (this.Z == point.Z);
            }
            else
            {
                return false;
            }

        }
        public bool Equals(Point3D point)
        {
            return (this.X == point.X) && (this.Y == point.Y) && (this.Z == point.Z);
        }
        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);
        }

        //Some useful operators.
        public static Point3D operator +(Point3D firstPoint, Point3D secondPoint)
        {
            return new Point3D((firstPoint.X + secondPoint.X), (firstPoint.Y + secondPoint.Y), (firstPoint.Z + secondPoint.Z));
        }
        public static Point3D operator -(Point3D firstPoint, Point3D secondPoint)
        {
            return new Point3D((firstPoint.X - secondPoint.X), (firstPoint.Y - secondPoint.Y), (firstPoint.Z - secondPoint.Z));
        }
        public static Point3D operator *(Point3D firstPoint, Point3D secondPoint)
        {
            return new Point3D((firstPoint.X * secondPoint.X), (firstPoint.Y * secondPoint.Y), (firstPoint.Z * secondPoint.Z));
        }
        public static Point3D operator /(Point3D firstPoint, Point3D secondPoint)
        {
            return new Point3D((firstPoint.X / secondPoint.X), (firstPoint.Y / secondPoint.Y), (firstPoint.Z / secondPoint.Z));
        }
        public static bool operator ==(Point3D firstPoint, Point3D secondPoint)
        {
            return firstPoint.Equals(secondPoint);
        }
        public static bool operator !=(Point3D firstPoint, Point3D secondPoint)
        {
            return !(firstPoint == secondPoint);
        }
    }
}