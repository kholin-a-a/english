using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetNextUserWordService : IQueryService<GetNextUserWordQuery, Word>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepo;
        private readonly IWordRepository _wordRepo;

        public GetNextUserWordService(
            IUserContext userContext,
            IUserRepository userRepo,
            IWordRepository wordRepo
        )
        {
            this._userContext = userContext;
            this._userRepo = userRepo;
            this._wordRepo = wordRepo;
        }

        public async Task<Word> ExecuteAsync(GetNextUserWordQuery query)
        {
            var user = await this._userRepo.Find(
                    this._userContext.UserId
                );

            var filterWordIds = user.Lessons
                .SelectMany(w => w.Answers)
                .Select(a => a.Word.Id)
                .ToArray()
                ;

            var words = await this._wordRepo.Query(filterWordIds, take: 1);

            return words.SingleOrDefault();
        }
    }
}
