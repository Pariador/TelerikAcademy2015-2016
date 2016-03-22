namespace Space3D.ObjectLibrary
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;

    public static class PathStorage
    {
        //Saves a specified Path object in a specified file.
        //The first line holds the Neighbor Distance of the Path.
        //Each subsequent line, until all elements of the Path have been printed,
        //holds the a string representation of a Point3D object.
        public static void Save(Path path, string filePath)
        {
            var result = new StringBuilder(path.NeighborDistance.ToString() + '\n');

            for (int i = 0; i < path.Count; i++)
            {
                result.Append(path[i].ToString());

                if (i != path.Count - 1)
                {
                    result.Append('\n');
                }
            }

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(result);
            }
        }
        //Reads a Path object from a text file constructed by PathStorage.Save().
        //First the Neighbor Distance is read from the first line, then the rest of the file is read, split into string numbers
        //which are parsed to double and saved in an array.
        //Each set of three numbers from the beginning of the array is a Point3D object.
        //These objects are constructed and saved to there own array,
        //wich is then used as a parametar along with Neighbor Distance to construct a Path object.
        public static Path Load(string filePath)
        {
            double[] numbers;
            double neighborDistance;
            using (var reader = new StreamReader(filePath))
            {
                neighborDistance = double.Parse(reader.ReadLine());
                numbers = reader.ReadToEnd().Split(new string[] { "X: ", ", Y: ",", Z: ", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            var points = new Point3D[numbers.Length / 3];
            for (int i = 2, j = 0; i < numbers.Length; i += 3, j++)
            {
                points[j] = new Point3D(numbers[i - 2], numbers[i - 1], numbers[i]);
            }

            return new Path(neighborDistance, points);
        }
    }
}
