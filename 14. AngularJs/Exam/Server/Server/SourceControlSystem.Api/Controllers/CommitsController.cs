namespace SourceControlSystem.Api.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models.Commits;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Services.Common;

    [RoutePrefix("api/Commits")]
    public class CommitsController : ApiController
    {
        private readonly ICommitsService commits;
        
        public CommitsController(ICommitsService commitsService)
        {
            this.commits = commitsService;
        }

        public IHttpActionResult Get()
        {
            var result = this.commits
                .GetAll()
                .ProjectTo<ListedCommitResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var result = this.commits
                .GetById(id)
                .ProjectTo<CommitDetailsResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(SaveCommitRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdCommitId = this.commits.Add(
                model.ProjectId,
                model.SourceCode,
                this.User.Identity.GetUserId());

            return this.Ok(createdCommitId);
        }

        [Authorize]
        [Route("ByProject/{id}")]
        [HttpGet]
        public IHttpActionResult GetByProjectId([FromUri]CommitRequest request)
        {
            var result = this.commits
                .GetAll(request)
                .ProjectTo<ListedCommitResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}
