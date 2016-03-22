namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;

    public static class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = SelectionSort.FindMinElementIndex(arr, index, arr.Length - 1);
                SelectionSort.Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert((0 <= startIndex) && (startIndex < arr.Length), "Invalid indeces.");
            Debug.Assert(startIndex <= endIndex, "endIndex is less than startIndex.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert((0 <= minElementIndex) && (minElementIndex < arr.Length), "Wrong result index not in in range.");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
