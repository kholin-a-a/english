using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ILessonRepository
    {
        Task Create();

        Task<Lesson> GetLessonWithMaxNumber();
    }
}
