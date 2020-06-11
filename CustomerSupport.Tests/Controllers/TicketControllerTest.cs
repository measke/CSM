using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerSupport.Controllers;
using CustomerSupport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerSupport.Tests.Controllers
{
    [TestClass]
    public class TicketControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            TicketController controller = new TicketController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void IndexModel()
        {
            // Arrange
            TicketController controller = new TicketController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(List<Ticket>));
        }
        
        [TestMethod]
        public void Update()
        {
            // Arrange
            TicketController controller = new TicketController();

            //Act
            RedirectToActionResult result = controller.Update(1) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Add()
        {
            // Arrange
            TicketController controller = new TicketController();

            //Act
            RedirectToActionResult result = controller.Update(1) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
