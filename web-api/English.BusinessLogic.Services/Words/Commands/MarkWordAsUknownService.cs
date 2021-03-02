using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsUknownService : ICommandService<MarkWordAsUknown>
    {
        private readonly IUnknownWordRepository _repo;

        public MarkWordAsUknownService(IUnknownWordRepository repo)
        {
            this._repo = repo;
        }

        public async Task ExecuteAsync(MarkWordAsUknown command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var word = new UnknownWord
            {
                WordId = command.WordId
            };

            await this._repo.Save(word);
        }
    }
}
