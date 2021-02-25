using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    [Route("")]
    public class WordDefinitionsController : ApiControllerBase
    {
        [HttpGet("words/{id:int}/definitions")]
        public async Task<ActionResult<List<WordDefinitionOutputModel>>> GetExplanation(int id)
        {
            await Task.Yield();

            var definitions = new WordDefinitionOutputModel[]
            {
                new WordDefinitionOutputModel
                {
                    SpeechPart = "Noun",
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                    Synonyms = new string[] { "activity", "movement", "exercition", "effort", "work" }
                },
                new WordDefinitionOutputModel
                {
                    SpeechPart = "Noun",
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                },
                new WordDefinitionOutputModel
                {
                    SpeechPart = "Verb",
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                    Synonyms = new string[] { "activity", "movement", "exercition", "effort", "work" }
                }
            };

            return Ok(definitions);
        }
    }
}
