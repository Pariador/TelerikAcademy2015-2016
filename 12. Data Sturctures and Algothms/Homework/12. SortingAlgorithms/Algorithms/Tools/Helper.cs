namespace SortingHomework.Tools
{
	using System;

	public static class Helper
	{
		private static readonly Lazy<Random> LazyRandom = new Lazy<Random>();

		public static Random Random
		{
			get
			{
				return Helper.LazyRandom.Value;
			}
		}

		public static void Swap<T>(ref T first, ref T second)
		{
			T holder = first;
			first = second;
			second = holder;
		}

		public static int DefaultCompare<T>(T first, T second) where T : IComparable<T>
		{
			return first.CompareTo(second);
		}
	}
}