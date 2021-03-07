using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class WordRulesFake : IWordRules
    {
        public Task WordExists(int wordId)
        {
            return Task.CompletedTask;
        }
    }
}
