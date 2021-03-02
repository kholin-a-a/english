using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ICompletedWordRepository
    {
        Task Save(CompletedWord word);
    }
}
