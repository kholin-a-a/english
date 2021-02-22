using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class WordsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<WordOutputModel>> GetNextWord()
        {
            await Task.Yield();

            var word = new WordOutputModel
            {
                Id = 123,
                Text = "exersice"
            };

            return Ok(word);
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
