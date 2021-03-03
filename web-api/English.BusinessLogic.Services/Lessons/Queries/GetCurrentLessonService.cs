using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetCurrentLessonService : IQueryService<GetCurrentLessonQuery, Lesson>
    {
        private readonly ILessonRepository _repo;

        public GetCurrentLessonService(ILessonRepository repo)
        {
            this._repo = repo;
        }

        public Task<Lesson> ExecuteAsync(GetCurrentLessonQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetLessonWithMaxNumber();
        }
    }
}
