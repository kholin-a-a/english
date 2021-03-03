using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetNextUserWordService : IQueryService<GetNextUserWordQuery, Word>
    {
        private readonly IUnlearnedWordRepository _repo;
        private readonly IUserContext _userContext;

        public GetNextUserWordService(
            IUnlearnedWordRepository repo,
            IUserContext userContext
        )
        {
            this._repo = repo;
            this._userContext = userContext;
        }

        public Task<Word> ExecuteAsync(GetNextUserWordQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetNextUserWord(
                    this._userContext.UserId
                );
        }
    }
}
