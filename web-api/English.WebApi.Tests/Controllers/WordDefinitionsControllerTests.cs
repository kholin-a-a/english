using English.BusinessLogic;
using English.WebApi.Controllers;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace English.WebApi.Tests.Controllers
{
    public class WordDefinitionsControllerTests
    {
        private readonly Mock<IQueryService<GetWordDefinitionsQuery, IEnumerable<WordDefinition>>> _definitionsQueryMock;

        public WordDefinitionsControllerTests()
        {
            this._definitionsQueryMock = new Mock<IQueryService<GetWordDefinitionsQuery, IEnumerable<WordDefinition>>>();
        }

        [Fact]
        public async Task GetDefinitions_Default_OkObjectResult()
        {
            var controller = this.MakeController();

            var actionResult = await controller.GetDefinitions(1);

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetDefinitions_Default_QueryExecuted()
        {
            var controller = this.MakeController();
            const int wordId = 123;

            await controller.GetDefinitions(wordId);

            this._definitionsQueryMock.Verify(m =>
                m.ExecuteAsync(
                    It.Is<GetWordDefinitionsQuery>(q =>
                        q.WordId == wordId
                        )
                    )
                );
        }

        [Fact]
        public async Task GetDefinitions_Default_ReturnsDefinitions()
        {
            // Setup
            var controller = this.MakeController();

            var speechPart = "Noun";
            var definition = "activity requiring physical effort, carried out to sustain or improve health and fitness";
            var example = "exercise improves your heart and lung power";
            var syn = "activity";

            var wordDefinitions = new WordDefinition[]
            {
                new WordDefinition
                {
                     SpeechPart = new SpeechPart
                     {
                        Name = speechPart
                     },
                     Definition = definition,
                     Example = example,
                     Synonyms = new Word[]
                     {
                        new Word
                        {
                            Id = 1,
                            Text = syn
                        }
                     }
                }
            };

            this._definitionsQueryMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetWordDefinitionsQuery>())
                )
                .ReturnsAsync(wordDefinitions);

            // Action
            var actionResult = await controller.GetDefinitions(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var definitions = Assert.IsType<List<WordDefinitionOutputModel>>(okResult.Value);

            Assert.All(
                definitions,
                d =>
                {
                    Assert.Equal(speechPart, d.SpeechPart);
                    Assert.Equal(definition, d.Definition);
                    Assert.Equal(example, d.Example);

                    Assert.All(
                        d.Synonyms,
                        s =>
                        {
                            Assert.Equal(syn, s);
                        });
                });
        }

        private WordDefinitionsController MakeController()
        {
            return new WordDefinitionsController(
                this._definitionsQueryMock.Object
                );
        }
    }
}
