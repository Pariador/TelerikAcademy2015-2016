namespace MoviesDb.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	public class MoviesController : BaseController
	{
		public ActionResult All()
		{
			return this.View(this.Db.Movies.ToArray());
		}
	}
}