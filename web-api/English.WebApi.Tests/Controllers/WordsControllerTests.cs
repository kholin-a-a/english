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
        private readonly Mock<IQueryService<GetNextUserWordQuery, Word>> _nextUserWordQueryMock;
        private readonly Mock<ICommandService<MarkWordAsUknown>> _markWordAsUknownCommandMock;
        private readonly Mock<ICommandService<MarkWordAsCompleted>> _markWordAsCompletedCommandMock;

        public WordsControllerTests()
        {
            this._nextUserWordQueryMock = new Mock<IQueryService<GetNextUserWordQuery, Word>>();
            this._markWordAsUknownCommandMock = new Mock<ICommandService<MarkWordAsUknown>>();
            this._markWordAsCompletedCommandMock = new Mock<ICommandService<MarkWordAsCompleted>>();
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
                    m.ExecuteAsync(It.IsAny<GetNextUserWordQuery>())
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

        [Fact]
        public async Task MarkAsUnknown_Default_OkResult()
        {
            var controller = this.MakeController();

            var actionResult = await controller.MarkAsUnknown(1);

            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public async Task MarkAsUnknown_Default_CommandExecuted()
        {
            var controller = this.MakeController();
            var wordId = 109;

            await controller.MarkAsUnknown(wordId);

            this._markWordAsUknownCommandMock.Verify(m =>
                m.ExecuteAsync(
                    It.Is<MarkWordAsUknown>(c =>
                        c.WordId == wordId
                        )
                    )
                );
        }

        [Fact]
        public async Task MarkAsCompleted_Default_OkResult()
        {
            var controller = this.MakeController();

            var actionResult = await controller.MarkAsCompleted(
                new WordCompletedInputModel()
                );

            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public async Task MarkAsCompleted_Default_CommandExecuted()
        {
            var controller = this.MakeController();
            var wordId = 123;
            var lessonId = 456;
            var text = "Some spoken words by user";

            var actionResult = await controller.MarkAsCompleted(
                new WordCompletedInputModel
                {
                    Id = wordId,
                    LessonId = lessonId,
                    Text = text
                });

            this._markWordAsCompletedCommandMock.Verify(m =>
                m.ExecuteAsync(
                    It.Is<MarkWordAsCompleted>(c =>
                        c.WordId == wordId
                        &&
                        c.LessonId == lessonId
                        &&
                        c.Text == text
                        )
                    )
                );
        }

        private WordsController MakeController()
        {
            this._nextUserWordQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetNextUserWordQuery>())
                )
                .ReturnsAsync(
                    new Word()
                );

            return new WordsController(
                this._nextUserWordQueryMock.Object,
                this._markWordAsUknownCommandMock.Object,
                this._markWordAsCompletedCommandMock.Object
                );
        }
    }
}
