namespace MvcTemplate.Web.Areas.Administration.Controllers
{
	using System.Web.Mvc;

	[Authorize]
	public class IdeasController : Controller
	{
		public ActionResult Index()
		{
			return this.View();
		}
	}
}