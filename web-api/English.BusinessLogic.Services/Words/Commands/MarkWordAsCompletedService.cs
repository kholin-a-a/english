using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsCompletedService : ICommandService<MarkWordAsCompletedCommand>
    {
        private readonly ICompletedWordRepository _repo;
        private readonly IUserContext _userContext;

        public MarkWordAsCompletedService(
            ICompletedWordRepository repo,
            IUserContext userContext
        )
        {
            this._repo = repo;
            this._userContext = userContext;
        }

        public async Task ExecuteAsync(MarkWordAsCompletedCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var word = new CompletedWord
            {
                LessonId = command.LessonId,
                WordId = command.WordId,
                Text = command.Text,
                UserId = this._userContext.UserId
            };

            await this._repo.Add(word);
        }
    }
}
