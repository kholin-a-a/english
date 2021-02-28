using English.BusinessLogic;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace English.WebApi.Controllers
{
    public class LessonsController : ApiControllerBase
    {
        private readonly ICommandService<StartLesson> _startService;
        private readonly ICommandService<StopLesson> _stopService;

        public LessonsController(
            ICommandService<StartLesson> startService,
            ICommandService<StopLesson> stopService
        )
        {
            this._startService = startService;
            this._stopService = stopService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonOutputModel>> StartLesson()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> StopLesson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
