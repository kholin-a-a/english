using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsUknownService : ICommandService<MarkWordAsUknownCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepo;
        private readonly IWordRepository _wordRepo;

        public MarkWordAsUknownService(
            IUserContext userContext,
            IUserRepository userRepo,
            IWordRepository wordRepo
        )
        {
            this._userContext = userContext;
            this._userRepo = userRepo;
            this._wordRepo = wordRepo; 
        }

        public async Task ExecuteAsync(MarkWordAsUknownCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var user = await this._userRepo.Find(
                    this._userContext.UserId
                );

            var word = await this._wordRepo.Find(
                    command.WordId
                );

            user.UnknownWords.Add(word);

            await this._userRepo.Update(user);
        }
    }
}
