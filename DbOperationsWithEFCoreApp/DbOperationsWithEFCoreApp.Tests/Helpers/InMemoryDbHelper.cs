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
                new Currency { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency { Id = 2, Title = "Dollar", Description = "Dollar" },
                new Currency { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency { Id = 4, Title = "Dinar", Description = "Dinar" }
            );

            context.Languages.AddRange(
                new Language { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language { Id = 2, Title = "Tamil", Description = "Tamil" },
                new Language { Id = 3, Title = "Punjabi", Description = "Punjabi" },
                new Language { Id = 4, Title = "Urdu", Description = "Urdu" }
            );

            context.SaveChanges();

            return context;
        }
    }
}
