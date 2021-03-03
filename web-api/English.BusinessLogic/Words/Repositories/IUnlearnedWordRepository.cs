using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IUnlearnedWordRepository
    {
        Task<Word> GetNextUserWord(int userId);
    }
}
