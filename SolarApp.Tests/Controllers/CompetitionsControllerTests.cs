using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using System.Net;

using System.Threading.Tasks;

namespace NUnitTestSolarAPI.Controllers
{
    class CompetitionsControllerTests : IntegrationTest
    {
        [Test]
        public async Task GetCompetitions_Returns_Nothing_From_Empty_Repo()
        {
            var response = await TestClient.GetAsync("api/competitions");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //response.Content.ReadAsStringAsync().Result.Should().Be("[]");
            var responseData = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("[]", responseData);
        }
    }
}
