using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("GetAllCurrencies")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = appDbContext.Currencies.ToList();
            var result = await (from Currencies in appDbContext.Currencies
                          where Currencies != null
                          select Currencies).ToListAsync();

            return Ok(result);
        }
        [HttpGet("GetCurrenciesById")]
        public IActionResult GetCurrenciesById(int Id)
        {
            var result = appDbContext.Currencies.FirstOrDefault(x => x.Id == Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
