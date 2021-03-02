using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsCompletedService : ICommandService<MarkWordAsCompleted>
    {
        private readonly ICompletedWordRepository _completedWordRepo;

        public MarkWordAsCompletedService(ICompletedWordRepository completedWordRepo)
        {
            this._completedWordRepo = completedWordRepo;
        }

        public async Task ExecuteAsync(MarkWordAsCompleted command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var word = new CompletedWord
            {
                LessonId = command.LessonId,
                WordId = command.WordId,
                Text = command.Text
            };

            await this._completedWordRepo.Save(word);
        }
    }
}
