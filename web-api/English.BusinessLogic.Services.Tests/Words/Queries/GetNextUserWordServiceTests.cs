using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetNextUserWordServiceTests
    {
        private readonly Mock<IWordRepository> _repoMock;

        public GetNextUserWordServiceTests()
        {
            this._repoMock = new Mock<IWordRepository>();
        }

        [Fact]
        public async Task ExecuteAsync_CommandNull_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsNextWord()
        {
            // Setup
            var service = this.MakeService();
            var query = new GetNextUserWord();
            var word = new Word
            {
                Id = 123,
                Text = "Test"
            };

            this._repoMock.Setup(m =>
                    m.GetNexWord()
                )
                .ReturnsAsync(word);

            // Action
            var fact = await service.ExecuteAsync(query);

            // Assert
            Assert.Equal(word, fact);
        }

        private GetNextUserWordService MakeService()
        {
            return new GetNextUserWordService(
                this._repoMock.Object
                );
        }
    }
}
