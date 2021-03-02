using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public Task<int> GetLessonCount()
        {
            return Task.FromResult(10);
        }

        public Task<Lesson> GetLessonWithMaxNumber()
        {
            return Task.FromResult(new Lesson
            {
                Id = 12,
                Number = 123
            });
        }

        public Task Save(Lesson lesson)
        {
            return Task.CompletedTask;
        }
    }
}
