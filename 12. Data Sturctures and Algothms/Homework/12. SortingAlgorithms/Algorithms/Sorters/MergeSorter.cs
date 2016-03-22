namespace SortingHomework.Sorters
{
    using System;
	using System.Collections.Generic;

	using Abstracts;

	public class MergeSorter<T> : Sorter<T> where T : IComparable<T>
	{
		protected override IEnumerable<T> SafeSort(T[] array)
		{
			return this.MergeSort(array);
		}

		protected T[] MergeSort(T[] array)
		{
			if (array.Length == 1)
			{
				return array;
			}

			T[] first;
			T[] second;

			if (array.Length == 2)
			{
				first = new T[] { array[0] };
				second = new T[] { array[1] };

				return this.Merge(first, second);
			}

			int firstLength = array.Length / 2;
			first = new T[firstLength];

			int secondLength = array.Length - firstLength;
			second = new T[secondLength];

			Array.Copy(array, first, firstLength);
			Array.Copy(array, firstLength, second, 0, secondLength);

			return this.Merge(this.MergeSort(first), this.MergeSort(second));
		}

		protected T[] Merge(T[] first, T[] second)
		{
			T[] result = new T[first.Length + second.Length];

			int firstIndex = 0;
			int secondIndex = 0;
			for (int i = 0; i < result.Length; i++)
			{
				bool takeFromFirst;

				if (secondIndex == second.Length)
				{
					takeFromFirst = true;
				}
				else if (firstIndex == first.Length)
				{
					takeFromFirst = false;
				}
				else
				{
					takeFromFirst = (this.Comparer.Compare(first[firstIndex], second[secondIndex])) <= 0;
                }


				if (takeFromFirst)
				{
					result[i] = first[firstIndex];
					firstIndex++;
				}
				else
				{
					result[i] = second[secondIndex];
					secondIndex++;
				}
			}

			return result;
		}
	}
}