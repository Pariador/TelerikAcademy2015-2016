namespace Space3D.ObjectLibrary
{
    using System;

    public static class Point3DCalculations
    {
        public static double TwoPointDistance(Point3D firstPoint, Point3D secondPoint)
        {
            //Formula used:
            //Distance = Sqrt((x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2)

            Point3D result = secondPoint - firstPoint;
            result = result * result;

            return Math.Sqrt(result.X + result.Y + result.Z);
        }
    }
}
