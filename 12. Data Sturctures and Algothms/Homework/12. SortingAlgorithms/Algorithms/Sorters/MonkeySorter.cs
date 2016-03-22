namespace SortingHomework.Sorters
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	using Abstracts;
	using Tools.Extensions;

	public class MonkeySorter<T> : Sorter<T> where T : IComparable<T>
	{
		protected override IEnumerable<T> SafeSort(T[] array)
		{
			while (!Sorter<T>.IsSorted(array))
			{
				array = array.Shuffle()
					.ToArray();
			}

			return array;
		}
	}
}