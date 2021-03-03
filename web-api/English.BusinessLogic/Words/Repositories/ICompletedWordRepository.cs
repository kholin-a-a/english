using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ICompletedWordRepository
    {
        Task Add(CompletedWord word);
    }
}
