using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    [Route("")]
    public class WordExplanationsController : ApiControllerBase
    {
        [HttpGet("words/{id:int}/explanation")]
        public async Task<ActionResult<List<WordExplanationOutputModel>>> GetExplanation(int id)
        {
            await Task.Yield();

            var explanation = new WordExplanationOutputModel[]
            {
                new WordExplanationOutputModel
                {
                    Part = "Noun",
                    Meanings = new WordMeaningOutputModel[]
                    {
                        new WordMeaningOutputModel
                        {
                             Meaning = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                              Example = "exercise improves your heart and lung power",
                               Synonyms = new string[]
                               {
                                    "activity",
                                    "movement",
                                    "exercition",
                                    "effort",
                                    "work"
                               }
                        }
                    }
                }
            };

            return Ok(explanation);
        }
    }
}
