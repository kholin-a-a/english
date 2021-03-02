using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetCurrentLessonServiceTests
    {
        private readonly Mock<ILessonRepository> _repoMock;

        public GetCurrentLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
        }

        [Fact]
        public async Task ExecuteAsync_NullQuery_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsLessonWithMaxNumber()
        {
            // Setup
            var service = this.MakeService();

            var lesson = new Lesson
            {
                Id = 111,
                Number = 222
            };

            this._repoMock.Setup(m =>
                    m.GetLessonWithMaxNumber()
                )
                .ReturnsAsync(lesson);

            // Action
            var factLesson = await service.ExecuteAsync(
                    new GetCurrentLesson()
                );

            // Assert
            Assert.Equal(lesson, factLesson);
        }

        private GetCurrentLessonService MakeService()
        {
            return new GetCurrentLessonService(
                this._repoMock.Object
                );
        }
    }
}
