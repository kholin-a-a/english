using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsUknownService : ICommandService<MarkWordAsUknownCommand>
    {
        private readonly IUnknownWordRepository _repo;
        private readonly IUserContext _userContext;

        public MarkWordAsUknownService(
            IUnknownWordRepository repo,
            IUserContext userContext
        )
        {
            this._repo = repo;
            this._userContext = userContext;
        }

        public async Task ExecuteAsync(MarkWordAsUknownCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var word = new UnknownWord
            {
                WordId = command.WordId,
                UserId = this._userContext.UserId
            };

            await this._repo.Save(word);
        }
    }
}
