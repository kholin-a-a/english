using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetCurrentLessonServiceTests
    {
        private readonly Mock<ILessonRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;

        public GetCurrentLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
            this._userContextMock = new Mock<IUserContext>();

            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_Default_NoExceptions()
        {
            var service = new GetCurrentLessonService(
                this._userContextFake,
                this._userRepoFake
                );

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

            var service = new GetCurrentLessonService(
                this._userContextFake,
                repoMock.Object
                );

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

            var service = new GetCurrentLessonService(
                this._userContextFake,
                this._userRepoFake
                );

            // Action
            var lesson = await service.ExecuteAsync(
                new GetCurrentLessonQuery()
                );

            // Assert
            Assert.Equal(last, lesson);
        }
    }
}
