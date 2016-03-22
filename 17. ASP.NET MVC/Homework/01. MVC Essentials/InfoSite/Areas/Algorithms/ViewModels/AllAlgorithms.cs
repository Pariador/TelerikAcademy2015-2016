namespace InfoSite.Areas.Algorithms.ViewModels
{
	using System.Collections.Generic;

	using Data.Models;

	public class AllAlgorithms
	{
		public AllAlgorithms()
		{
			this.Categories = new Category[0];
			this.Algorithms = new Data.Models.Algorithm[0];
		}

		public int? DisplayCategoryId { get; set; }

		public IEnumerable<Category> Categories { get; set; }

		public IEnumerable<Data.Models.Algorithm> Algorithms { get; set; }
	}
}