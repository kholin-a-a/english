using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class WordsController : ApiControllerBase
    {
        private readonly IQueryService<GetNextUserWord, Word> _nextUserWordQuery;
        private readonly ICommandService<MarkWordAsUknown> _markWordAsUknownCommand;
        private readonly ICommandService<MarkWordAsCompleted> _markWordAsCompletedCommand;

        public WordsController(
            IQueryService<GetNextUserWord, Word> nextUserWordQuery,
            ICommandService<MarkWordAsUknown> markWordAsUknownCommand,
            ICommandService<MarkWordAsCompleted> markWordAsCompletedCommand
        )
        {
            this._nextUserWordQuery = nextUserWordQuery;
            this._markWordAsUknownCommand = markWordAsUknownCommand;
            this._markWordAsCompletedCommand = markWordAsCompletedCommand;
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
            var command = new MarkWordAsUknown
            {
                WordId = id
            };

            await this._markWordAsUknownCommand.ExecuteAsync(command);

            return Ok();
        }

        [HttpPost("completed")]
        public async Task<ActionResult> MarkAsCompleted([FromBody]WordCompletedInputModel model)
        {
            var command = new MarkWordAsCompleted()
            {
                WordId = model.Id,
                LessonId = model.LessonId,
                Text = model.Text
            };

            await this._markWordAsCompletedCommand.ExecuteAsync(command);

            return Ok();
        }
    }
}
