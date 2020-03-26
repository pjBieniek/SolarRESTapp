using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SolarApp.DatabaseCreation.DbContexts;
using SolarApp.Data.Services;
using System.Linq;
using System.Collections;

namespace SolarApp.Tests.Services
{
    class SolarDbRepositoryTests : RepositoryTests
    {
        [Test]
        public void AddCompetition_Writes_to_Database()
        {
            //arrange
            int competitionsBeforeTestCount = context.Competitions.Count();
            
            //act
            repo.AddCompetition(new DatabaseCreation.Entities.Competition { CompetitionId=99, CompetitionTitle = "test", CompetitionDescription = "test" });
            context.SaveChanges();
            string title = repo.GetCompetition(99).CompetitionTitle;

            //assert
            Assert.AreEqual(competitionsBeforeTestCount + 1, context.Competitions.Count());
            Assert.AreEqual("test", title);
        }

        [Test]
        public void AddResult_Writest_to_Database()
        {
            //arrange
            int resultsBeforeTestCount = context.Results.Count();

            //act
            repo.AddResult(99, new DatabaseCreation.Entities.Result {ResultId=99, ResultPosition = 1 });
            context.SaveChanges();
            int position = repo.GetResult(99, 99).ResultPosition;

            //assert
            Assert.AreEqual(resultsBeforeTestCount + 1, context.Results.Count());
            Assert.AreEqual(1, position);
        }

        [Test]
        public void AddUser_Writes_to_Database()
        { 
            //arrange
            int usersBeforeTestCount = context.Users.Count();

            //act
            repo.AddUser(new SolarApp.DatabaseCreation.Entities.User { UserId=99, UserEmail = "test@mail", UserFullName = "test", UserPassword = "password" });
            context.SaveChanges();
            string email = repo.GetUser(99).UserEmail;

            //assert
            Assert.AreEqual(usersBeforeTestCount + 1, context.Users.Count());
            Assert.AreEqual("test@mail", email);
        }

        [Test]
        public void DeleteCompetition_Deletes_From_Database()
        {
            //arrange
            int competitionsBeforeTestCount = context.Competitions.Count();

            //act
            repo.AddCompetition(new DatabaseCreation.Entities.Competition { CompetitionId = 2, CompetitionTitle = "test2", CompetitionDescription = "test2" });
            context.SaveChanges();
            repo.DeleteCompetition(2);
            context.SaveChanges();

            //assert
            Assert.AreEqual(competitionsBeforeTestCount, context.Competitions.Count());
        }

        [Test]
        public void GetCompetition_Returns_Competition_From_Database()
        {
            //arrange
            string title = "testGet";
            repo.AddCompetition(new SolarApp.DatabaseCreation.Entities.Competition { CompetitionId = 1, CompetitionTitle = title, CompetitionDescription = "test" });
            context.SaveChanges();

            //act
            string titleFromGet = repo.GetCompetition(1).CompetitionTitle;

            //assert
            Assert.AreEqual(title, titleFromGet);
        }

        [Test]
        public void GetCompetitions_ReturnsCollection_From_Database()
        {
            //arrange
            var competitions = repo.GetCompetitions();

            //act
            var type = competitions.GetType();

            //assert
            Assert.IsTrue(type.GetInterface(nameof(ICollection)) != null);

        }
    }
}
