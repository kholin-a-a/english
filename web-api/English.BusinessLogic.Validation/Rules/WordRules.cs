using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class WordRules : IWordRules
    {
        private readonly IWordRepository _wordRepo;

        public WordRules(IWordRepository wordRepo)
        {
            this._wordRepo = wordRepo;
        }

        public async Task WordExists(int wordId)
        {
            var word = await this._wordRepo.Find(wordId);
            if (word == null)
                throw new EntityNotFoundException($"Word is not found");
        }
    }
}
