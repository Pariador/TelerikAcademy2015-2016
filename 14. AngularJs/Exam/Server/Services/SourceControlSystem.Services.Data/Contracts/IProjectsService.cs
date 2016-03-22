namespace SourceControlSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;
    using Common;

    public interface IProjectsService
    {
        IQueryable<SoftwareProject> All(ProjectRequest request = null, string username = null);

        int Add(string name, string description, string creator, int licenseId, bool isPrivate = false);

        IQueryable<SoftwareProject> ById(int projectId, string username);

        bool AddCollaborator(int id, string creator, string username);
    }
}
