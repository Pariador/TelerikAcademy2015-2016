namespace InfoSite.Areas.Algorithms.ViewModels
{
	using System.Collections.Generic;

	using Data.Models;

	public class AddAlgorithm
	{
		public AddAlgorithm()
		{
			this.Categories = new Category[0];
		}

		public Algorithm Algorithm { get; set; }

		public IEnumerable<Category> Categories { get; set; }
	}
}