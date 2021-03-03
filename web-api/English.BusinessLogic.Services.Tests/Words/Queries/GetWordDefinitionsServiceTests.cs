using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetWordDefinitionsServiceTests
    {
        private readonly Mock<IWordDefinitionRepository> _repoMock;

        public GetWordDefinitionsServiceTests()
        {
            this._repoMock = new Mock<IWordDefinitionRepository>();
        }

        [Fact]
        public async Task ExecuteAsync_NullQuery_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsDefinitions()
        {
            // Setup
            var service = this.MakeService();
            var query = new GetWordDefinitionsQuery()
            {
                WordId = 509
            };
            var definitions = new WordDefinition[0];

            this._repoMock.Setup(m =>
                m.GetDefinition(
                    It.Is<int>(id => id == query.WordId)
                    )
                )
                .ReturnsAsync(definitions);

            // Action
            var fact = await service.ExecuteAsync(query);

            // Assert
            Assert.Equal(definitions, fact);
        }

        private GetWordDefinitionsService MakeService()
        {
            return new GetWordDefinitionsService(
                this._repoMock.Object
                );
        }
    }
}
