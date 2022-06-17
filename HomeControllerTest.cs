using Bachelorprosjekt.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace TestProject4
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetIndexFagansvarlig()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var mocked = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = logger = Mock.Of<ILogger<HomeController>>();

            var controller = new HomeController(logger);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = controller.Index() as ViewResult;
            //Assert.AreEqual("getmyprojects", result.ViewName);

            Assert.IsNotNull(result);
            Assert.AreEqual("Administrasjon", result.ViewName);
        }
        [TestMethod]
        public void GetIndexBedrift()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "mock"));

            var mocked = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = logger = Mock.Of<ILogger<HomeController>>();

            var controller = new HomeController(logger);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = (RedirectResult)controller.Index();
            //Assert.AreEqual("getmyprojects", result.ViewName);
            
            Assert.IsNotNull(result);
            Assert.AreEqual("ProsjektDescriptions/getmyprojects", result.Url);
        }


        [TestMethod]
        public void GetPrivacy()
        {


            var mocked = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = logger = Mock.Of<ILogger<HomeController>>();

            var controller = new HomeController(logger);

            
            var result = controller.Privacy() as ViewResult;
            Assert.IsNotNull(result);

        }
       

    }
}