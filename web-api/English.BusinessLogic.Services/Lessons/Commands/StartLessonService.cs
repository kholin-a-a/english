using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StartLessonService : ICommandService<StartLesson>
    {
        private readonly ILessonRepository _repo;

        public StartLessonService(
            ILessonRepository repo
        )
        {
            this._repo = repo;
        }

        public async Task ExecuteAsync(StartLesson command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await this._repo.Create();
        }
    }
}
