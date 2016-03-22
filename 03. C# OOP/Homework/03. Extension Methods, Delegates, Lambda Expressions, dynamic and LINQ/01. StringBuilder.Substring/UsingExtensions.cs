namespace UsingExtensions
{
    using System;
    using Extensions;
    using System.Text;

    internal class UsingExtensions
    {
        static void Main()
        {
            //substring starts at index 5 and has a length of 9
            var strBuilder = new StringBuilder("Only substring must reamain.");

            strBuilder = strBuilder.SubString(5, 9);

            Console.WriteLine("({0})", strBuilder);


            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i + 1;
            }

            Console.WriteLine("Sum: {0}", arr.Sum<int>());
            Console.WriteLine("Product: {0}", arr.Product<int>());
            Console.WriteLine("Count: {0}", arr.Count<int>());
            Console.WriteLine("Average: {0}", arr.Average<int>());
            Console.WriteLine("Min: {0}", arr.Min<int>());
            Console.WriteLine("Max: {0}", arr.Max<int>());
        }
    }
}
