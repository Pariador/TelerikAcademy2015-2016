namespace InfoSite.Controllers
{
	using System.Web.Mvc;

	using Services;
	using ViewModels;

	public class HomeController : Controller
	{
		public HomeController()
		{
			this.AlgorithmsService = new AlgorithmsService();
		}

		protected AlgorithmsService AlgorithmsService { get; }

		public ActionResult Index()
		{
			TopAlgorithms top = new TopAlgorithms(this.AlgorithmsService.GetTop(10));

			return this.View(top);
		}
	}
}