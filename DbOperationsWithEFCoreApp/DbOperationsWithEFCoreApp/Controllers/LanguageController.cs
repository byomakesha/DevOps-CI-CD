using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("GetAllLanguage")]
        public async Task<IActionResult> GetAllLanguage()
        {
            //var languages = await appDbContext.Languages.ToListAsync();
            var languages = await (from Languages in appDbContext.Languages
                            where Languages != null
                            select Languages).ToListAsync();

            return Ok(languages);
        }
    }
}
