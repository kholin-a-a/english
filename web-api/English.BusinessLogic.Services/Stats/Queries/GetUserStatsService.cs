using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetUserStatsService : IQueryService<GetUserStatsQuery, UserStats>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepo;

        public GetUserStatsService(
            IUserContext userContext,
            IUserRepository userRepo
        )
        {
            this._userContext = userContext;
            this._userRepo = userRepo;
        }

        public async Task<UserStats> ExecuteAsync(GetUserStatsQuery query)
        {
            var user = await this._userRepo.Find(
                    this._userContext.UserId
                );

            return new UserStats
            {
                TotalLessons = user.Lessons.Count
            };
        }
    }
}
