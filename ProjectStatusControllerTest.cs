using Bachelorprosjekt.Controllers;
using Bachelorprosjekt.Data;
using Bachelorprosjekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace TestProject4
{
    [TestClass]
    public class ProjectStatusControllerTest
    {
        public BachelorprosjektContext context;
        public ClaimsPrincipal User;
        public ProjectStatusController controller;

        [TestInitialize]
        public void BeforeEach()
        {
            User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "type1" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 2, Status = "type2" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 3, Status = "type3" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 4, Status = "type4" });

            var l = context.ProjectStatus.ToList();
            context.SaveChanges();
            controller = new ProjectStatusController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
        }

        [TestMethod]
        public async Task GetIndex()
        {

            var result = await controller.Index();
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (List<ProjectStatus>)x.ViewData.Model;


            Assert.AreEqual(4, p.Count);
        }
        [TestMethod]
        public void GetCreate()
        {


            var result = controller.Create();
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.AreEqual("Create", x.ViewName);
        }

        [TestMethod]
        public async Task PostCreate()
        {

            ProjectStatus o = new ProjectStatus { Id=5, Status = "type5"};

            var result = controller.Create(o);
            var x = await result as ViewResult;

            

            List<ProjectStatus> list = context.ProjectStatus.ToList();

            Assert.AreEqual(5, list.Count);
            

        }
        [TestMethod]
        public async Task GetEdit()
        {

            var result = await controller.Edit(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.IsNotNull(x.Model as ProjectStatus);


            Assert.AreEqual(4,(x.Model as ProjectStatus).Id);
        }

        [TestMethod]
        public async Task PostEdit()
        {      
            ProjectStatus o = context.ProjectStatus.Find(4);
            o.Status = "ny";

            Assert.AreNotEqual("ny", context.ProjectStatus.Find(4));

            var result = await controller.Edit(4,o);

            var x = result as ViewResult;

            ProjectStatus oFromContext = context.ProjectStatus.Find(1);
            
            Assert.AreEqual("ny", o.Status);


        }
        public async Task GetDelete()
        {
            var result = await controller.Delete(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            Assert.IsNotNull(x.Model as ProjectStatus);

            Assert.AreEqual(4, (x.Model as ProjectStatus).Id);
        }
        [TestMethod]
        public async Task PostDeleteConfirmedAsync()
        {

            ProjectStatus o = context.ProjectStatus.Find(4);
            Assert.IsNotNull(o);

            var result = await controller.DeleteConfirmed(4);
            var x = result as RedirectToActionResult;

            Assert.IsNotNull(x);

            o = context.ProjectStatus.Find(4);


            Assert.IsNull(o);
        }
    }
}