using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class MarkWordAsCompletedValidator : ICommandValidator<MarkWordAsCompletedCommand>
    {
        private readonly ICommandService<MarkWordAsCompletedCommand> _decoratee;
        private readonly IUserRepository _userRepo;
        private readonly IWordRepository _wordRepo;
        private readonly IUserContext _userContext;

        public MarkWordAsCompletedValidator(
            ICommandService<MarkWordAsCompletedCommand> decoratee,
            IUserRepository userRepo,
            IWordRepository wordRepo,
            IUserContext userContext
        )
        {
            this._decoratee = decoratee;
            this._userRepo = userRepo;
            this._wordRepo = wordRepo;
            this._userContext = userContext;
        }

        public async Task Validate(MarkWordAsCompletedCommand command)
        {
            var word = await this._wordRepo.Find(command.WordId);
            if (word == null)
                throw new EntityNotFoundException($"Word with id {command.WordId} is not found");

            var user = await this._userRepo.Find(this._userContext.UserId);

            var lessonExists = user.Lessons.Any(l => l.Id == command.LessonId);
            if (!lessonExists)
                throw new EntityNotFoundException($"Lesson with id {command.LessonId} is not found");

            await this._decoratee.ExecuteAsync(command);
        }
    }
}
