using BettingSite.Controllers.V1;
using BettingSite.Models;
using BettingSite.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BettingSite.Tests.Controllers.V1
{
    [TestClass]
    public class TeamsControllerTestcs
    {
        [TestMethod]
        public void getTeams()
        {
            List<Team> testObjects = new List<Team>();
            testObjects.Add(new Team { teamId = 1, name = "test1" });
            testObjects.Add(new Team { teamId = 2, name = "test2" });

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.GetAll())
                .Returns(testObjects.AsQueryable);

            TeamsController teamsController = new TeamsController(myMock.Object);

            IQueryable<Team> returnedTask = teamsController.GetTeams();

            var contentResult = returnedTask.ToList();

            Assert.IsNotNull(contentResult);

            Assert.AreEqual(contentResult.Count, 2);
            Assert.AreEqual(contentResult[0].teamId, 1);
            Assert.AreEqual(contentResult[1].teamId, 2);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void GetTeam()
        {
            int teamId = 1;
            String name = "test";

            Team testObject = new Team();
            testObject.teamId = teamId;
            testObject.name = name;

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.GetById(1))
                .Returns(Task.FromResult(testObject));

            TeamsController teamsController = new TeamsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = teamsController.GetTeam(1);

            var contentResult = returnedTask.Result as OkNegotiatedContentResult<Team>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            Assert.AreEqual(contentResult.Content.teamId, teamId);
            Assert.AreEqual(contentResult.Content.name, name);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void PutTeam()
        {
            int teamId = 1;
            String name = "test";
            Team testObject = new Team();
            testObject.teamId = teamId;
            testObject.name = name;

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.Update(teamId, testObject))
                .Returns(Task.FromResult(teamId));


            TeamsController teamsController = new TeamsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = teamsController.PutTeam(1, testObject);

            Assert.IsInstanceOfType(returnedTask.Result, typeof(StatusCodeResult));
            Assert.AreEqual(((StatusCodeResult)returnedTask.Result).StatusCode, HttpStatusCode.NoContent);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void PostTeam()
        {
            int teamId = 1;
            String name = "test";
            Team testObject = new Team();
            testObject.teamId = teamId;
            testObject.name = name;

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.Add(testObject))
                .Returns(Task.FromResult(teamId));


            TeamsController teamsController = new TeamsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = teamsController.PostTeam(testObject);

            var contentResult = returnedTask.Result as CreatedAtRouteNegotiatedContentResult<Team>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content.teamId, teamId);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteTeam()
        {
            int teamId = 1;
            String name = "test";
            Team testObject = new Team();
            testObject.teamId = teamId;
            testObject.name = name;

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.GetById(teamId))
                .Returns(Task.FromResult(testObject));

            myMock.Setup(x => x.Delete(testObject))
                .Returns(Task.FromResult(teamId));


            TeamsController teamsController = new TeamsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = teamsController.DeleteTeam(teamId);

            var contentResult = returnedTask.Result as OkNegotiatedContentResult<Team>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            Assert.AreEqual(contentResult.Content.teamId, teamId);
            Assert.AreEqual(contentResult.Content.name, name);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteTeam_NotFound()
        {
            int teamId = 1;
            String name = "test";
            Team testObject = new Team();
            testObject.teamId = teamId;
            testObject.name = name;

            Mock<ITeamRepository> myMock = new Mock<ITeamRepository>();
            myMock.Setup(x => x.GetById(teamId))
                .Returns(Task.FromResult((Team)null));

            myMock.Setup(x => x.Delete(testObject))
                .Returns(Task.FromResult(teamId));


            TeamsController teamsController = new TeamsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = teamsController.DeleteTeam(teamId);

            var contentResult = returnedTask.Result as NotFoundResult;

            Assert.IsNotNull(contentResult);

            myMock.Verify(mock => mock.GetById(teamId), Times.Once());
        }

    }
}
