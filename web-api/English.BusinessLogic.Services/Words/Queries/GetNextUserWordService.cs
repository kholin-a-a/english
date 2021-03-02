using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetNextUserWordService : IQueryService<GetNextUserWord, Word>
    {
        private readonly IWordRepository _repo;

        public GetNextUserWordService(IWordRepository repo)
        {
            this._repo = repo;
        }

        public Task<Word> ExecuteAsync(GetNextUserWord query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetNexWord();
        }
    }
}
