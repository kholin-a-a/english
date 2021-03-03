using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetWordDefinitionsServiceTests
    {
        private readonly WordRepoFake _repoFake;

        public GetWordDefinitionsServiceTests()
        {
            this._repoFake = new WordRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_NullQuery_ThrowsException()
        {
            var service = this.MakeService();
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_FindsWordInRepo()
        {
            // Setup
            var repoMock = new Mock<IWordRepository>();

            repoMock.SetReturnsDefault(
                    Task.FromResult(new Word())
                );

            var service = this.MakeService(repo: repoMock.Object);

            var query = new GetWordDefinitionsQuery { WordId = 123 };

            // Action
            await service.ExecuteAsync(query);

            // Assert
            repoMock.Verify(m =>
                m.Find(
                    It.Is<int>(id => id == query.WordId)
                    )
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsWordDefinitions()
        {
            // Setup
            var service = this.MakeService();

            this._repoFake.Word.Definitions.Add(
                    new Definition()
                );

            // Action
            var definitions = await service.ExecuteAsync(
                new GetWordDefinitionsQuery()
                );

            // Assert
            Assert.Same(this._repoFake.Word.Definitions, definitions);
        }

        private GetWordDefinitionsService MakeService(
            IWordRepository repo = null)
        {
            return new GetWordDefinitionsService(
                repo ?? this._repoFake
                );
        }
    }
}
