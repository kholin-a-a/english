using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetNextUserWordServiceTests
    {
        private readonly Mock<IUnlearnedWordRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public GetNextUserWordServiceTests()
        {
            this._repoMock = new Mock<IUnlearnedWordRepository>();
            this._userContextMock = new Mock<IUserContext>();
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
            var query = new GetNextUserWordQuery();
            var userId = 1232;
            var word = new Word
            {
                Id = 123,
                Text = "Test"
            };

            this._repoMock.Setup(m =>
                    m.GetNextUserWord(It.Is<int>(id => id == userId))
                )
                .ReturnsAsync(word);

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            var fact = await service.ExecuteAsync(query);

            // Assert
            Assert.Equal(word, fact);
        }

        private GetNextUserWordService MakeService()
        {
            return new GetNextUserWordService(
                this._repoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
