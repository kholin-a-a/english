using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetUserStatsService : IQueryService<GetUserStats, UserStats>
    {
        public Task<UserStats> ExecuteAsync(GetUserStats query)
        {
            return Task.FromResult(
                new UserStats
                {
                    TotalLessons = 123
                });
        }
    }
}
