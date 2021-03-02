using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetUserStatsService : IQueryService<GetUserStats, UserStats>
    {
        private readonly ILessonRepository _lessonRepo;

        public GetUserStatsService(ILessonRepository lessonRepo)
        {
            this._lessonRepo = lessonRepo;
        }

        public async Task<UserStats> ExecuteAsync(GetUserStats query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var count = await this._lessonRepo.GetLessonCount();

            return new UserStats
            {
                TotalLessons = count
            };
        }
    }
}
