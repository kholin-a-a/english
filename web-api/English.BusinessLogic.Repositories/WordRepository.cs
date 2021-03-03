using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class WordRepository : IWordRepository
    {
        public Task<Word> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Word>> Query(int[] filterIds, int take)
        {
            throw new NotImplementedException();
        }
    }
}
