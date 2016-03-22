namespace InfoSite.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	using Services;
	using ViewModels;

	public class CategoriesController : Controller
	{
		public CategoriesController()
		{
			this.AlgoService = new AlgorithmsService();
			this.CategoriesService = new CategoriesService();
		}

		public AlgorithmsService AlgoService { get; }

		public CategoriesService CategoriesService { get; }

		public ActionResult All(AllCategories model)
		{
			model.Categories = this.CategoriesService.All()
				.Select(category => new Category
				{
					Id = category.Id,
					Name = category.Name,
					AlgotithmsCount = this.AlgoService.All()
						.Count(algo => algo.Category == category)
				})
				.OrderByDescending(category => category.AlgotithmsCount);

			return this.View(model);
		}
	}
}