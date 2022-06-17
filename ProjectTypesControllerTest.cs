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
    public class ProjectTypeControllerTest
    {
        public BachelorprosjektContext context;
        public ClaimsPrincipal User;
        public ProjectTypesController controller;

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

            context.ProjectType.Add(new ProjectType { Id = 1, Name = "type1" });
            context.ProjectType.Add(new ProjectType { Id = 2, Name = "type2" });
            context.ProjectType.Add(new ProjectType { Id = 3, Name = "type3" });
            context.ProjectType.Add(new ProjectType { Id = 4, Name = "type4" });

            var l = context.ProjectType.ToList();
            context.SaveChanges();

            controller = new ProjectTypesController(context);

        }

        [TestMethod]
        public async Task GetIndex()
        {
            var result = await controller.Index();
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (List<ProjectType>)x.ViewData.Model;


            Assert.AreEqual(4, p.Count);
        }
        [TestMethod]
        public void GetCreate()
        {
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = controller.Create();
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.AreEqual("Create", x.ViewName);
        }

        [TestMethod]
        public async Task PostCreate()
        {

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            ProjectType o = new ProjectType { Id=5,Name="type5"};

            var result = controller.Create(o);
            var x = await result as ViewResult;

            

            List<ProjectType> list = context.ProjectType.ToList();

            Assert.AreEqual(5, list.Count);
            

        }
        [TestMethod]
        public async Task GetEdit()
        {


            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Edit(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.IsNotNull(x.Model as ProjectType);


            Assert.AreEqual(4,(x.Model as ProjectType).Id);
        }

        [TestMethod]
        public async Task PostEdit()
        {
           
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            ProjectType o = context.ProjectType.Find(4);
            o.Name = "ny";

            Assert.AreNotEqual("ny", context.ProjectType.Find(4));

            var result = await controller.Edit(4,o);

            var x = result as ViewResult;

            ProjectType oFromContext = context.ProjectType.Find(1);
            
            Assert.AreEqual("ny", o.Name);


        }
        public async Task GetDelete()
        {
            var result = await controller.Delete(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            Assert.IsNotNull(x.Model as ProjectType);

            Assert.AreEqual(4, (x.Model as ProjectType).Id);
        }
        [TestMethod]
        public async Task PostDeleteConfirmedAsync()
        {

            ProjectType o = context.ProjectType.Find(4);
            Assert.IsNotNull(o);

            var result = await controller.DeleteConfirmed(4);
            var x = result as RedirectToActionResult;

            Assert.IsNotNull(x);

            o = context.ProjectType.Find(4);


            Assert.IsNull(o);
        }
    }
}