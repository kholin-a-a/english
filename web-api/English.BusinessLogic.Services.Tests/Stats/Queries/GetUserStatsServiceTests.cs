using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetUserStatsServiceTests
    {   
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;

        public GetUserStatsServiceTests()
        {
            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_Default_NoExceptions()
        {
            var service = this.MakeService();

            await service.ExecuteAsync(
                    new GetUserStatsQuery()
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
                    new GetUserStatsQuery()
                );

            // Assert
            repoMock.Verify(m =>
                    m.Find(It.Is<int>(id => id == this._userContextFake.UserId)
                )
            );
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsTotalUserLessons()
        {
            // Setup
            var user = new User()
            {
                Lessons = new List<Lesson>()
                {
                    new Lesson(),
                    new Lesson(),
                    new Lesson(),
                    new Lesson()
                }
            };

            this._userRepoFake.User = user;

            var service = this.MakeService();

            // Action
            var stats = await service.ExecuteAsync(
                    new GetUserStatsQuery()
                );

            // Assert
            Assert.Equal(user.Lessons.Count, stats.TotalLessons);
        }

        //[Fact]
        //public async Task ExecuteAsync_NullQuery_ThrowsException()
        //{
        //    var service = this.MakeService();

        //    await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        //}

        //[Fact]
        //public async Task ExecuteAsync_Default_TotalLessonsEqualLessonsCount()
        //{
        //    // Setup
        //    var service = this.MakeService();
        //    var count = 77;
        //    var userId = 120;

        //    this._lessonRepoMock.Setup(m =>
        //            m.GetLessonCount(It.Is<int>(id => id == userId))
        //        )
        //        .ReturnsAsync(count);

        //    this._userContextMock.Setup(m =>
        //            m.UserId
        //        )
        //        .Returns(userId);

        //    // Action
        //    var fact = await service.ExecuteAsync(
        //            new GetUserStatsQuery()
        //        );

        //    // Assert
        //    Assert.Equal(count, fact.TotalLessons);
        //}

        private GetUserStatsService MakeService(
            IUserContext context = null,
            IUserRepository repo = null
        )
        {
            return new GetUserStatsService(
                context ?? this._userContextFake,
                repo ?? this._userRepoFake
                );
        }
    }
}
