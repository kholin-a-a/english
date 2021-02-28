using English.BusinessLogic;
using English.WebApi.Controllers;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.WebApi.Tests.Controllers
{
    public class WordsControllerTests
    {
        private readonly Mock<IQueryService<GetNextUserWord, Word>> _nextUserWordQueryMock;

        public WordsControllerTests()
        {
            this._nextUserWordQueryMock = new Mock<IQueryService<GetNextUserWord, Word>>();
        }

        [Fact]
        public async Task GetNextWord_Default_OkObjectResult()
        {
            var controller = this.MakeController();

            var actionResult = await controller.GetNextWord();

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetNextWord_Default_ReturnsWord()
        {
            // Setup
            var controller = this.MakeController();

            var nextWord = new Word
            {
                Id = 123,
                Text = "Something"
            };

            this._nextUserWordQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetNextUserWord>())
                )
                .ReturnsAsync(nextWord);

            // Action
            var actionResult = await controller.GetNextWord();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var word = Assert.IsType<WordOutputModel>(okResult.Value);

            Assert.Equal(nextWord.Id, word.Id);
            Assert.Equal(nextWord.Text, word.Text);
        }

        private WordsController MakeController()
        {
            this._nextUserWordQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetNextUserWord>())
                )
                .ReturnsAsync(
                    new Word()
                );

            return new WordsController(
                this._nextUserWordQueryMock.Object
                );
        }
    }
}
