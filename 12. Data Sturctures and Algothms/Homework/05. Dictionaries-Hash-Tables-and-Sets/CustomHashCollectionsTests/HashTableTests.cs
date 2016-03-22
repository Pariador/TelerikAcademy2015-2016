namespace CustomHashCollectionsTests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	
	using CustomHashCollections;

	[TestClass]
	public class HashTableTests
	{
		public HashTable<string, string> Table;

		[TestInitialize]
		public void Init()
		{
			this.Table = new HashTable<string, string>();
		}

		[TestMethod]
		public void AddingItems()
		{
			for (int i = 67; i < 400; i++)
			{
				string key = "Batman" + (char)i;
				this.Table.Add(key, "#Value");
			}

			Assert.AreEqual(400 - 67, this.Table.Count, "Not all items were added.");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddingTheSameKeyTwiceShouldThrowArgumentException()

		{
			this.Table.Add("Harry", "Potter");
			this.Table.Add("Harry", "Potter");
		}

		[TestMethod]
		public void FindingItems()
		{
			string key = "Mary";
			string value = "Poppins";

			this.Table.Add(key, value);

			Assert.AreEqual(this.Table.Find(key), value, "Table didn't find the correct value.");
			Assert.AreEqual(this.Table[key], value, "Indexer didn't find the correct value.");
		}

		[TestMethod]
		public void ContainsKeyShouldReturnTrueIfKeyIsInTable()
		{
			string key = "THIS IS KEY";
			string value = "THIS IS VALUE";

			this.Table.Add(key, value);

			Assert.IsTrue(this.Table.ContainsKey(key), "ContainsKey can't find key.");
			Assert.IsFalse(this.Table.ContainsKey("Not a real key."), "ContainsKey found a wrong key.");
		}

		[TestMethod]
		public void RemoveShouldRemoveItemFromTable()
		{
			string key = "O_o";
			string value = "o_O";

			this.Table.Add(key, value);

			Assert.IsTrue(this.Table.Remove(key), "Remove didn't remove the item.");
			Assert.IsFalse(this.Table.Remove("Not a key."), "Table removed a value that it didn't have.");
			Assert.IsFalse(this.Table.ContainsKey(key), "Remove didn't remove the item.");
		}
	}
}