using System.Threading.Tasks;

namespace English.BusinessLogic.Providers
{
    public class NextLessonNumberProvider : INextLessonNumberProvider
    {
        private readonly ILessonRepository _repo;

        public NextLessonNumberProvider(ILessonRepository repo)
        {
            this._repo = repo;
        }

        public async Task<int> Get()
        {
            var count = await this._repo.GetLessonCount();
            return count + 1;
        }
    }
}
