using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public class UnknownWordRepository : IUnknownWordRepository
    {
        public Task Save(UnknownWord word)
        {
            return Task.CompletedTask;
        }
    }
}
