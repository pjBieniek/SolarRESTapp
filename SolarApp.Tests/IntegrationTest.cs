using LinqToDB;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SolarApp;
using System.Linq;
using SolarApp.DatabaseCreation.DbContexts;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SolarApp.Tests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider serviceProvider;

        public IntegrationTest()
        {
            // THIS IS ANOTHER METHOD FOR A FAKE DB
            //var services = new ServiceCollection();
            //services.AddEntityFrameworkNpgsql()
            //    .AddEntityFrameworkInMemoryDatabase()
            //    .AddDbContext<SolarDbContext>(options =>
            //    {
            //        options.UseInMemoryDatabase("test db");
            //    });

            //serviceProvider = services.BuildServiceProvider();

            var appFactory = new WebApplicationFactory<Startup>()
                 .WithWebHostBuilder(builder =>
                 {
                     builder.ConfigureServices(services =>
                     {
                         var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<SolarDbContext>));
                         if (descriptor != null)
                             services.Remove(descriptor);
                         services.AddDbContext<SolarDbContext>(options => { options.UseInMemoryDatabase("Test db"); });
                     });
                 });

            TestClient = appFactory.CreateClient();
        }

        // Setup authorization
        //protected async Task AuthenticateAsyns()
        //{
        //    TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        //}

        //TODO
        //private async Task<string> GetJwtAsync()
        //{
        //    var response = await TestClient.PostAsync("api/users/login", 
        //        {

        //        });
        //}
    }
}