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
        private readonly IQueryService<GetWordDefinitionsQuery, IEnumerable<WordDefinition>> _definitionsQuery;

        public WordDefinitionsController(
            IQueryService<GetWordDefinitionsQuery, IEnumerable<WordDefinition>> definitionsQuery
        )
        {
            this._definitionsQuery = definitionsQuery;
        }

        [HttpGet("words/{wordId:int}/definitions")]
        public async Task<ActionResult<List<WordDefinitionOutputModel>>> GetDefinitions(int wordId)
        {
            var definitions = await this._definitionsQuery.ExecuteAsync(
                new GetWordDefinitionsQuery()
                {
                    WordId = wordId
                });

            var result = definitions.Select(d =>
                new WordDefinitionOutputModel
                {
                    SpeechPart = d.SpeechPart.Name,
                    Definition = d.Definition,
                    Example = d.Example,
                    Synonyms = d.Synonyms.Select(s => s.Text)
                }
            )
            .ToList();

            return Ok(result);
        }
    }
}
