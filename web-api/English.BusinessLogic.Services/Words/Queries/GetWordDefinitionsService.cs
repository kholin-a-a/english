using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetWordDefinitionsService : IQueryService<GetWordDefinitionsQuery, IEnumerable<Definition>>
    {
        private readonly IWordRepository _wordRepo;

        public GetWordDefinitionsService(IWordRepository repo)
        {
            this._wordRepo = repo;
        }

        public async Task<IEnumerable<Definition>> ExecuteAsync(GetWordDefinitionsQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var word = await this._wordRepo.Find(query.WordId);

            return word.Definitions;
        }
    }
}
