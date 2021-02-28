using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class StatsController : ApiControllerBase
    {
        private readonly IQueryService<GetUserStats, UserStats> _statsQuery;

        public StatsController(
            IQueryService<GetUserStats, UserStats> statsQuery
        )
        {
            this._statsQuery = statsQuery;
        }

        [HttpGet]
        public async Task<ActionResult<StatsOuputModel>> GetStats()
        {
            var stats = await this._statsQuery.ExecuteAsync(
                new GetUserStats()
                );

            var result = new StatsOuputModel()
            {
                TotalLessons = stats.TotalLessons
            };

            return Ok(result);
        }
    }
}
