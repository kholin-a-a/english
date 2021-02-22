using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class StatsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StatsOuputModel>> GetStats()
        {
            await Task.Yield();

            var result = new StatsOuputModel
            {
                TotalLessons = 34
            };

            return Ok(result);
        }
    }
}
