namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public static class ShapesTest
    {
        private static readonly Random rand = new Random();

        public static void Start()
        {
            List<Shape> shapes = new List<Shape>();

            for (int c = 0; c < 30; c++)
            {
                int result = ShapesTest.rand.Next(0, 3);

                switch (result)
                {
                    case 0:
                        shapes.Add(new Triangle(ShapesTest.rand.Next(1, 21), ShapesTest.rand.Next(1, 21)));
                        break;
                    case 1:
                        shapes.Add(new Rectangle(ShapesTest.rand.Next(1, 21), ShapesTest.rand.Next(1, 21)));
                        break;
                    case 2:
                        shapes.Add(new Squere(ShapesTest.rand.Next(1, 21)));
                        break;
                    default:
                        throw new ApplicationException("Error ShapesTest Switch.");
                }
            }

            foreach (var shape in shapes)
            {
                if (shape is Triangle)
                {
                    Console.WriteLine("Triangle: Height - {0} Width - {1}", shape.Height, shape.Width);
                }
                else if(shape is Squere)
                {
                    Console.WriteLine("Squere: Height - {0} Width - {1}", shape.Height, shape.Width);
                }
                else
	            {
                    Console.WriteLine("Rectangle: Height - {0} Width - {1}", shape.Height, shape.Width);
	            }

                Console.WriteLine("Area: {0}", shape.CalculateArea());
            }
        }
    }
}