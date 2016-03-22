namespace CohesionAndCoupling
{
    using System;

    using Tools;
    using Drawing;

    public static class Examples
    {
        internal static void Main()
        {
            string[] fileNameExamples = { "example1", "example2.pdf", "example3.new.pdf" };

            foreach (var example in fileNameExamples)
            {
                string fileExtension = FileTools.GetFileExtension(example);
                Console.WriteLine("File extension in [{0}]: [{1}]", example, fileExtension);
            }

            foreach (var example in fileNameExamples)
            {
                string fileName = FileTools.GetFileNameWithoutExtension(example);
                Console.WriteLine("File name in [{0}]: [{1}]", example, fileName);
            }

            Point2D first2D = new Point2D(1, -2);
            Console.WriteLine("Ditance from Origin in 2D sapce = {0:f2}", Point2D.DistanceFromOrigin(first2D));
            Point2D second2D = new Point2D(3, 4);
            Console.WriteLine("Distance in the 2D space = {0:f2}", Point2D.CalcDistance(first2D, second2D));

            Point3D first3D = new Point3D(5, 2, -1);
            Console.WriteLine("Ditance from Origin in 2D sapce = {0:f2}", Point2D.DistanceFromOrigin(first3D));
            Point3D second3D = new Point3D(3, -6, 4);
            Console.WriteLine("Distance in the 3D space = {0:f2}", Point3D.CalcDistance(first3D, second3D));

            Cuboid obj = new Cuboid(3, 4, 5);
            double objVolume = obj.CalcValume();
            Console.WriteLine("Volume = {0:f2}", objVolume);
        }
    }
}
