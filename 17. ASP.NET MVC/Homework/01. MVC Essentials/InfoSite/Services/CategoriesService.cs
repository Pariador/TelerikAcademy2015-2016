namespace InfoSite.Services
{
	using System.Collections.Generic;

	using Data;
	using Data.Models;

	public class CategoriesService
	{
		public Category GetById(int id)
		{
			return Database.Categories.Find(category => category.Id == id);
		}

		public IEnumerable<Category> All()
		{
			return Database.Categories;
		}
	}
}