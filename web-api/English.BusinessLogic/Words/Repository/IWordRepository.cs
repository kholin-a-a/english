using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IWordRepository
    {
        Task MarkCompleted(int id);
    }
}
