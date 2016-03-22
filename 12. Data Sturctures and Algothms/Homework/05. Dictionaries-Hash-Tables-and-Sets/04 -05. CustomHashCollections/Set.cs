namespace CustomHashCollections
{
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;

	public class Set<T> : IEnumerable<T>
	{
		public Set()
		{
			this.Table = new HashTable<int, T>();	
		}

		private HashTable<int, T> Table { get; set; }

		public int Count
		{
			get
			{
				return this.Table.Count;
			}
		}

		public void Add(T item)
		{
			this.Table[item.GetHashCode()] = item;
		}

		public bool Remove(T item)
		{
			return this.Table.Remove(item.GetHashCode());
		}

		// Sets don't need Find(T) they need Contains(T).
		public bool Contains(T item)
		{
			return this.Table.ContainsKey(item.GetHashCode());
		}

		public void Clear()
		{
			this.Table.Clear();
		}

		public void UnionWith(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				this.Add(item);
			}
		}

		public void IntersectWith(IEnumerable<T> items)
		{
			List<T> forDelettion = new List<T>();

			foreach (var item in this)
			{
				if (!items.Contains(item))
				{
					forDelettion.Add(item);
				}
			}

			foreach (var item in forDelettion)
			{
				this.Remove(item);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var item in this.Table)
			{
				yield return item.Value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}