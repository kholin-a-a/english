using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IWordRepository
    {
        Task<Word> Find(int id);

        Task<IEnumerable<Word>> Query(int[] filterIds, int take);

        Task Add(Word word);
    }
}
