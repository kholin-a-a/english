using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StartLessonService : ICommandService<StartLesson>
    {
        private readonly ILessonRepository _repo;
        private readonly INextLessonNumberProvider _nextNumber;

        public StartLessonService(
            ILessonRepository repo,
            INextLessonNumberProvider nextNumber
        )
        {
            this._repo = repo;
            this._nextNumber = nextNumber;
        }

        public async Task ExecuteAsync(StartLesson command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var lesson = new Lesson()
            {
                Number = await this._nextNumber.Get()
            };

            await this._repo.Save(lesson);
        }
    }
}
