namespace SortingHomework.Sorters.Abstracts
{
    using System;
    using System.Collections.Generic;

	public interface ISorter<T> where T : IComparable<T>
	{
		IEnumerable<T> Sort(IEnumerable<T> items);
	}
}