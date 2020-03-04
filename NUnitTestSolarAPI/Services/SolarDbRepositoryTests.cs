using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SolarApp.DbContexts;
using SolarApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestSolarAPI.Services
{
    class SolarDbRepositoryTests
    {
        [Test]
        public void AddCompetition_Writes_to_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db1")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddCompetition(new SolarApp.Entities.Competition { CompetitionTitle = "test", CompetitionDescription = "test"});
                context.SaveChanges();
            }

            using (var context = new SolarDbContext(options))
            {
                Assert.AreEqual(1, context.Competitions.Count());
                Assert.AreEqual("test", context.Competitions.Single().CompetitionTitle);
            }
        }

        [Test]
        public void AddResult_Writest_to_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db2")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddResult(99, new SolarApp.Entities.Result { ResultPosition = 1 });
                context.SaveChanges();
            }

            using (var context = new SolarDbContext(options))
            {
                Assert.AreEqual(1, context.Results.Count());
                Assert.AreEqual(1, context.Results.Single().ResultPosition);
            }
        }

        [Test]
        public void AddUser_Writes_to_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db3")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddUser(new SolarApp.Entities.User { UserEmail = "test@mail", UserFullName = "test", UserPassword = "password" });
                context.SaveChanges();
            }

            using (var context = new SolarDbContext(options))
            {
                Assert.AreEqual(1, context.Users.Count());
                Assert.AreEqual("test@mail", context.Users.Single().UserEmail);
            }
        }

        [Test]
        public void DeleteCompetition_Deletes_From_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db4")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddCompetition(new SolarApp.Entities.Competition { CompetitionId = 1, CompetitionTitle = "test", CompetitionDescription = "test" });
                context.SaveChanges();
            }
            

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.DeleteCompetition(1);
                context.SaveChanges();
            }

            using (var context = new SolarDbContext(options))
            {
                Assert.AreEqual(0, context.Competitions.Count());
            }
        }

        [Test]
        public void GetCompetition_Returns_Competition_From_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db5")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddCompetition(new SolarApp.Entities.Competition { CompetitionId = 1, CompetitionTitle = "testGet", CompetitionDescription = "test" });
                context.SaveChanges();
            }


            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                var competition = service.GetCompetition(1);
                Assert.AreEqual("testGet", competition.CompetitionTitle);
            }            
        }

        [Test]
        public void GetCompetitions_ReturnsCollection_From_Database()
        {
            var options = new DbContextOptionsBuilder<SolarDbContext>()
                .UseInMemoryDatabase("Test db6")
                .Options;

            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                service.AddCompetition(new SolarApp.Entities.Competition { CompetitionId = 1, CompetitionTitle = "testGet", CompetitionDescription = "test" });
                service.AddCompetition(new SolarApp.Entities.Competition { CompetitionId = 2, CompetitionTitle = "testGet2", CompetitionDescription = "test2" });
                context.SaveChanges();
            }


            using (var context = new SolarDbContext(options))
            {
                var service = new SolarDbRepository(context);
                var competition = service.GetCompetitions();
                Assert.AreEqual("testGet2", competition.ElementAt(1).CompetitionTitle);
                Assert.AreEqual(2, competition.Count());
            }
        }
    }
}
