using System.Threading.Tasks;

namespace English.BusinessLogic.Services.Tests
{
    public class WordRepoFake : IWordRepository
    {
        public WordRepoFake()
        {
            this.Word = new Word
            {
                Id = 12
            };
        }

        public Word Word { get; set; }

        public Task<Word> Find(int id)
        {
            return Task.FromResult(this.Word);
        }
    }
}
