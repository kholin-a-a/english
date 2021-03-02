using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ILessonRepository
    {
        Task Save(Lesson lesson);

        Task<Lesson> GetLessonWithMaxNumber();

        Task<int> GetLessonCount();
    }
}
