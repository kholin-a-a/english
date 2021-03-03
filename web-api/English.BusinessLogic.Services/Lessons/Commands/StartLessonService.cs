using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class StartLessonService : ICommandService<StartLessonCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepo;

        public StartLessonService(
            IUserContext userContext,
            IUserRepository userRepo
        )
        {
            this._userContext = userContext;
            this._userRepo = userRepo;
        }

        public async Task ExecuteAsync(StartLessonCommand command)
        {
            var user = await this._userRepo.Find(this._userContext.UserId);

            var lesson = new Lesson
            {
                Id = user.Lessons.Count + 1
            };

            user.Lessons.Add(lesson);

            await this._userRepo.Update(user);
        }
    }
}
