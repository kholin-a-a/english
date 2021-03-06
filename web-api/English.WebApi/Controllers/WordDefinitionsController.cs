using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    [Route("")]
    public class WordDefinitionsController : ApiControllerBase
    {
        private readonly IQueryService<GetWordDefinitionsQuery, IEnumerable<Definition>> _definitionsQuery;

        public WordDefinitionsController(
            IQueryService<GetWordDefinitionsQuery, IEnumerable<Definition>> definitionsQuery
        )
        {
            this._definitionsQuery = definitionsQuery;
        }

        [HttpGet("words/{wordId:int}/definitions")]
        public async Task<ActionResult<List<WordDefinitionOutputModel>>> GetDefinitions(int wordId)
        {
            var definitions = await this._definitionsQuery.ExecuteAsync(
                    new GetWordDefinitionsQuery(wordId)
                );

            var result = definitions.Select(d =>
                new WordDefinitionOutputModel
                {
                    SpeechPart = d.SpeechPart,
                    Definition = d.Value,
                    Example = d.Example,
                    Synonyms = d.Synonyms
                }
            )
            .ToList();

            return Ok(result);
        }
    }
}
