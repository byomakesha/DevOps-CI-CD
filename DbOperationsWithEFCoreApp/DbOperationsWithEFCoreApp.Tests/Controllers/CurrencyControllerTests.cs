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
    public class CurrencyControllerTests
    {
        [Fact]
        public void GetAllCurrencies_ReturnsData()
        {
            var context = InMemoryDbHelper.GetDbContext();
            var controller = new CurrencyController(context);

            var result = controller.GetAllCurrencies();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<Currency>>(okResult.Value);

            Assert.Equal(2, data.Count());
        }

        [Fact]
        public void GetCurrenciesById_ReturnsSingleCurrency()
        {
            var context = InMemoryDbHelper.GetDbContext();
            var controller = new CurrencyController(context);

            var result = controller.GetCurrenciesById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var currency = Assert.IsType<Currency>(okResult.Value);

            Assert.Equal("USD", currency.Title);
        }
    }
}
