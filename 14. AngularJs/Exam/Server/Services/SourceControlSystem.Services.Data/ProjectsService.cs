namespace SourceControlSystem.Services.Data
{
    using System;
    using System.Linq;
    using Models;
    using SourceControlSystem.Data;
    using SourceControlSystem.Services.Data.Contracts;
    using Common;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<SoftwareProject> projects;
        private readonly IRepository<User> users;

        public ProjectsService(
            IRepository<SoftwareProject> projectsRepo,
            IRepository<User> usersRepo)
        {
            this.projects = projectsRepo;
            this.users = usersRepo;
        }

        public int Add(string name, string description, string creator, int licenseId, bool isPrivate = false)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == creator);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var newProject = new SoftwareProject
            {
                Name = name,
                Description = description,
                Private = isPrivate,
                LicenseId = licenseId,
                CreatedOn = DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.Id;
        }

        public IQueryable<SoftwareProject> ById(int projectId, string username)
        {
            return this.projects
                .All()
                .Where(pr =>
                    pr.Id == projectId
                    && (!pr.Private
                        || (pr.Private
                            && pr.Users.Any(c => c.UserName == username))));
        }

        public IQueryable<SoftwareProject> All(ProjectRequest request = null, string username = null)
        {
            request = request ?? new ProjectRequest();

            var query = this.projects.All().Where(pr => !pr.Private);

            if (!string.IsNullOrWhiteSpace(username) && !request.OnlyPublic)
            {
                query = this.projects
                    .All()
                    .Where(pr => !pr.Private
                        || (pr.Private && pr.Users.Any(c => c.Email == username)));
            }

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                query = query
                    .Where(pr => pr.Name.ToLower().Contains(request.Filter.ToLower())
                        || pr.Description.ToLower().Contains(request.Filter.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(request.ByUser))
            {
                query = query
                    .Where(pr => pr.Users.Any(u => u.Email == request.ByUser));
            }

            if (request.OrderBy == "collaborators")
            {
                if (request.OrderType == "desc")
                {
                    query = query.OrderByDescending(pr => pr.Users.Count());
                }
                else
                {
                    query = query.OrderBy(pr => pr.Users.Count());
                }
            }
            else if (request.OrderBy == "name")
            {
                if (request.OrderType == "desc")
                {
                    query = query.OrderByDescending(pr => pr.Name);
                }
                else
                {
                    query = query.OrderBy(pr => pr.Name);
                }
            }
            else
            {
                if (request.OrderType == "desc")
                {
                    query = query.OrderByDescending(pr => pr.CreatedOn);
                }
                else
                {
                    query = query.OrderBy(pr => pr.CreatedOn);
                }
            }

            return query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize);
        }

        public bool AddCollaborator(int id, string creator, string collaborator)
        {
            var project = this.projects.GetById(id);

            if (project == null || !project.Users.Any(u => u.Email == creator))
            {
                return false;
            }

            var user = this.users.All().FirstOrDefault(u => u.Email == collaborator);

            if (user == null)
            {
                return false;
            }

            if (!project.Users.Contains(user))
            {
                project.Users.Add(user);
                this.projects.SaveChanges();
            }

            return true;
        }
    }
}
