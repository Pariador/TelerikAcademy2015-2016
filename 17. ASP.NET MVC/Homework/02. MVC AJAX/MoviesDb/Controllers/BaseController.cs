namespace MoviesDb.Web.Controllers
{
	using System.Web.Mvc;

	using Data;

	public abstract class BaseController : Controller
	{
		protected BaseController()
		{
			this.Db = new MoviesDbContext();
		}

		protected MoviesDbContext Db { get; }

		protected override void Dispose(bool disposing)
		{
			this.Db.Dispose();

			base.Dispose(disposing);
		}
	}
}