using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class MarkWordAsCompletedValidator : ICommandValidator<MarkWordAsCompletedCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRules _userRules;
        private readonly IWordRules _wordRules;

        public MarkWordAsCompletedValidator(
            IUserContext userContext,
            IUserRules userRules,
            IWordRules wordRules
        )
        {
            this._userContext = userContext;
            this._userRules = userRules;
            this._wordRules = wordRules;
        }

        public async Task Validate(MarkWordAsCompletedCommand command)
        {
            await this._wordRules.WordExists(command.WordId);
            await this._userRules.HasLesson(this._userContext.UserId, command.LessonId);
        }
    }
}
