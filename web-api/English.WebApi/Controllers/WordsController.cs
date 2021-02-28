using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class WordsController : ApiControllerBase
    {
        private readonly IQueryService<GetNextUserWord, Word> _nextUserWordQuery;

        public WordsController(
            IQueryService<GetNextUserWord, Word> nextUserWordQuery
        )
        {
            this._nextUserWordQuery = nextUserWordQuery;
        }

        [HttpGet]
        public async Task<ActionResult<WordOutputModel>> GetNextWord()
        {
            var word = await this._nextUserWordQuery.ExecuteAsync(
                new GetNextUserWord()
                );

            var result = new WordOutputModel
            {
                Id = word.Id,
                Text = word.Text
            };

            return Ok(result);
        }

        [HttpPost("unknown")]
        public async Task<ActionResult> MarkAsUnknown([FromBody]int id)
        {
            await Task.Yield();

            return Ok();
        }

        [HttpPost("completed")]
        public async Task<ActionResult> MarkAsCompleted([FromBody]WordCompletedInputModel model)
        {
            await Task.Yield();

            return Ok();
        }
    }
}
