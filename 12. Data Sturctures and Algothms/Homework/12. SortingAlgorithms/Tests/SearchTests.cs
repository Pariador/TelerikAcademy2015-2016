namespace Tests
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SortingHomework.Tools.Extensions;

	[TestClass]
	public class SearchTests
	{
		[TestMethod]
		public void TestLinearSearch()
		{
			Assert.IsTrue(Helper.Numbers.LinearSearch(Helper.Numbers[3]), "Number in array not found.");
			Assert.IsFalse(Helper.Numbers.LinearSearch(Helper.Numbers[3] - 1), "Found a number not in the array.");
		}

		[TestMethod]
		public void TestCustomBinarySearch()
		{
			int[] sorted = Helper.Numbers.OrderBy(number => number).ToArray();
			Assert.IsTrue(sorted.CustomBinarySearch(sorted[3]), "Number in array not found.");
			Assert.IsFalse(sorted.CustomBinarySearch(sorted[3] - 1), "Found a number not in the array.");
		}
	}
}