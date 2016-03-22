namespace SourceControlSystem.Api.Controllers
{
    using Data;
    using System.Web.Http;
    using System.Linq;

    public class LicensesController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            // NO TIME!
            var db = new SourceControlSystemDbContext();

            var result = db.Licenses
                .Select(l => new
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToList();

            return this.Ok(result);
        }
    }
}
