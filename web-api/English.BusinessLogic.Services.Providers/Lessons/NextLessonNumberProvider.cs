using System.Threading.Tasks;

namespace English.BusinessLogic.Providers
{
    public class NextLessonNumberProvider : INextLessonNumberProvider
    {
        private readonly ILessonRepository _repo;
        private readonly IUserContext _userContext;

        public NextLessonNumberProvider(
            ILessonRepository repo,
            IUserContext userContext
            )
        {
            this._repo = repo;
            this._userContext = userContext;
        }

        public async Task<int> Get()
        {
            var count = await this._repo.GetLessonCount(
                this._userContext.UserId
                );

            return count + 1;
        }
    }
}
