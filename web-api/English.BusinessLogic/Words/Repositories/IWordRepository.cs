using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IWordRepository
    {
        Task<Word> Find(int id);
    }
}
