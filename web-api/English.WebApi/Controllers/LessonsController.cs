using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class LessonsController : ApiControllerBase
    {
        private readonly ICommandService<StartLessonCommand> _startService;
        private readonly IQueryService<GetCurrentLesson, Lesson> _getService;

        public LessonsController(
            ICommandService<StartLessonCommand> startService,
            IQueryService<GetCurrentLesson, Lesson> getService
        )
        {
            this._startService = startService;
            this._getService = getService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonOutputModel>> StartLesson()
        {
            await this._startService.ExecuteAsync(
                new StartLessonCommand()
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
    }
}
