using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public class WordRepository : IWordRepository
    {
        public Task<Word> GetNextUserWord()
        {
            return Task.FromResult(new Word
            {
                Id = 12,
                Text = "Word"
            });
        }
    }
}
