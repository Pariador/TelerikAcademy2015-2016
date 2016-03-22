namespace MVC.Controllers
{
	using System.Web.Mvc;

	using Models;

	public class HomeController : Controller
	{
		// GET: Home
		[HttpGet]
		public ActionResult Index(double? first, double? second)
		{
			double firstAsDouble = first ?? 0;
			double secondAsDouble = second ?? 0;

			HomeModel model = new HomeModel
			{
				First = firstAsDouble,
				Second = secondAsDouble,
				Result = firstAsDouble + secondAsDouble
			};

			return this.View(model);
		}
	}
}