using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public interface IWordRules
    {
        Task WordExists(int wordId);
    }
}
