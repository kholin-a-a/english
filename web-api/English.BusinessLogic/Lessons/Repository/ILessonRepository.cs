using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ILessonRepository
    {
        Task<Lesson> GetLessonWithMaxNumber(int userId);

        Task<int> GetLessonCount();

        Task Add(Lesson lesson);
    }
}
