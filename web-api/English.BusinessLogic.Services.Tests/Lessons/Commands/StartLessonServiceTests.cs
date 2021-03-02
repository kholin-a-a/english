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

        public StartLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
            this._nextNumberMock = new Mock<INextLessonNumberProvider>();
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

            this._nextNumberMock.Setup(m =>
                    m.Get()
                )
                .ReturnsAsync(number);

            // Action
            await service.ExecuteAsync(
                new StartLesson()
                );

            // Assert
            this._repoMock.Verify(m =>
                    m.Save(
                            It.Is<Lesson>(l => l.Number == number)
                        )
                );
        }

        private StartLessonService MakeService()
        {
            return new StartLessonService(
                this._repoMock.Object,
                this._nextNumberMock.Object
                );
        }
    }
}
