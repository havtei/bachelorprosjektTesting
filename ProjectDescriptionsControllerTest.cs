using Bachelorprosjekt.Controllers;
using Bachelorprosjekt.Data;
using Bachelorprosjekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;
using System.Linq;

namespace TestProject4
{
    [TestClass]
    public class ProjectDescriptionsControllerTest
    {
        [TestMethod]
        public async Task GetIndexAsFagansvarlig()
        {

            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Index();
            var x = result as ViewResult;

            Assert.IsNotNull(x);
            
            var p = (List<ProsjektDescription>)x.ViewData.Model;


            Assert.AreEqual(4, p.Count);

        }

        [TestMethod]
        public async Task GetIndexAsBedrift()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });


            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Index();
            var x = (ViewResult)result;
            Assert.AreEqual(0, x.ViewData.ToList().Count);
        }
        [TestMethod]
        public async Task GetProsjektKlarForGodkjenningAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.ProsjektKlarForGodkjenning();
            var x = result as ViewResult;

            Assert.IsNotNull(x);
            var p = (List<ProsjektDescription>)x.ViewData.Model;


            Assert.AreEqual(2, p.Count);
        }
        [TestMethod]
        public async Task GetProsjektVenterFiksAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.ProsjektVenterFiks();
            var x = result as ViewResult;

            Assert.IsNotNull(x);
            var p = (List<ProsjektDescription>)x.ViewData.Model;


            Assert.AreEqual(1, p.Count);
        }
        [TestMethod]
        public async Task GetEditAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.Edit(5);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (ProsjektDescription)x.ViewData.Model;


           

            Assert.AreEqual(5, p.Id);
        }
        [TestMethod]
        public async Task PostEditAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));
           

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            ProsjektDescription pro = context.ProsjektDescription.Find(8);
            pro.Annet = "oppdatert string";

            var result = await controller.Edit(pro.Id,"Lagre",pro);

            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (ProsjektDescription)x.ViewData.Model;

             
            var p1 = context.ProsjektDescription.Find(8);

            Assert.AreEqual(pro.Annet, p1.Annet);
        }
        [TestMethod]
        public async Task PostEditGodkjennAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            ProsjektDescription pro = context.ProsjektDescription.Find(8);
            pro.Annet = "oppdatert string";

            var result = await controller.EditGodkjenn(pro.Id, "Lagre", pro);

            var x = result as ViewResult;

            

            var p1 = context.ProsjektDescription.Find(8);

            Assert.AreEqual(pro.Annet, p1.Annet);
        }
        [TestMethod]
        public async Task PostEditFiksAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            ProsjektDescription pro = context.ProsjektDescription.Find(8);
            pro.Annet = "oppdatert string";

            var result = await controller.EditFiks(pro.Id, "Lagre", pro);

            var x = result as ViewResult;



            var p1 = context.ProsjektDescription.Find(8);

            Assert.AreEqual(pro.Annet, p1.Annet);
        }
        [TestMethod]
        public async Task GetEditGodkjennAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.EditGodkjenn(5);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (ProsjektDescription)x.ViewData.Model;




            Assert.AreEqual(5, p.Id);
        }
        [TestMethod]
        public async Task GetEditFiksAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test" });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test" });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test" });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, status = 4, Annet = "test8", Arbeidsoppgaver = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test" });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            //controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result = await controller.EditFiks(5);
            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (ProsjektDescription)x.ViewData.Model;




            Assert.AreEqual(5, p.Id);
        }


        [TestMethod]
        public async Task PostGodkjennAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            

            var result = await controller.Godkjenn(8, "ProsjektKlarForGodkjenning");
            
            var p1 = context.ProsjektDescription.Find(8);

            Assert.AreEqual(4, p1.status);
        }

        [TestMethod]
        public async Task GetDeleteAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };


            var result = await controller.Delete(8);


            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var p = (ProsjektDescription)x.ViewData.Model;

            Assert.IsNotNull(p);
            Assert.AreEqual(8, p.Id);


            var result2 = await controller.Delete(99);

            var y = result2 as ViewResult;

            Assert.IsNull(y);
            


        }
        [TestMethod]
        public void GetProsjektkatalogAlleGodkjente()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };


            var result =  controller.ProsjektkatalogAlleGodkjente();

            var f = result as FileResult;

            Assert.IsNotNull(f);
            



        }

        [TestMethod]
        public void GetProsjektkatalogAlleValgte()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };


            var result = controller.ProsjektkatalogAlleValgte();

            var f = result as FileResult;

            Assert.IsNotNull(f);


        }

        [TestMethod]
        public void GetReport()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "8"));


            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };


            var result = controller.GetReport(8);

            var f = result as FileResult;

            Assert.IsNotNull(f);

            var result2 = controller.GetReport(1111);

            var f2 = result2 as FileResult;

            Assert.IsNull(f2);

        }

        [TestMethod]
        public void GetCreate()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            var result =  controller.Create();
            var x = result as ViewResult;
            
            Assert.IsNotNull(x);
            Assert.AreEqual("Create", x.ViewName);


            User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };


            var result2 = controller.Create();
            var x2 = result2 as ViewResult;

            Assert.IsNull(x2);

        }
        [TestMethod]
        public async Task PostCreateAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0 ,Name="Internt Bergen",NormalizedName="IB"});
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status="Ny" });


            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };
            controller.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string,
Microsoft.Extensions.Primitives.StringValues>
{
            { "a", "v1" },
            { "b", "v2" }
});

            ProsjektDescription p3 = new ProsjektDescription { Id = 9, Navn="test", Prosjektgiver = "test", Webadresse = "test", IntroOppdragsgiver = "test", BagrunnProsjekt = "test" , TeknologiMetoder = "test", Arbeidsoppgaver = "test", Annet = "test8",status=1 };

           
            var result = await controller.Create("Lagre", "Internt Bergen", p3);

            var x = result as ViewResult;


            ProsjektDescription p4 = context.ProsjektDescription.Find(9);

            Assert.AreEqual(9, p4.Id);
        }

        [TestMethod]
        public async Task PostDeleteConfinrmedAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });


            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);

            var result = await controller.DeleteConfirmed(8);
            var x = result as RedirectToActionResult;

            Assert.IsNotNull(x);



            p = context.ProsjektDescription.Find(8);



            Assert.IsNull(p);
        }
        [TestMethod]
        public async Task GetShowAsPdfGodkjennFiksAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });
            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();

             
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);

            var result = await controller.ShowAsPDFGodkjennFiks(8,"");

            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var result2 = await controller.ShowAsPDFGodkjennFiks(1, "");

            var x2 = result2 as ViewResult;

            Assert.IsNull(x2);



        }
        [TestMethod]
        public async Task GetShowAsPdfAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });
            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();


            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);

            var result = await controller.ShowAsPDF(8);

            var x = result as ViewResult;

            Assert.IsNotNull(x);

            var result2 = await controller.ShowAsPDF(1);

            var x2 = result2 as ViewResult;

            Assert.IsNull(x2);



        }
        [TestMethod]
        public async Task GetGetMyProjectsAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "8"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });
            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();


            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);

            var result = await controller.GetMyProjects();

            var x = result as ViewResult;

            Assert.IsNotNull(x);

            List<ProsjektDescription> ProsjektDescriptions = x.Model as List<ProsjektDescription>;

            Assert.IsNotNull(ProsjektDescriptions);

            foreach(var prosjektDescription in ProsjektDescriptions)
            {
                Assert.AreEqual(prosjektDescription.IdentityUserID,"8");
            }

        }
        [TestMethod]
        public async Task GetOppgiValgteProsjektAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Bedrift"),
            }, "8"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4 });

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });
            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();


            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);

            var result = await controller.OppgiValgteProsjekt();

            var x = result as ViewResult;

            Assert.IsNotNull(x);

            List<ProsjektDescription> ProsjektDescriptions = x.Model as List<ProsjektDescription>;

            Assert.IsNotNull(ProsjektDescriptions);

            foreach (var prosjektDescription in ProsjektDescriptions)
            {
                Assert.AreNotEqual(prosjektDescription.status, 2);
            }

        }
        [TestMethod]
        public async Task PostOppgiValgteProsjektAsync()
        {
            var User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, "Fagansvarlig"),
            }, "mock"));

            var options = new DbContextOptionsBuilder<BachelorprosjektContext>().UseInMemoryDatabase(databaseName: "bachelorprosjekt").Options;

            var context = new BachelorprosjektContext(options);
            context.Database.EnsureDeleted();

            context.ProsjektDescription.Add(new ProsjektDescription { Id = 5, status = 1, Annet = "test5", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 1 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 6, status = 3, Annet = "test6", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 2 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 7, status = 2, Annet = "test7", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Indeks = 3 });
            context.ProsjektDescription.Add(new ProsjektDescription { Id = 8, IdentityUserID = "8", status = 4, Annet = "test8", Arbeidsoppgaver = "test", TeknologiMetoder = "test", BagrunnProsjekt = "test", IntroOppdragsgiver = "test", Navn = "test", Prosjektgiver = "test", Webadresse = "test", Lokasjon = 1, Indeks = 4, ErValgt = false }) ;

            context.Lokasjon.Add(new Lokasjon { Id = 1, Antall = 0, Name = "Internt Bergen", NormalizedName = "IB" });
            context.ProjectStatus.Add(new ProjectStatus { Id = 1, Status = "Ny" });


            var l = context.ProsjektDescription.ToList();
            context.SaveChanges();
            var controller = new ProsjektDescriptionsController(context);

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = User };

            ProsjektDescription p = context.ProsjektDescription.Find(8);
            Assert.IsNotNull(p);
            Assert.AreNotEqual(p.ErValgt, true);

            var result = await controller.OppgiValgteProsjekt(8);
            var x = result as RedirectToActionResult;

            Assert.IsNotNull(x);



            Assert.AreEqual(p.ErValgt,true);
        }

    }
}