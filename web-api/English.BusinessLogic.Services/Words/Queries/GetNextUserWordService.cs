using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetNextUserWordService : IQueryService<GetNextUserWord, Word>
    {
        public Task<Word> ExecuteAsync(GetNextUserWord query)
        {
            return Task.FromResult(
                new Word
                {
                    Id = 101,
                    Text = "Experiment"
                });
        }
    }
}
