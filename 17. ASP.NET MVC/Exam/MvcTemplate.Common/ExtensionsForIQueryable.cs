namespace MvcTemplate.Common
{
	using System;
	using System.Linq;

	public static class ExtensionsForIQueryable
	{
		public static IQueryable<T> Page<T>(this IQueryable<T> items, int page, int pageSize = GlobalConstants.DefaultPageSize)
		{
			const int FirstPage = 1;
			if (page < FirstPage)
			{
				throw new ArgumentException($"{nameof(page)} can't be less then {FirstPage}. Value: {page}");
			}

			return items.Skip((page - FirstPage) * pageSize)
				.Take(pageSize);
		}
	}
}