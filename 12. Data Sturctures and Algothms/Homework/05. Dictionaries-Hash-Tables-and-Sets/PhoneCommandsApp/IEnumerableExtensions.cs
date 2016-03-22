namespace PhoneCommandsApp
{
	using System;
	using System.Collections.Generic;

	public static class IEnumerableExtensions
	{
		public static Dictionary<K, List<V>> GroupInDictionary<K, V>(this IEnumerable<V> items, Func<V, K> getKey)
		{
			var dictionary = new Dictionary<K, List<V>>();

			foreach (var item in items)
			{
				K key = getKey(item);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<V>());
				}

				dictionary[key].Add(item);
			}

			return dictionary;
		}
	}
}