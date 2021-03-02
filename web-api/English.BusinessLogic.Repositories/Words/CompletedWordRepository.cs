using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class CompletedWordRepository : ICompletedWordRepository
    {
        public Task Save(CompletedWord word)
        {
            return Task.CompletedTask;
        }
    }
}
