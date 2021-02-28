using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StopLessonService : ICommandService<StopLesson>
    {
        public Task ExecuteAsync(StopLesson command)
        {
            return Task.CompletedTask;
        }
    }
}
