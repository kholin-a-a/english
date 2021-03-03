using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetCurrentLessonService : IQueryService<GetCurrentLessonQuery, Lesson>
    {
        private readonly ILessonRepository _repo;
        private readonly IUserContext _userContext;

        public GetCurrentLessonService(
            ILessonRepository repo,
            IUserContext userContext
        )
        {
            this._repo = repo;
            this._userContext = userContext;
        }

        public Task<Lesson> ExecuteAsync(GetCurrentLessonQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.GetLessonWithMaxNumber(
                this._userContext.UserId
                );
        }
    }
}
