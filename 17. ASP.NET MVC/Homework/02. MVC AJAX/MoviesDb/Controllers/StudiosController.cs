namespace MoviesDb.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	public class StudiosController : BaseController
	{
		public ActionResult All()
		{
			return this.View(this.Db.Studios.ToArray());
		}
	}
}