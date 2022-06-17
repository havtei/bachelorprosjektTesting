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
    public class DomainControllerTest
    {
        public BachelorprosjektContext context;
        public ClaimsPrincipal User;
        public DomainsController controller;
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

            context.Domain.Add(new Domain { Id = 1, Name = "type1" });
            context.Domain.Add(new Domain { Id = 2, Name = "type2" });
            context.Domain.Add(new Domain { Id = 3, Name = "type3" });
            context.Domain.Add(new Domain { Id = 4, Name = "type4" });

            var l = context.Domain.ToList();
            context.SaveChanges();
            controller = new DomainsController(context);
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
        }

        [TestMethod]
        public async Task GetIndex()
        {

            var result = await controller.Index();
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (List<Domain>)x.ViewData.Model;


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
            Domain o = new Domain { Id=5,Name="type5"};

            var result = controller.Create(o);
            var x = await result as ViewResult;

            List<Domain> list = context.Domain.ToList();

            Assert.AreEqual(5, list.Count);    

        }
        [TestMethod]
        public async Task GetEdit()
        {
            var result = await controller.Edit(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            Assert.IsNotNull(x.Model as Domain);

            Assert.AreEqual(4,(x.Model as Domain).Id);
        }

        [TestMethod]
        public async Task PostEdit()
        {
            Domain o = context.Domain.Find(4);
            o.Name = "ny";

            Assert.AreNotEqual("ny", context.Domain.Find(4));

            var result = await controller.Edit(4,o);

            var x = result as ViewResult;

            Domain oFromContext = context.Domain.Find(1);
            
            Assert.AreEqual("ny", o.Name);

        }
        [TestMethod]
        public async Task GetDelete()
        {
            var result = await controller.Delete(4);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            Assert.IsNotNull(x.Model as Domain);

            Assert.AreEqual(4, (x.Model as Domain).Id);
        }
        [TestMethod]
        public async Task PostDeleteConfirmedAsync()
        {
            
            Domain o = context.Domain.Find(4);
            Assert.IsNotNull(o);

            var result = await controller.DeleteConfirmed(4);
            var x = result as RedirectToActionResult;

            Assert.IsNotNull(x);

            o = context.Domain.Find(4);


            Assert.IsNull(o);
        }
    }
}