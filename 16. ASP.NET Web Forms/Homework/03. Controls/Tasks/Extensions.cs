namespace Tasks
{
	using System;
	using System.Collections.Generic;

	public static class Extensions
	{
		public static string Join<T>(this IEnumerable<T> items, string separator)
		{
			return string.Join(separator, items);
		}

		public static LinkedListNode<T> Find<T>(this LinkedList<T> list, Predicate<LinkedListNode<T>> predicate)
		{
			var current = list.First;
			while (current != null)
			{
				if (predicate(current))
				{
					return current;
				}	

				current = current.Next;
			}

			return null;
		}
	}
}