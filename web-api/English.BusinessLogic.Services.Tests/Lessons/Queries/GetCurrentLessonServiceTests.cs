using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetCurrentLessonServiceTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;

        public GetCurrentLessonServiceTests()
        {
            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_Default_NoExceptions()
        {
            var service = this.MakeService();

            await service.ExecuteAsync(
                new GetCurrentLessonQuery()
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_FindsUserInRepo()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            repoMock.SetReturnsDefault(
                Task.FromResult(new User())
                );

            var service = this.MakeService(repo: repoMock.Object);

            // Action
            await service.ExecuteAsync(
                new GetCurrentLessonQuery()
                );

            // Assert
            repoMock.Verify(m =>
                    m.Find(
                        It.Is<int>(id => id == this._userContextFake.UserId)
                    )
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsLastLesson()
        {
            // Setup
            var last = new Lesson { Id = 5 };

            this._userRepoFake.User = new User
            {
                Id = 32,
                Lessons = new List<Lesson>()
                {
                    new Lesson { Id = 1 },
                    last,
                    new Lesson { Id = 2 }
                }
            };

            var service = this.MakeService();

            // Action
            var lesson = await service.ExecuteAsync(
                new GetCurrentLessonQuery()
                );

            // Assert
            Assert.Equal(last, lesson);
        }

        private GetCurrentLessonService MakeService(
            IUserContext context = null,
            IUserRepository repo = null
        )
        {
            return new GetCurrentLessonService(
                    context ?? this._userContextFake,
                    repo ?? this._userRepoFake
                );
        }
    }
}
