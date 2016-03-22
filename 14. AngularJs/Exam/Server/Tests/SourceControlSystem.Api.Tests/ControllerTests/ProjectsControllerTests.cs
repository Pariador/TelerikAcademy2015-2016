namespace SourceControlSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using MyTested.WebApi;
    using Models.Projects;
    using System.Collections.Generic;
    using System;
    using Services.Common;

    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void GetShouldHaveAuthorizedAttribute()
        {
            MyWebApi
                .Controller<ProjectsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
                .Calling(c => c.Get(1))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests());
        }

        [TestMethod]
        public void GetShouldReturnNotFoundWhenProjectIsNull()
        {
            MyWebApi
                .Controller<ProjectsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
                .WithAuthenticatedUser()
                .Calling(c => c.Get(0))
                .ShouldReturn()
                .NotFound();
        }
        
        [TestMethod]
        public void PostShouldValidateModelState()
        {
            MyWebApi
                .Controller<ProjectsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
                .Calling(c => c.Post(TestObjectFactory.GetInvalidModel()))
                .ShouldHave()
                .InvalidModelState();
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            MyWebApi
                .Controller<ProjectsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
                .Calling(c => c.Post(TestObjectFactory.GetInvalidModel()))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<SaveProjectRequestModel>()
                .ContainingModelStateErrorFor(m => m.Name);
        }
    }
}
