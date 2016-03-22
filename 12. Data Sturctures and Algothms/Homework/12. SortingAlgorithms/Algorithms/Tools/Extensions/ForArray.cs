namespace SortingHomework.Tools.Extensions
{
	using System;

	public static class ForArray
	{
		public static bool CustomBinarySearch<T>(this T[] array, T toFind) where T : IComparable<T>
		{
			int minIndex = 0;
			int maxIndex = array.Length - 1;

			while (minIndex <= maxIndex)
			{
				int midIndex = (minIndex + maxIndex) / 2;

				int comparison = toFind.CompareTo(array[midIndex]);

				if (comparison == 0)
				{
					return true;
				}
				else if (comparison < 0)
				{
					maxIndex = midIndex - 1;
				}
				else
				{
					minIndex = midIndex + 1;
				}
			}

			return false;
		}
	}
}