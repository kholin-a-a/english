using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class StartLessonServiceTests
    {
        private readonly Mock<ILessonRepository> _repoMock;
        private readonly Mock<INextLessonNumberProvider> _nextNumberMock;
        private readonly Mock<IUserContext> _userContextMock;

        public StartLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
            this._nextNumberMock = new Mock<INextLessonNumberProvider>();
            this._userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task ExecuteAsync_NullCommand_ThrowsException()
        {
            var service = this.MakeService();

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_RepositoryMethodCalled()
        {
            // Setup
            var service = this.MakeService();
            var number = 12;
            var userId = 1212;

            this._nextNumberMock.Setup(m =>
                    m.Get()
                )
                .ReturnsAsync(number);

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            await service.ExecuteAsync(
                new StartLessonCommand()
                );

            // Assert
            this._repoMock.Verify(m =>
                    m.Add(
                        It.Is<Lesson>(l =>
                            l.Number == number
                            &&
                            l.UserId == userId
                        )
                    )
                );
        }

        private StartLessonService MakeService()
        {
            return new StartLessonService(
                this._repoMock.Object,
                this._nextNumberMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
