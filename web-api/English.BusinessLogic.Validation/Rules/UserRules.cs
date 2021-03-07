using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class UserRules : IUserRules
    {
        private readonly IUserRepository _userRepo;

        public UserRules(
            IUserRepository userRepo
        )
        {
            this._userRepo = userRepo;
        }

        public async Task HasLesson(int userId, int lessonId)
        {
            var user = await this._userRepo.Find(userId);

            var lessonExists = user.Lessons.Any(l => l.Id == lessonId);
            if (!lessonExists)
                throw new EntityNotFoundException($"Lesson is not found");
        }
    }
}
