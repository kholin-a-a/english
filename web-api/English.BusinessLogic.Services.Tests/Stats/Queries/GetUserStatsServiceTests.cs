using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetUserStatsServiceTests
    {
        private readonly Mock<ILessonRepository> _lessonRepoMock;

        public GetUserStatsServiceTests()
        {
            this._lessonRepoMock = new Mock<ILessonRepository>();
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

            this._lessonRepoMock.Setup(m =>
                    m.GetLessonCount()
                )
                .ReturnsAsync(count);

            // Action
            var fact = await service.ExecuteAsync(
                    new GetUserStats()
                );

            // Assert
            Assert.Equal(count, fact.TotalLessons);
        }

        private GetUserStatsService MakeService()
        {
            return new GetUserStatsService(
                this._lessonRepoMock.Object
                );
        }
    }
}
