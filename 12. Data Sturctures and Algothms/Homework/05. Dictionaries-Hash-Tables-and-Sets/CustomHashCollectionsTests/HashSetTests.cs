namespace CustomHashCollectionsTests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using CustomHashCollections;

	[TestClass]
	public class HashSetTests
	{
		public Set<string> Set;

		[TestInitialize]
		public void Init()
		{
			this.Set = new Set<string>();
		}

		[TestMethod]
		public void AddingItems()
		{
			for (int i = 67; i < 400; i++)
			{
				string value = "Batman" + (char)i;
				this.Set.Add(value);
			}

			Assert.AreEqual(400 - 67, this.Set.Count, "Not all items were added.");
		}

		[TestMethod]
		public void SetShouldNotHoldDuplicateValues()
		{
			this.Set.Add("Harry");
			this.Set.Add("Harry");

			Assert.AreEqual(this.Set.Count, 1, "Duplicate values added to set.");
		}

		[TestMethod]
		public void ContainsShouldReturnTrueIfKeyIsInSet()
		{
			string value = "THIS IS VALUE";

			this.Set.Add(value);

			Assert.IsTrue(this.Set.Contains(value), "Contains can't find value.");
			Assert.IsFalse(this.Set.Contains("Not a real value."), "Contains found a wrong key.");
		}

		[TestMethod]
		public void RemoveShouldRemoveItemFromSet()
		{
			string value = "o_O";

			this.Set.Add(value);

			Assert.IsTrue(this.Set.Remove(value), "Remove didn't remove the item.");
			Assert.IsFalse(this.Set.Remove("Not a key."), "Set removed a value that it didn't have.");
			Assert.IsFalse(this.Set.Contains(value), "Remove didn't remove the item.");
		}
	}
}