namespace GenericClass
{ 
    using System;
    using ObjectLibrary;

    internal class GenericClass
    {
        //Some tests to use GenericList funtionality.
        static void PrintAll(GenericList<int> genList)
        {
            Console.WriteLine("Starting Count: {0}", genList.Count);
            Console.WriteLine("Starting Capacity: {0}", genList.Capacity);
            Console.WriteLine("Starting Min: {0}", genList.Min());
            Console.WriteLine("Starting Min Index: {0}", genList.IndexOf(genList.Min(), 0));
            genList.RemoveAt(genList.IndexOf(genList.Min(), 0));
            Console.WriteLine("New Min: {0}", genList.Min());
            Console.WriteLine("Starting Max: {0}", genList.Max());

            for (int i = 0; i < 20; i++)
            {
                genList.Add(default(int));
            }
            Console.WriteLine("Starting Count + 20 items added: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 20 items added: {0}", genList.Capacity);

            for (int i = 0; i < 20; i++)
            {
                genList.Insert(0, default(int));
            }
            Console.WriteLine("Starting Count + 20 items inserted: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 20 items inserted: {0}", genList.Capacity);

            Console.WriteLine("List.ToString:");
            Console.WriteLine(genList);

            genList.Clear();
            Console.WriteLine("Count after Clear: {0}", genList.Count);
            Console.WriteLine("Capacity after Clear: {0}\n", genList.Capacity);
        }
        static void PrintAll(GenericList<string> genList)
        {
            Console.WriteLine("Starting Count: {0}", genList.Count);
            Console.WriteLine("Starting Capacity: {0}", genList.Capacity);
            Console.WriteLine("Starting Min: {0}", genList.Min());
            Console.WriteLine("Starting Min Index: {0}", genList.IndexOf(genList.Min(), 0));
            genList.RemoveAt(genList.IndexOf(genList.Min(), 0));
            Console.WriteLine("New Min: {0}", genList.Min());
            Console.WriteLine("Starting Max: {0}", genList.Max());

            for (int i = 0; i < 20; i++)
            {
                genList.Add(default(string));
            }
            Console.WriteLine("Starting Count + 20 items added: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 20 items added: {0}", genList.Capacity);

            for (int i = 0; i < 20; i++)
            {
                genList.Insert(0, default(string));
            }
            Console.WriteLine("Starting Count + 20 items inserted: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 20 items inserted: {0}", genList.Capacity);

            Console.WriteLine("List.ToString:");
            Console.WriteLine(genList);

            genList.Clear();
            Console.WriteLine("Count after Clear: {0}", genList.Count);
            Console.WriteLine("Capacity after Clear: {0}\n", genList.Capacity);
        }
        static void PrintAll(GenericList<DateTime> genList)
        {
            Console.WriteLine("Starting Count: {0}", genList.Count);
            Console.WriteLine("Starting Capacity: {0}", genList.Capacity);
            Console.WriteLine("Starting Min: {0}", genList.Min());
            Console.WriteLine("Starting Min Index: {0}", genList.IndexOf(genList.Min(), 0));
            genList.RemoveAt(genList.IndexOf(genList.Min(), 0));
            Console.WriteLine("New Min: {0}", genList.Min());
            Console.WriteLine("Starting Max: {0}", genList.Max());

            for (int i = 0; i < 3; i++)
            {
                genList.Add(default(DateTime));
            }
            Console.WriteLine("Starting Count + 3 items added: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 3 items added: {0}", genList.Capacity);

            for (int i = 0; i < 3; i++)
            {
                genList.Insert(0, default(DateTime));
            }
            Console.WriteLine("Starting Count + 3 items inserted: {0}", genList.Count);
            Console.WriteLine("Starting Capacity + 3 items inserted: {0}", genList.Capacity);

            Console.WriteLine("List.ToString:");
            Console.WriteLine(genList);

            genList.Clear();
            Console.WriteLine("Count after Clear: {0}", genList.Count);
            Console.WriteLine("Capacity after Clear: {0}\n", genList.Capacity);
        }

        static void Main()
        {
            var genIntList = new GenericList<int>(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var genStringList = new GenericList<string>("zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine");
            var genDateList = new GenericList<DateTime>(new DateTime(1995, 9, 22), new DateTime(2007, 1 , 1), DateTime.Now);

            PrintAll(genIntList);
            PrintAll(genStringList);
            PrintAll(genDateList);
        }
    }
}
