using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface INextLessonNumberProvider
    {
        Task<int> Get();
    }
}
