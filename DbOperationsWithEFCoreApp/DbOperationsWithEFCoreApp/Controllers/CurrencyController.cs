using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet("")]
        public IActionResult GetAllCurrencies()
        {
            //var result = appDbContext.Currencies.ToList();
            var result = (from Currencies in appDbContext.Currencies
                          select Currencies).ToList();

            return Ok(result);
        }
    }
}
