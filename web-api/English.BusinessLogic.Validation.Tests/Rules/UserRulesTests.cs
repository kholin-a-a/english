using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Validation.Tests
{
    public class UserRulesTests
    {
        private readonly UserRepoFake _userRepoFake;

        public UserRulesTests()
        {
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task HasLesson_HasLesson_NoExceptions()
        {
            var lessonId = 2;

            this._userRepoFake.User.Lessons.Add(
                new Lesson { Id = lessonId }
                );

            var rules = this.MakeRules();

            await rules.HasLesson(1, lessonId);
        }

        [Fact]
        public async Task HasLesson_NoLesson_NotFoundException()
        {
            this._userRepoFake.User.Lessons.Clear();
            var rules = this.MakeRules();

            var ex = await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await rules.HasLesson(1, 2);
            });

            Assert.Contains("Lesson is not found", ex.Message);
        }

        private UserRules MakeRules(
            IUserRepository userRepo = null
        )
        {
            return new UserRules(
                userRepo ?? this._userRepoFake
                );
        }
    }
}
