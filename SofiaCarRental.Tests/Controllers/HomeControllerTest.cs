using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofiaCarRental.Controllers;

namespace SofiaCarRental.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
