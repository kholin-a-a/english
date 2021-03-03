using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class StartLessonServiceTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;

        public StartLessonServiceTests()
        {
            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_Default_NoExceptions()
        {
            var service = this.MakeService();

            await service.ExecuteAsync(
                new StartLessonCommand()
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_FindMethodCalled()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            repoMock.SetReturnsDefault(
                    Task.FromResult(new User())
                );

            var service = this.MakeService(repo: repoMock.Object);

            // Action
            await service.ExecuteAsync(
                    new StartLessonCommand()
                );

            // Assert
            repoMock.Verify(m =>
                m.Find(
                        It.Is<int>(id => id == this._userContextFake.UserId)
                    )
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_UpdateMethodCalled()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            var user = new User() { Id = 123 };

            repoMock.SetReturnsDefault(
                    Task.FromResult(user)
                );

            var service = new StartLessonService(
                    this._userContextFake,
                    repoMock.Object
                );

            // Action
            await service.ExecuteAsync(
                new StartLessonCommand()
                );

            repoMock.Verify(m =>
                m.Update(
                    It.Is<User>(u =>
                        u.Id == user.Id
                        &&
                        u.Lessons.Count == 1
                    )
                )
            );
        }

        private StartLessonService MakeService(
            IUserContext context = null,
            IUserRepository repo = null
        )
        {
            return new StartLessonService(
                    context ?? this._userContextFake,
                    repo ?? this._userRepoFake
                );
        }
    }
}