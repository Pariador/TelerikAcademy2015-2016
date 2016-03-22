namespace Teleimot.Common.Tools
{
	using System.Linq;
	using System.Collections.Generic;

	public static class ExtensionsIEnumerable
	{
		public static IEnumerable<T> Page<T>(this IEnumerable<T> items, int page = 1, int pageSize = 10)
		{
			return items.Skip((page - 1) * pageSize)
				.Take(pageSize);
		}
	}
}