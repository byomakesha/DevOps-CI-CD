using DbOperationsWithEFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOperationsWithEFCoreApp.Tests.Helpers
{
    //Purpose : DB setup, mocks
    public static class InMemoryDbHelper
    {
        public static AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            context.Currencies.AddRange(
                new Currency { Id = 1, Title = "USD", Description = "US Dollar" },
                new Currency { Id = 2, Title = "INR", Description = "Indian Rupee" }
            );

            context.SaveChanges();

            return context;
        }
    }
}
