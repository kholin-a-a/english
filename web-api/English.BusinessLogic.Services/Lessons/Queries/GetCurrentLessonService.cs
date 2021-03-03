using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetCurrentLessonService : IQueryService<GetCurrentLessonQuery, Lesson>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserContext _userContext;

        public GetCurrentLessonService(
            IUserContext userContext,
            IUserRepository userRepo
        )
        {
            this._userRepo = userRepo;
            this._userContext = userContext;
        }

        public async Task<Lesson> ExecuteAsync(GetCurrentLessonQuery query)
        {
            var user = await this._userRepo.Find(
                    this._userContext.UserId
                );

            return user.Lessons
                .OrderBy(l => l.Id)
                .LastOrDefault()
                ;
        }
    }
}
