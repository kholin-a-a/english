using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StartLessonService : ICommandService<StartLessonCommand>
    {
        private readonly ILessonRepository _repo;
        private readonly INextLessonNumberProvider _nextNumber;
        private readonly IUserContext _userContext;

        public StartLessonService(
            ILessonRepository repo,
            INextLessonNumberProvider nextNumber,
            IUserContext userContext
        )
        {
            this._repo = repo;
            this._nextNumber = nextNumber;
            this._userContext = userContext;
        }

        public async Task ExecuteAsync(StartLessonCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var lesson = new Lesson()
            {
                Number = await this._nextNumber.Get(),
                UserId = this._userContext.UserId
            };

            await this._repo.Add(lesson);
        }
    }
}
