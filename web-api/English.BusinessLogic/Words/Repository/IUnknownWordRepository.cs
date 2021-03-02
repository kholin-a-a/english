using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IUnknownWordRepository
    {
        Task Save(UnknownWord word);
    }
}
