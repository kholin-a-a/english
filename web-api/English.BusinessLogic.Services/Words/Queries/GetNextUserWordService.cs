using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetNextUserWordService : IQueryService<GetNextUserWordQuery, Word>
    {
        private readonly IWordRepository _repo;

        public GetNextUserWordService(IWordRepository repo)
        {
            this._repo = repo;
        }

        public Task<Word> ExecuteAsync(GetNextUserWordQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetNextUserWord();
        }
    }
}
