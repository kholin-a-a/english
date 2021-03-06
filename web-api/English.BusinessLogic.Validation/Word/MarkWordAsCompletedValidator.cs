using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class MarkWordAsCompletedValidator : ICommandValidator<MarkWordAsCompletedCommand>
    {
        private readonly IUserRepository _userRepo;
        private readonly IWordRepository _wordRepo;
        private readonly IUserContext _userContext;

        public MarkWordAsCompletedValidator(
            IUserRepository userRepo,
            IWordRepository wordRepo,
            IUserContext userContext
        )
        {
            this._userRepo = userRepo;
            this._wordRepo = wordRepo;
            this._userContext = userContext;
        }

        public async Task Validate(MarkWordAsCompletedCommand command)
        {
            var word = await this._wordRepo.Find(command.WordId);
            if (word == null)
                throw new EntityNotFoundException($"Word is not found");

            var user = await this._userRepo.Find(this._userContext.UserId);

            var lessonExists = user.Lessons.Any(l => l.Id == command.LessonId);
            if (!lessonExists)
                throw new EntityNotFoundException($"Lesson is not found");
        }
    }
}
