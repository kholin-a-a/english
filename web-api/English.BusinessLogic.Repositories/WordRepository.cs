using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly ILiteCollection<Word> _words;

        public WordRepository(ILiteCollection<Word> words)
        {
            this._words = words;
        }

        public async Task<Word> Find(int id)
        {
            await Task.Yield();
            return this._words.FindById(id);
        }

        public async Task<IEnumerable<Word>> Query(int[] filterIds, int take)
        {
            await Task.Yield();

            return this._words.Find(
                    w => !filterIds.Contains(w.Id),
                    limit: take
                );
        }

        public async Task Add(Word word)
        {
            await Task.Yield();
            this._words.Insert(word);
        }
    }
}
