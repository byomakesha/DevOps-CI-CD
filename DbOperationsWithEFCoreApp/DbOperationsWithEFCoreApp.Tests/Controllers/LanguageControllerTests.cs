using DbOperationsWithEFCoreApp.Controllers;
using DbOperationsWithEFCoreApp.Data;
using DbOperationsWithEFCoreApp.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOperationsWithEFCoreApp.Tests.Controllers
{
    public class LanguageControllerTests
    {
        [Fact]
        public async Task GetAllLanguages_ReturnsData()
        {
            var context = InMemoryDbHelper.GetDbContext();
            var controller = new LanguageController(context);

            var result = await controller.GetAllLanguage();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<Language>>(okResult.Value);

            Assert.Equal(4, data.Count());
        }

        [Fact]
        public void GetLanguageById_ReturnsSingleLanguage()
        {
            var context = InMemoryDbHelper.GetDbContext();
            var controller = new LanguageController(context);

            var result = controller.GetLanguageById(2);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var language = Assert.IsType<Language>(okResult.Value);

            Assert.Equal("Tamil", language.Title);
        }
    }
}
