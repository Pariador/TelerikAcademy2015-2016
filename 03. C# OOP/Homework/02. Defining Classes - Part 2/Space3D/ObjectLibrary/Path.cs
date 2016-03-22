namespace Space3D.ObjectLibrary
{
    using System;
    using System.Collections.Generic;

    //Represents a sequence of points in the Euclidian 3D space.
    //Two points are neighbors if they are a set n distance (n > 0) from each other with 0.01 precision.
    //Each point has to be a neighbor of the previous.
    //A Path may not contain less than one point.
    //Default neighbor distance is 1.00.
    public class Path
    {
        private static readonly ArgumentException notNeighbor = new ArgumentException("Each point must be different and at neighbor distance from the previous one.");

        private double neighborDistance;

        public Path(double neighborDistance, params Point3D[] points)
        {
            this.NeighborDistance = neighborDistance;

            if (!this.IsValidPath(points))
            {
                throw new ArgumentException("Invalid path.");
            }

            this.Points = new List<Point3D>(points);
        }
        public Path(params Point3D[] points) : this(1, points)
        {
            ;
        }

        public int Count 
        {
            get
            {
                return this.Points.Count;
            }
        }
        public int Capacity
        {
            get
            {
                return this.Points.Capacity;
            }
        }
        public double NeighborDistance
        {
            get
            {
                return this.neighborDistance;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Distance between neighbors can't be equal to or less than zero.");
                }

                this.neighborDistance = value;
            }
        }
        private List<Point3D> Points { get; set; }

        public Point3D this[int index]
        {
            get
            {
                return this.Points[index];
            }
            set
            {
                if (index == 0)
                {
                    if (!this.AreNeighbors(value, this.Points[1]))
                    {
                        throw Path.notNeighbor;
                    }

                    this.Points[index] = value;
                }
                else if (index == this.Points.Count - 1)
                {
                    if (!this.AreNeighbors(this.Points[index - 1], value))
                    {
                        throw Path.notNeighbor;
                    }

                    this.Points[index] = value;
                }
                else
                {
                    if (!this.AreNeighbors(this.Points[index - 1], value) || !this.AreNeighbors(value, this.Points[index + 1]))
                    {
                        throw Path.notNeighbor;    
                    }

                    this.Points[index] = value;
                }
            }
        }

        //Methods to access useful list functionality
        public void Add(Point3D point)
        {
            if (!this.AreNeighbors(this[this.Count - 1], point))
            {
                throw Path.notNeighbor;
            }

            this.Points.Add(point);
        }
        public void Insert(int index, Point3D point)
        {
            if (!this.AreNeighbors(point, this[index]) || !this.AreNeighbors(this[index - 1], point))
            {
                throw notNeighbor;
            }

            this.Points.Insert(index, point);
        }
        public int IndexOf(Point3D point)
        {
            return this.Points.IndexOf(point);
        }
        public int IndexOf(Point3D point, int index)
        {
            return this.Points.IndexOf(point, index);
        }
        public int IndexOf(Point3D point, int index, int count)
        {
            return this.Points.IndexOf(point, index, count);
        }
        public bool Contains(Point3D point)
        {
            return this.Points.Contains(point);
        }
        public void Clear()
        {
            this.Points.Clear();
        }
        public void Remove(Point3D point)
        {
            this.Points.Remove(point);
        }
        public void RemoveAt(int index)
        {
            this.Points.RemoveAt(index);
        }
        public Point3D[] ToArray()
        {
            return this.Points.ToArray();
        }
        //Checks if two points are within neighbor distance of each other.
        private bool AreNeighbors(Point3D firstPoint, Point3D secondPoint)
        {
            return (Math.Abs(this.NeighborDistance - Point3DCalculations.TwoPointDistance(firstPoint, secondPoint))) < 0.01;
        }
        //A valid path is a sequence of Point3D points where each point is within neighbor ditance
        //of the previous one. A Path may not contain less than one point.
        private bool IsValidPath(params Point3D[] points)
        {
            if (points.Length == 0)
            {
                return false;
            }

            for (int i = 1; i < points.Length; i++)
            {
                if (!this.AreNeighbors(points[i], points[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}