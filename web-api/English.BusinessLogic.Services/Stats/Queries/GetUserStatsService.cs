using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetUserStatsService : IQueryService<GetUserStatsQuery, UserStats>
    {
        private readonly ILessonRepository _lessonRepo;
        private readonly IUserContext _userContext;

        public GetUserStatsService(
            ILessonRepository lessonRepo,
            IUserContext userContext
        )
        {
            this._lessonRepo = lessonRepo;
            this._userContext = userContext;
        }

        public async Task<UserStats> ExecuteAsync(GetUserStatsQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var count = await this._lessonRepo.GetLessonCount(
                this._userContext.UserId
                );

            return new UserStats
            {
                TotalLessons = count
            };
        }
    }
}
