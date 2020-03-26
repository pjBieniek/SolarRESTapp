using Microsoft.EntityFrameworkCore;
using SolarApp.Data.Services;
using SolarApp.DatabaseCreation.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarApp.Tests
{
    class RepositoryTests
    {
        protected SolarDbRepository repo;
        protected SolarDbContext context;

        public RepositoryTests()
        {
            var repositoryOptions = new DbContextOptionsBuilder<SolarDbContext>()
                    .UseInMemoryDatabase("Test db1")
                    .Options;
            context = new SolarDbContext(repositoryOptions);
            repo = new SolarDbRepository(context);
        }
    }
}
