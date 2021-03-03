using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetWordDefinitionsService : IQueryService<GetWordDefinitionsQuery, IEnumerable<WordDefinition>>
    {
        private readonly IWordDefinitionRepository _repo;

        public GetWordDefinitionsService(IWordDefinitionRepository repo)
        {
            this._repo = repo;
        }

        public Task<IEnumerable<WordDefinition>> ExecuteAsync(GetWordDefinitionsQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetDefinition(query.WordId);
        }
    }
}
