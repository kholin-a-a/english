using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class MarkWordAsCompletedServiceTests
    {
        private readonly Mock<ICompletedWordRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public MarkWordAsCompletedServiceTests()
        {
            this._repoMock = new Mock<ICompletedWordRepository>();
            this._userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task ExecuteAsync_CommandNull_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_WordRepoMethodCalled()
        {
            // Setup
            var service = this.MakeService();
            var userId = 12221;

            var command = new MarkWordAsCompleted
            {
                LessonId = 456,
                Text = "Some spoken text",
                WordId = 789
            };

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            await service.ExecuteAsync(command);

            // Assert
            this._repoMock.Verify(m =>
                m.Add(
                    It.Is<CompletedWord>(w =>
                        w.LessonId == command.LessonId
                        &&
                        w.WordId == command.WordId
                        &&
                        w.Text == command.Text
                        &&
                        w.UserId == userId
                    )
                )
            );
        }

        private MarkWordAsCompletedService MakeService()
        {
            return new MarkWordAsCompletedService(
                this._repoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
