namespace SourceControlSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http.Results;
    using Models.Commits;
    using System.Collections.Generic;
    using Services.Data.Contracts;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http;
    using TestObjects;
    using MyTested.WebApi;
    using Services.Common;
    [TestClass]
    public class CommitsControllerTests
    {
        private ICommitsService commitsService;

        [TestInitialize]
        public void Init()
        {
            this.commitsService = TestObjectFactory.GetCommitsService();
        }

        [TestMethod]
        public void GetByProjectIdShouldReturnOkResultWithData()
        {
            var controller = new CommitsController(this.commitsService);

            var result = controller.GetByProjectId(new CommitRequest { Id = 1 });

            var okResult = result as OkNegotiatedContentResult<List<ListedCommitResponseModel>>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(1, okResult.Content.Count);
        }
    }
}
