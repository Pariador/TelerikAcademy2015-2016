namespace SourceControlSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models.Projects;
    using Services.Data.Contracts;
    using Services.Common;

    public class ProjectsController : ApiController
    {
        private readonly IProjectsService projects;

        public ProjectsController(IProjectsService projectsService)
        {
            this.projects = projectsService;
        }
        
        public IHttpActionResult Get()
        {
            var result = this.projects
                .All()
                .ProjectTo<SoftwareProjectDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var result = this.projects
                .ById(id, this.User.Identity.Name)
                .ProjectTo<SoftwareProjectDetailsResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveProjectRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.projects.Add(
                model.Name,
                model.Description,
                this.User.Identity.Name,
                model.LicenseId,
                model.Private);

            return this.Ok(createdProjectId);
        }

        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]string collaborator)
        {
            if (string.IsNullOrWhiteSpace(collaborator))
            {
                return this.BadRequest("Username is not valid");
            }

            var result = this.projects.AddCollaborator(
                id,
                this.User.Identity.Name,
                collaborator);

            if (!result)
            {
                return this.BadRequest("Username is not valid or you are not the owner of this repository");
            }

            return this.Ok();
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get([FromUri]ProjectRequest request)
        {
            string username = null;
            if (this.User.Identity.IsAuthenticated)
            {
                username = this.User.Identity.Name;
            }

            var result = this.projects
                .All(request, username)
                .ProjectTo<SoftwareProjectDetailsResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Route("api/projects/collaborators/{id}")]
        public IHttpActionResult GetCollaborators(int id)
        {
            string username = null;
            if (this.User.Identity.IsAuthenticated)
            {
                username = this.User.Identity.Name;
            }

            var result = this.projects
                .ById(id, username)
                .SelectMany(pr => pr.Users.Select(u => u.Email))
                .ToList();

            return this.Ok(result);
        }
    }
}
