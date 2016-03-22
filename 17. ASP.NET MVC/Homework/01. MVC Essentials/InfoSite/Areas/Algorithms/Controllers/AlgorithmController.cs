namespace InfoSite.Areas.Algorithms.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	using Services;
	using ViewModels;

	public class AlgorithmController : Controller
	{
		public AlgorithmController()
		{
			this.AlgoService = new AlgorithmsService();
			this.CategoriesService = new CategoriesService();
		}

		public AlgorithmsService AlgoService { get; }

		public CategoriesService CategoriesService { get; }

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return this.RedirectToAction("Index", "Main");
			}

			return this.View(this.AlgoService.GetById((int)id));
		}

		public ActionResult Add(AddAlgorithm model)
		{
			if (model.Algorithm == null)
			{
				AddAlgorithm newModel = new AddAlgorithm();

				newModel.Categories = this.CategoriesService.All()
					.OrderBy(category => category.Name);

				return this.View(newModel);
			}

			var algo = this.AlgoService.Add(new Data.Models.Algorithm
			{
				Name = model.Algorithm.Name,
				Category = this.CategoriesService.GetById(model.Algorithm.CategoryId),
				Author = model.Algorithm.Author,
				Summary = model.Algorithm.Summary,
				Description = model.Algorithm.Description,
				PseudoCode = model.Algorithm.PseudoCode,
				ImageUrl = model.Algorithm.ImageUrl
			});

			return this.RedirectToAction("Details", new { algo.Id });
		}
	}
}