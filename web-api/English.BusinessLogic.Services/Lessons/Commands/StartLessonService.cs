using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StartLessonService : ICommandService<StartLesson>
    {
        public Task ExecuteAsync(StartLesson command)
        {
            return Task.CompletedTask;
        }
    }
}
