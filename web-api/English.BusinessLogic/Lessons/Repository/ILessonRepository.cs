using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ILessonRepository
    {
        Task<Lesson> GetLessonWithMaxNumber();

        Task<int> GetLessonCount();

        Task Add(Lesson lesson);
    }
}
