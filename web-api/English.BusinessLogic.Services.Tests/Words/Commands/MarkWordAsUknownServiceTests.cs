using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class MarkWordAsUknownServiceTests
    {
        private readonly Mock<IUnknownWordRepository> _repoMock;

        public MarkWordAsUknownServiceTests()
        {
            this._repoMock = new Mock<IUnknownWordRepository>();
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
            var command = new MarkWordAsUknown
            {
                WordId = 33
            };

            // Action
            await service.ExecuteAsync(command);

            // Assert
            this._repoMock.Verify(m =>
                m.Save(
                    It.Is<UnknownWord>(w => w.WordId == command.WordId)
                    )
                );
        }

        private MarkWordAsUknownService MakeService()
        {
            return new MarkWordAsUknownService(
                this._repoMock.Object
                );
        }
    }
}
