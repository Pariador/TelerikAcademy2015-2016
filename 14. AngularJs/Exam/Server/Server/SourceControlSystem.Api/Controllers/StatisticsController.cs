namespace SourceControlSystem.Api.Controllers
{
    using Data;
    using System.Web.Http;
    using System.Linq;

    public class StatisticsController : ApiController
    {
        public IHttpActionResult Get()
        {
            // NO TIME!
            var db = new SourceControlSystemDbContext();

            var users = db.Users.Count();
            var softwareProjects = db.SoftwareProjects.Count();
            var commits = db.Commits.Count();

            return this.Ok(new
            {
                Users = users,
                Projects = softwareProjects,
                Commits = commits
            });
        }
    }
}
