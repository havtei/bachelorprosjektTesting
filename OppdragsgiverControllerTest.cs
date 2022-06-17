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
    public class OppdragsgiverControllerTest
    {
        [TestMethod]
        public async Task GetIndex()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "5", IsActive = true});
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "6", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "7", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "8", IsActive = true });

            var l = context.Oppdragsgiver.ToList();
            context.SaveChanges();
            var controller = new OppdragsgiverController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Index();
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (List<Oppdragsgiver>)x.ViewData.Model;


            Assert.AreEqual(4, p.Count);
        }
        [TestMethod]
        public void  GetCreate()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "5", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "6", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "7", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "8", IsActive = true });

            var l = context.Oppdragsgiver.ToList();
            context.SaveChanges();
            var controller = new OppdragsgiverController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = controller.Create();
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.AreEqual("Create", x.ViewName);
        }

        [TestMethod]
        public async Task PostCreate()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "5", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "6", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "7", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "8", IsActive = true });

            var l = context.Oppdragsgiver.ToList();
            context.SaveChanges();
            var controller = new OppdragsgiverController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            Oppdragsgiver o = new Oppdragsgiver { Id="9",IsActive=true, Email="e", Name="n",Description="d"};

            var result = controller.Create(o);
            var x = await result as ViewResult;

            //List<Oppdragsgiver> result2 = x.Model as List<Oppdragsgiver>;

            List<Oppdragsgiver> list = context.Oppdragsgiver.ToList();

            Assert.AreEqual(5, list.Count);
            

        }
        [TestMethod]
        public async Task GetEdit()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "5", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "6", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "7", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "8", IsActive = true });

            var l = context.Oppdragsgiver.ToList();
            context.SaveChanges();
            var controller = new OppdragsgiverController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Edit("8");
            var x = result as ViewResult;

            Assert.IsNotNull(x);


            Assert.IsNotNull(x.Model as Oppdragsgiver);


            Assert.AreEqual("8",(x.Model as Oppdragsgiver).Id);
        }

        [TestMethod]
        public async Task PostEdit()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "5", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "6", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "7", IsActive = true });
            context.Oppdragsgiver.Add(new Oppdragsgiver { Id = "8", IsActive = true });

            var l = context.Oppdragsgiver.ToList();
            context.SaveChanges();
            var controller = new OppdragsgiverController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            Oppdragsgiver o = context.Oppdragsgiver.Find("8");
            o.Email = "ny";

            Assert.AreNotEqual("ny", context.Oppdragsgiver.Find("8"));

            var result = await controller.Edit("8",o);

            var x = result as ViewResult;

            Oppdragsgiver oFromContext = context.Oppdragsgiver.Find("8");
            
            Assert.AreEqual("ny", o.Email);


        }
    }
}