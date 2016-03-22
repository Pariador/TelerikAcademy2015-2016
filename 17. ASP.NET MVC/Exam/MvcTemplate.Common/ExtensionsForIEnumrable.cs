namespace MvcTemplate.Common
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class ExtensionsIEnumerable
	{
		public static IEnumerable<T> Page<T>(this IEnumerable<T> items, int page, int pageSize = GlobalConstants.DefaultPageSize)
		{
			return ExtensionsForIQueryable.Page(items.AsQueryable(), page, pageSize);
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (var item in items)
			{
				action(item);
			}

			return items;
		}
	}
}