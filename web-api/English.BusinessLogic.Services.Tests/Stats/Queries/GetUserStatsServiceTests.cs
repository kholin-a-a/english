using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetUserStatsServiceTests
    {
        private readonly Mock<ILessonRepository> _lessonRepoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public GetUserStatsServiceTests()
        {
            this._lessonRepoMock = new Mock<ILessonRepository>();
            this._userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task ExecuteAsync_NullQuery_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_TotalLessonsEqualLessonsCount()
        {
            // Setup
            var service = this.MakeService();
            var count = 77;
            var userId = 120;

            this._lessonRepoMock.Setup(m =>
                    m.GetLessonCount(It.Is<int>(id => id == userId))
                )
                .ReturnsAsync(count);

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            var fact = await service.ExecuteAsync(
                    new GetUserStatsQuery()
                );

            // Assert
            Assert.Equal(count, fact.TotalLessons);
        }

        private GetUserStatsService MakeService()
        {
            return new GetUserStatsService(
                this._lessonRepoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
