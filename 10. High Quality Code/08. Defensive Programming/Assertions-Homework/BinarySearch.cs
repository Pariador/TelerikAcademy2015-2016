namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;

    public static class BinarySearch
    {
        public static int Search<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            return BinarySearch.BinSearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinSearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert((0 <= startIndex) && (startIndex < arr.Length), "Invalid indeces.");
            Debug.Assert(startIndex <= endIndex, "endIndex is less than startIndex.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert((0 <= midIndex) && (midIndex < arr.Length), "Wrong result index not in in range.");

                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
