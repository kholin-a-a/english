using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public Task Add(Lesson lesson)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetLessonCount()
        {
            return Task.FromResult(10);
        }

        public Task<Lesson> GetLessonWithMaxNumber(int userId)
        {
            return Task.FromResult(new Lesson
            {
                Id = 12,
                Number = 123
            });
        }
    }
}
