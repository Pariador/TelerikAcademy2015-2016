namespace SortingHomework.Sorters.Abstracts
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	using Tools;

	public abstract class Sorter<T> : ISorter<T> where T : IComparable<T>
	{
		public static bool IsSorted(T[] items)
		{
			for (int i = 1; i < items.Length; i++)
			{
				if (items[i - 1].CompareTo(items[i]) == 1)
				{
					return false;
				}
			}

			return true;
		}

		protected Sorter(Comparer<T> comparer)
		{
			this.Comparer = comparer;
		}

		protected Sorter(Comparison<T> compare)
			: this(Comparer<T>.Create(compare))
		{
			;
		}

		protected Sorter()
			: this(Helper.DefaultCompare)
		{
			;
		}

		public Comparer<T> Comparer { get; set; }

		public IEnumerable<T> Sort(IEnumerable<T> items)
		{
			return this.SafeSort(items.ToArray());
		}

		protected abstract IEnumerable<T> SafeSort(T[] array);
	}
}