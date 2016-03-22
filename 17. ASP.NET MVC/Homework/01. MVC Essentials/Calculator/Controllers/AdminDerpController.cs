namespace Calculator.Controllers
{
	using System.Web.Mvc;

	public class AdminDerpController : Controller
	{
		public ActionResult Index()
		{
			return this.Content("ADMIN");
		}
	}
}