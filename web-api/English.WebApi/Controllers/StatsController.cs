using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class StatsController : ApiControllerBase
    {
        public async Task<ActionResult> GetStats()
        {
            return Ok(
                new { TotalLessons = 34 }
                );
        }
    }
}
