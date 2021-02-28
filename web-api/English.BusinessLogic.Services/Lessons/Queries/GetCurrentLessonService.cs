using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetCurrentLessonService : IQueryService<GetCurrentLesson, Lesson>
    {
        public Task<Lesson> ExecuteAsync(GetCurrentLesson query)
        {
            return Task.FromResult(
                new Lesson
                {
                    Id = 12,
                    Number = 34
                });
        }
    }
}
