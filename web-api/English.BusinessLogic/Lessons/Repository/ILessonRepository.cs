using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ILessonRepository
    {
        Task<Lesson> GetLessonWithMaxNumber(int userId);

        Task<int> GetLessonCount(int userId);

        Task Add(Lesson lesson);
    }
}
