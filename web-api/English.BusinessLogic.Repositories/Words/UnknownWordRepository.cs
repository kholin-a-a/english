using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public class UnknownWordRepository : IUnknownWordRepository
    {
        public Task Add(UnknownWord word)
        {
            return Task.CompletedTask;
        }
    }
}
