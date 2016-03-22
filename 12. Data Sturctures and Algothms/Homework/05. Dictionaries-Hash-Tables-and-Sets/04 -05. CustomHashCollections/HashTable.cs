namespace CustomHashCollections
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
	{
		private const int InitialSize = 16;

		private const int SizeMultiplier = 2;

		private const double LoadFactorBoundry = 0.75;

		public HashTable()
		{
			this.Count = 0;
			this.Buckets = new LinkedList<KeyValuePair<K, V>>[HashTable<K, V>.InitialSize];
		}

		public int Count { get; private set; }

		private LinkedList<KeyValuePair<K, V>>[] Buckets { get; set; }

		public V this[K key]
		{
			get
			{
				return this.Find(key);
			}

			set
			{
				if (this.ContainsKey(key))
				{
					this.Remove(key);
				}

				this.Add(key, value);
			}
		}

		public void Add(K key, V value)
		{
			this.Add(new KeyValuePair<K, V>(key, value));
		}

		public V Find(K key)
		{
			int index = this.GetIndex(key);
			var bucket = this.Buckets[index];

			if (bucket != null)
			{
				foreach (var pair in bucket)
				{
					if (pair.Key.Equals(key))
					{
						return pair.Value;
					}
				}
			}

			throw new ArgumentException("The given key was not present in the table.");
		}

		public bool Remove(K key)
		{
			int index = this.GetIndex(key);
			var bucket = this.Buckets[index];

			if (bucket != null)
			{
				foreach (var pair in bucket)
				{
					if (pair.Key.Equals(key))
					{
						this.Count--;
						return bucket.Remove(pair);
					}
				}
			}

			return false;
		}

		public void Clear()
		{
			for (int i = 0; i < this.Buckets.Length; i++)
			{
				this.Buckets[i] = null;
			}

			this.Count = 0;
		}

		public bool ContainsKey(K key)
		{
			int index = this.GetIndex(key);

			if (this.Buckets[index] != null)
			{
				return this.BucketContainsKey(this.Buckets[index], key);
			}
			
			return false;
		}

		public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
		{
			for (int i = 0; i < this.Buckets.Length; i++)
			{
				if (this.Buckets[i] != null)
				{
					foreach (var pair in this.Buckets[i])
					{
						yield return pair;
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private void Add(KeyValuePair<K, V> pair)
		{
			int index = this.GetIndex(pair.Key);

			if (this.Buckets[index] == null)
			{
				this.Buckets[index] = new LinkedList<KeyValuePair<K, V>>();
			}
			else if (this.BucketContainsKey(this.Buckets[index], pair.Key))
			{
				throw new ArgumentException("An item with the same key has already been added.");
            }

			this.Buckets[index].AddLast(pair);

			this.Count++;
			this.ResizeIfNeeded();
		}

		private int GetIndex(K key)
		{
			int hash = key.GetHashCode();

			int index = Math.Abs(hash) % this.Buckets.Length;

			return index;
		}

		private void ResizeIfNeeded()
		{
			double loadFactor = ((double)this.Count) / this.Buckets.Length;

			if (loadFactor < HashTable<K, V>.LoadFactorBoundry)
			{
				return;
			}

			var oldBuckets = this.Buckets;

			int size = this.Buckets.Length * HashTable<K, V>.SizeMultiplier;
			this.Buckets = new LinkedList<KeyValuePair<K, V>>[size];
			this.Count = 0;

			for (int i = 0; i < oldBuckets.Length; i++)
			{
				if (oldBuckets[i] != null)
				{
					foreach (var pair in oldBuckets[i])
					{
						this.Add(pair);
					}
				}
			}
		}

		private bool BucketContainsKey(LinkedList<KeyValuePair<K, V>> bucket, K key)
		{
			foreach (var pair in bucket)
			{
				if (pair.Key.Equals(key))
				{
					return true;
				}
			}

			return false;
		}
	}
}