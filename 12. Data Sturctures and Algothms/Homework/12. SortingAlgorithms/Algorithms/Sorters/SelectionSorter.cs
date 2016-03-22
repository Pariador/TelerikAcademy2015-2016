namespace SortingHomework.Sorters
{
    using System;
    using System.Collections.Generic;

	using Tools;

	using Abstracts;

    public class SelectionSorter<T> : Sorter<T> where T : IComparable<T>
    {
		protected override IEnumerable<T> SafeSort(T[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (this.Comparer.Compare(array[i], array[j]) > 0)
					{
						Helper.Swap(ref array[i], ref array[j]);
					}
				}
			}

			return array;
		}
    }
}