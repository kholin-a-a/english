using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services.Tests
{
    public class WordRepoFake : IWordRepository
    {
        public WordRepoFake()
        {
            this.Word = new Word { Id = 12 };
            
            this.Words = new List<Word>()
            {
                new Word { Id = 345 }
            };
        }

        public Word Word { get; set; }

        public Task<Word> Find(int id)
        {
            return Task.FromResult(this.Word);
        }

        public IEnumerable<Word> Words { get; set; }

        public Task<IEnumerable<Word>> Query(int[] filterIds, int take)
        {
            return Task.FromResult(this.Words);
        }
    }
}
