using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public class WordRepository : IUnlearnedWordRepository
    {
        public Task<Word> GetNextUserWord(int userId)
        {
            return Task.FromResult(new Word
            {
                Id = 12,
                Text = "Word"
            });
        }
    }
}
