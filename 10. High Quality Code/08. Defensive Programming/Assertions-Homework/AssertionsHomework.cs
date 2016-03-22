namespace AssertionsHomework
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public static class AssertionsHomework
    {
        internal static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort.Sort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort.Sort(new int[0]); // Test sorting empty array
            SelectionSort.Sort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch.Search(arr, -1000));
            Console.WriteLine(BinarySearch.Search(arr, 0));
            Console.WriteLine(BinarySearch.Search(arr, 17));
            Console.WriteLine(BinarySearch.Search(arr, 10));
            Console.WriteLine(BinarySearch.Search(arr, 1000));
        }
    }
}