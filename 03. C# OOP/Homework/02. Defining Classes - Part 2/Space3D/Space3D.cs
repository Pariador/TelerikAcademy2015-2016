namespace Space3D
{
    using System;
    using ObjectLibrary;

    internal class Space3D
    {
        static void PrintPath(Path path)
        {
            Console.WriteLine(path.NeighborDistance);
            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i]);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            const string url = @"..\..\Test.txt";

            var path = new Path(3.14, new Point3D(5.17, -1.23, 9), new Point3D(8.31, -1.23, 9), new Point3D(8.31, -4.37, 9));

            PathStorage.Save(path, url);
            PrintPath(PathStorage.Load(url));
        }
    }
}