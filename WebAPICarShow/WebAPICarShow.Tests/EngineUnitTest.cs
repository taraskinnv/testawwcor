using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPICarShow.Controllers;
using WebAPICarShow.Models;


namespace WebAPICarShow.Tests
{
    [TestClass]
    public class EngineUnitTest
    {
        [TestMethod]
        public void GetAll()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Act on Test
            var response = controller.GetEngine();
            var contentResult = response as OkNegotiatedContentResult<IQueryable<Engine>>;

            // Assert the result

            Assert.AreEqual(3, response.Count());
        }

        [TestMethod]
        public void GetByEngineId()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Act on Test
            var response = controller.GetEngine(1);
            var contentResult = response as OkNegotiatedContentResult<Engine>;

            // Assert the result
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.id);
            Assert.AreEqual("Petrol", contentResult.Content.typeEngine);
        }

        [TestMethod]
        public void GetEngineNotFound()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Act
            var actionResult = controller.GetEngine(4);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostEngine()
        {
            // Arrange
            var controller = new EnginesController();

            Engine engine = new Engine()
            {
                id = 4, 
                typeEngine = "Hibrid"
            };

            // Act
            IHttpActionResult actionResult = controller.PostEngine(engine);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Engine>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void PutEngineBadRequest()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Arrange  
            Engine engine = new Engine()
            {
                id = 4,
                typeEngine = "Hibrid2"
            };

            // Act
            var actionResult = controller.PutEngine(5, engine);

            // Act  
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));

        }

        [TestMethod]
        public void PutEngineOk()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Arrange  
            Engine engine = new Engine()
            {
                id = 4,
                typeEngine = "Hibrid"
            };

            // Act
            var actionResult = controller.PutEngine(4, engine);
            var contentResult = actionResult as NegotiatedContentResult<StatusCodeResult>;

            Assert.AreEqual(204, (int)((StatusCodeResult)actionResult).StatusCode);

        }

        [TestMethod]
        public void DeleteEngineNotFound()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();

            // Act
            var actionResult = controller.DeleteEngine(5);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteEngineOk()
        {
            // Set up Prerequisites 
            var controller = new EnginesController();


            // Act
            var actionResult = controller.DeleteEngine(4);
            var contentResult = actionResult as OkNegotiatedContentResult<Engine>;

            // Assert the result
            Assert.AreEqual(4, contentResult.Content.id);
        }
    }
}
