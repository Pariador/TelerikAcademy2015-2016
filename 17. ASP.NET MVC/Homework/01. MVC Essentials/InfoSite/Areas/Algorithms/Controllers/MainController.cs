namespace InfoSite.Areas.Algorithms.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	using Services;
	using ViewModels;

	public class MainController : Controller
    {
		public MainController()
		{
			this.AlgoService = new AlgorithmsService();
			this.CategoriesService = new CategoriesService();
		}

		public AlgorithmsService AlgoService { get; }

		public CategoriesService CategoriesService { get; set; }

		public ActionResult Index(AllAlgorithms model)
        {
			model.Categories = this.CategoriesService.All()
				.OrderBy(category => category.Name);

			model.Algorithms = this.AlgoService.All();

			if (model.DisplayCategoryId != null)
			{
				model.Algorithms = model.Algorithms.Where(algo => algo.Category.Id == model.DisplayCategoryId);
			}

			model.Algorithms = 	model.Algorithms.OrderByDescending(algo => algo.Rating); 

            return this.View(model);
        }
    }
}