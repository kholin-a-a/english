using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class LessonsController : ApiControllerBase
    {
        private readonly ICommandService<StartLesson> _startService;
        private readonly ICommandService<StopLesson> _stopService;
        private readonly IQueryService<GetCurrentLesson, Lesson> _getService;

        public LessonsController(
            ICommandService<StartLesson> startService,
            ICommandService<StopLesson> stopService,
            IQueryService<GetCurrentLesson, Lesson> getService
        )
        {
            this._startService = startService;
            this._stopService = stopService;
            this._getService = getService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonOutputModel>> StartLesson()
        {
            await this._startService.ExecuteAsync(
                new StartLesson()
                );

            var lesson = await this._getService.ExecuteAsync(
                new GetCurrentLesson()
                );

            var result = new LessonOutputModel
            {
                Id = lesson.Id,
                Number = lesson.Number
            };

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> StopLesson(int id)
        {
            var command = new StopLesson
            {
                LessonId = id
            };

            await this._stopService.ExecuteAsync(command);

            return Ok();
        }
    }
}
