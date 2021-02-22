using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class LessonsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LessonOutputModel>> StartLesson()
        {
            var model = new LessonOutputModel
            {
                Id = 20,
                Number = 12
            };

            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> StopLesson(int id)
        {
            return Ok();
        }
    }
}
