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
    public class SportsControllerTest
    {
        [TestMethod]
        public void getSports()
        {
            List<Sport> testObjects = new List<Sport>();
            testObjects.Add(new Sport { sportId = 1, name = "test1" });
            testObjects.Add(new Sport { sportId = 2, name = "test2" });

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.GetAll())
                .Returns(testObjects.AsQueryable);

            SportsController sportsController = new SportsController(myMock.Object);

            IQueryable<Sport> returnedTask = sportsController.GetSports();

            var contentResult = returnedTask.ToList();

            Assert.IsNotNull(contentResult);

            Assert.AreEqual(contentResult.Count, 2);
            Assert.AreEqual(contentResult[0].sportId, 1);
            Assert.AreEqual(contentResult[1].sportId, 2);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void GetSport()
        {
            int sportId = 1;
            String name = "test";

            Sport testObject = new Sport();
            testObject.sportId = sportId;
            testObject.name = name;

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.GetById(1))
                .Returns(Task.FromResult(testObject));

            SportsController sportsController = new SportsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = sportsController.GetSport(1);

            var contentResult = returnedTask.Result as OkNegotiatedContentResult<Sport>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            Assert.AreEqual(contentResult.Content.sportId, sportId);
            Assert.AreEqual(contentResult.Content.name, name);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void PutSport()
        {
            int sportId = 1;
            String name = "test";
            Sport testObject = new Sport();
            testObject.sportId = sportId;
            testObject.name = name;

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.Update(sportId, testObject))
                .Returns(Task.FromResult(sportId));


            SportsController sportsController = new SportsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = sportsController.PutSport(1, testObject);

            Assert.IsInstanceOfType(returnedTask.Result, typeof(StatusCodeResult));
            Assert.AreEqual(((StatusCodeResult)returnedTask.Result).StatusCode, HttpStatusCode.NoContent);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void PostSport()
        {
            int sportId = 1;
            String name = "test";
            Sport testObject = new Sport();
            testObject.sportId = sportId;
            testObject.name = name;

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.Add(testObject))
                .Returns(Task.FromResult(sportId));


            SportsController sportsController = new SportsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = sportsController.PostSport(testObject);

            var contentResult = returnedTask.Result as CreatedAtRouteNegotiatedContentResult<Sport>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content.sportId, sportId);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteSport()
        {
            int sportId = 1;
            String name = "test";
            Sport testObject = new Sport();
            testObject.sportId = sportId;
            testObject.name = name;

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.GetById(sportId))
                .Returns(Task.FromResult(testObject));

            myMock.Setup(x => x.Delete(testObject))
                .Returns(Task.FromResult(sportId));


            SportsController sportsController = new SportsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = sportsController.DeleteSport(sportId);

            var contentResult = returnedTask.Result as OkNegotiatedContentResult<Sport>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            Assert.AreEqual(contentResult.Content.sportId, sportId);
            Assert.AreEqual(contentResult.Content.name, name);

            myMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteSport_NotFound()
        {
            int sportId = 1;
            String name = "test";
            Sport testObject = new Sport();
            testObject.sportId = sportId;
            testObject.name = name;

            Mock<ISportRepository> myMock = new Mock<ISportRepository>();
            myMock.Setup(x => x.GetById(sportId))
                .Returns(Task.FromResult((Sport)null));

            myMock.Setup(x => x.Delete(testObject))
                .Returns(Task.FromResult(sportId));


            SportsController sportsController = new SportsController(myMock.Object);

            Task<IHttpActionResult> returnedTask = sportsController.DeleteSport(sportId);

            var contentResult = returnedTask.Result as NotFoundResult;

            Assert.IsNotNull(contentResult);
            
            myMock.Verify(mock => mock.GetById(sportId), Times.Once());
        }

    }
}
