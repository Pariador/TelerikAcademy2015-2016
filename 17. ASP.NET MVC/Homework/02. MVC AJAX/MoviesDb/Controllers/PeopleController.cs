namespace MoviesDb.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	public class PeopleController : BaseController
	{
		public ActionResult All()
		{
			return this.View(this.Db.People.ToArray());
		}
	}
}