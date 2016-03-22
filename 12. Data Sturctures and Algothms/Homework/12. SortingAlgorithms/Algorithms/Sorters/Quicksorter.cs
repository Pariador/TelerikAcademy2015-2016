namespace SortingHomework.Sorters
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

	using Abstracts;

    public class QuickSorter<T> : Sorter<T> where T : IComparable<T>
    {
	    protected override IEnumerable<T> SafeSort(T[] array)
	    {
			return this.QuickSort(array.ToList());
	    }

	    protected List<T> QuickSort(List<T> items)
	    {
			if (items.Count <= 1)
			{
				return items;
			}

		    T pivot = items[0];

			List<T> lessOrEqual = new List<T>();
			List<T> greater = new List<T>();

			for (int i = 1; i < items.Count; i++)
			{
				if (this.Comparer.Compare(items[i], pivot) <= 0)
				{
					lessOrEqual.Add(items[i]);
				}
				else
				{
					greater.Add(items[i]);
				}
			}

			List<T> result = this.QuickSort(lessOrEqual);

			result.Add(pivot);
			result.AddRange(this.QuickSort(greater));

			return result;
	    }
    }
}