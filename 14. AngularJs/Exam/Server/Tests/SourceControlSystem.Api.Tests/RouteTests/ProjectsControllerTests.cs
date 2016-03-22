namespace SourceControlSystem.Api.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Controllers;
    using System.Net.Http;
    using Models.Projects;
    using System.Web.Http;
    using Services.Common;

    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Projects")
                .To<ProjectsController>(c => c.Get());
        }

        [TestMethod]
        public void GetWithIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Projects/1")
                .To<ProjectsController>(c => c.Get(1));
        }

        [TestMethod]
        public void AllShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/projects/all?page=1&pageSize=10")
                .To<ProjectsController>(c => c.Get(new ProjectRequest()));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Projects")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""Private"": true }")
                .To<ProjectsController>(c => c.Post(new SaveProjectRequestModel
                {
                    Name = "Test",
                    Private = true
                }));
        }
    }
}
