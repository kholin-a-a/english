using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Validation.Tests
{
    public class WordRepoFake : IWordRepository
    {
        public WordRepoFake()
        {
            this.Word = new Word();
            
            this.Words = new List<Word>();
            this.Words.Add(new Word());
        }

        public Task Add(Word word)
        {
            return Task.CompletedTask;
        }

        public Word Word { get; set; }
        public Task<Word> Find(int id)
        {
            return Task.FromResult(this.Word);
        }

        public IList<Word> Words { get; set; }
        public Task<IEnumerable<Word>> Query(int[] filterIds, int take)
        {
            return Task.FromResult(this.Words.AsEnumerable());
        }
    }
}
