using LinqToDB;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SolarApp;


namespace NUnitTestSolarAPI
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

//        public IntegrationTest()
//        {
//\            var appFactory = new WebApplicationFactory<Startup>()
//                .WithWebHostBuilder(builder =>
//                {
//                    builder.ConfigureServices(services =>
//                    {
//                        services.RemoveAll(typeof(DataContext));
//                        services.AddDbContext<DataContext>(options => { options.UseInMemoryDatabase("Test db"); });
//                    });
//                });
//            TestClient = appFactory.CreateClient();
//        }
        
    }
}