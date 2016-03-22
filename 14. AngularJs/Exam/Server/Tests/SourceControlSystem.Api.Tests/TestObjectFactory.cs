namespace SourceControlSystem.Api.Tests
{
    using System.Linq;
    using Models.Projects;
    using Moq;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using SourceControlSystem.Models;
    using System;
    using Services.Common;

    public static class TestObjectFactory
    {
        private static IQueryable<SoftwareProject> projects = new List<SoftwareProject>
        {
            new SoftwareProject
            {
                CreatedOn = new DateTime(2015, 11, 5, 23, 47, 12),
                Description = "Test Description",
                Name = "Test",
                Private = true
            }
        }.AsQueryable();

        private static IQueryable<Commit> commits = new List<Commit>
        {
            new Commit
            {
                CreatedOn = new DateTime(2015, 11, 5, 23, 47, 12),
                User = new User
                {
                    UserName = "User with commit"
                },
                Id = 1,
            }
        }.AsQueryable();

        public static IProjectsService GetProjectsService()
        {
            var projectsService = new Mock<IProjectsService>();

            projectsService.Setup(pr => pr.All(
                    It.IsAny<ProjectRequest>(),
                    It.IsAny<string>()))
                .Returns(projects);

            projectsService.Setup(pr => pr.ById(
                    It.Is<int>(s => s == 0),
                    It.IsAny<string>()))
                .Returns(new List<SoftwareProject>().AsQueryable());

            projectsService.Setup(pr => pr.ById(
                    It.Is<int>(s => s == 1),
                    It.IsAny<string>()))
                .Returns(projects);

            projectsService.Setup(pr => pr.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<bool>()))
                .Returns(1);

            return projectsService.Object;
        }
        
        public static ICommitsService GetCommitsService()
        {
            var commitsService = new Mock<ICommitsService>();

            commitsService.Setup(c => c.GetAll(
                    It.IsAny<CommitRequest>()))
                .Returns(commits);
            
            return commitsService.Object;
        }

        public static SaveProjectRequestModel GetInvalidModel()
        {
            return new SaveProjectRequestModel { Description = "TestDescription" };
        }
    }
}
