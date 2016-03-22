namespace SourceControlSystem.Api.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Controllers;
    using System.Web.Http;
    using Services.Common;
    [TestClass]
    public class CommitsControllerTests
    {
        [TestMethod]
        public void ByProjectIdShouldMapToCorrectAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Commits/ByProject/1")
                .To<CommitsController>(c => c.GetByProjectId(new CommitRequest { Id = 1 }));
        }
    }
}
