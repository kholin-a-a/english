using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IUnknownWordRepository
    {
        Task Add(UnknownWord word);
    }
}
