using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class MarkWordAsUknownServiceTests
    {
        private readonly Mock<IUnknownWordRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public MarkWordAsUknownServiceTests()
        {
            this._repoMock = new Mock<IUnknownWordRepository>();
            this._userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task ExecuteAsync_CommandNull_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_RepoMethodCalled()
        {
            // Setup
            var service = this.MakeService();
            var userId = 12121;
            var command = new MarkWordAsUknownCommand
            {
                WordId = 33
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
                    It.Is<UnknownWord>(w =>
                        w.WordId == command.WordId
                        &&
                        w.UserId == userId
                    )
                )
            );
        }

        private MarkWordAsUknownService MakeService()
        {
            return new MarkWordAsUknownService(
                this._repoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
