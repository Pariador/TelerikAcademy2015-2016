namespace Exam.Services
{
	using System.Linq;

	using Exam.Data;
	using Exam.Data.Models;
	using Exam.Data.Repositories;

	public class CategoryService
	{
		private IRepository<Category> categories;

		public CategoryService()
		{
			this.categories = new GenericRepository<Category>(new AppDbContext());
		}

		public IQueryable<Category> All()
		{
			return this.categories.All();
		}
	}
}