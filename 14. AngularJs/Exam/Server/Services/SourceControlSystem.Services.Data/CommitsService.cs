namespace SourceControlSystem.Services.Data
{
    using System.Linq;
    using Models;
    using SourceControlSystem.Services.Data.Contracts;
    using SourceControlSystem.Data;
    using System;
    using Common;
    public class CommitsService : ICommitsService
    {
        private readonly IRepository<Commit> commits;

        public CommitsService(IRepository<Commit> commitsRepository)
        {
            this.commits = commitsRepository;
        }

        public int Add(int projectId, string sourceCode, string collaboratorId)
        {
            var newCommit = new Commit
            {
                SoftwareProjectId = projectId,
                SourceCode = sourceCode,
                UserId = collaboratorId,
                CreatedOn = DateTime.Now
            };

            this.commits.Add(newCommit);
            this.commits.SaveChanges();

            return newCommit.Id;
        }

        public IQueryable<Commit> GetById(int id)
        {
            return this.commits.All()
                .Where(c => c.Id == id);
        }

        public IQueryable<Commit> GetAll(CommitRequest request = null)
        {
            request = request ?? new CommitRequest();

            var query = this.commits.All();

            if (request.Id != 0)
            {
                query = query.Where(c => c.SoftwareProjectId == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.ByUser))
            {
                query = query.Where(c => c.User.Email == request.ByUser);
            }

            return query
                .OrderByDescending(c => c.CreatedOn)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize);
        }
    }
}
