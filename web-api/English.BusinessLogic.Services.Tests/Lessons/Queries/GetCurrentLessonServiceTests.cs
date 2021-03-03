using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetCurrentLessonServiceTests
    {
        private readonly Mock<ILessonRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public GetCurrentLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
            this._userContextMock = new Mock<IUserContext>();
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
            var userId = 11211;
            var lesson = new Lesson
            {
                Id = 111,
                Number = 222,
                UserId = userId
            };

            this._repoMock.Setup(m =>
                    m.GetLessonWithMaxNumber(
                        It.Is<int>(id => id == userId)
                        )
                )
                .ReturnsAsync(lesson);

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            var factLesson = await service.ExecuteAsync(
                    new GetCurrentLessonQuery()
                );

            // Assert
            Assert.Equal(lesson, factLesson);
        }

        private GetCurrentLessonService MakeService()
        {
            return new GetCurrentLessonService(
                this._repoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
