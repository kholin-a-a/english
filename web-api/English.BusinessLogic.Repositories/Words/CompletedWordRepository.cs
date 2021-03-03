using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class CompletedWordRepository : ICompletedWordRepository
    {
        public Task Add(CompletedWord word)
        {
            return Task.CompletedTask;
        }
    }
}
