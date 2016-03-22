namespace BiDictionary
{
	using System.Collections.Generic;
	using Wintellect.PowerCollections;

	public class BiDictionary<K1, K2, V>
	{
		public BiDictionary()
		{
			this.FirstDictionary = new MultiDictionary<K1, V>(false);
			this.SecondDictionary = new MultiDictionary<K2, V>(false);
		}

		private MultiDictionary<K1, V> FirstDictionary { get; set; }

		private MultiDictionary<K2, V> SecondDictionary { get; set; }

		public void AddWithFirstKey(K1 key, V value)
		{
			this.FirstDictionary.Add(key, value);
		}

		public void AddWithSecondKey(K2 key, V value)
		{
			this.SecondDictionary.Add(key, value);
		}

		public void AddWithKeys(K1 firstKey, K2 secondKey, V value)
		{
			this.FirstDictionary.Add(firstKey, value);
			this.SecondDictionary.Add(secondKey, value);
		}

		public ICollection<V> GetByFirstKey(K1 key)
		{
			return this.FirstDictionary[key];
		}

		public ICollection<V> GetBySecondKey(K2 key)
		{
			return this.SecondDictionary[key];
		}

		public ICollection<V> GetByKeys(K1 firstKey, K2 secondKey)
		{
			var set = new HashSet<V>(this.FirstDictionary[firstKey]);

			set.IntersectWith(this.SecondDictionary[secondKey]);

			return set;
		}

		public bool RemoveByFirstKey(K1 key)
		{
			return this.FirstDictionary.Remove(key);
		}

		public bool RemoveBySecondKey(K2 key)
		{
			return this.SecondDictionary.Remove(key);
		}

		public bool RemoveByKeys(K1 firstKey, K2 secondKey)
		{
			return this.FirstDictionary.Remove(firstKey) &&
			this.SecondDictionary.Remove(secondKey);
		}
	}
}