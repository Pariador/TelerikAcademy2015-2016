namespace SourceControlSystem.Services.Data.Contracts
{
    using Common;
    using SourceControlSystem.Models;
    using System.Linq;

    public interface ICommitsService
    {
        int Add(int projectId, string sourceCode, string collaborator);

        IQueryable<Commit> GetAll(CommitRequest request = null);

        IQueryable<Commit> GetById(int id);
    }
}
