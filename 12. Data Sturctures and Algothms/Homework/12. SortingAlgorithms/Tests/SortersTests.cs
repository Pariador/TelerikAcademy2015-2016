namespace Tests
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SortingHomework.Sorters;
	using SortingHomework.Sorters.Abstracts;

	[TestClass]
	public class SortersTests
	{
		[TestMethod]
		public void TestSelectionSorter()
		{
			var sorter = new SelectionSorter<int>();

			var result = sorter.Sort(Helper.Numbers);

			Assert.IsTrue(Sorter<int>.IsSorted(result.ToArray()), "Array not sorted.");
		}

		[TestMethod]
		public void TestQuickSorter()
		{
			var sorter = new QuickSorter<int>();

			var result = sorter.Sort(Helper.Numbers);

			Assert.IsTrue(Sorter<int>.IsSorted(result.ToArray()), "Array not sorted.");
		}

		[TestMethod]
		public void TestMergeSorter()
		{
			var sorter = new MergeSorter<int>();

			var result = sorter.Sort(Helper.Numbers);

			Assert.IsTrue(Sorter<int>.IsSorted(result.ToArray()), "Array not sorted.");
		}
	}
}