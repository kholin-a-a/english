using English.BusinessLogic;
using English.WebApi.Controllers;
using English.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.WebApi.Tests.Controllers
{
    public class LessonsControllerTests
    {
        private readonly Mock<ICommandService<StartLessonCommand>> _startLessonMock;
        private readonly Mock<IQueryService<GetCurrentLessonQuery, Lesson>> _getLessonMock;

        public LessonsControllerTests()
        {
            this._startLessonMock = new Mock<ICommandService<StartLessonCommand>>();
            this._getLessonMock = new Mock<IQueryService<GetCurrentLessonQuery, Lesson>>();
        }

        [Fact]
        public async Task StartLesson_Default_OkObjectResult()
        {
            var controller = this.MakeConroller();

            var actionResult = await controller.StartLesson();

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task StartLesson_Default_StartCommandExecuted()
        {
            var controller = this.MakeConroller();

            await controller.StartLesson();

            this._startLessonMock.Verify(m =>
                m.ExecuteAsync(
                    It.IsAny<StartLessonCommand>()
                    )
                );
        }

        [Fact]
        public async Task StartLesson_Default_ReturnsCurrentLesson()
        {
            // Setup
            var controller = this.MakeConroller();

            var currentLesson = new Lesson()
            {
                Id = 123
            };

            this._getLessonMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetCurrentLessonQuery>())
                )
                .ReturnsAsync(currentLesson);

            // Action
            var actionResult = await controller.StartLesson();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var lesson = Assert.IsType<LessonOutputModel>(okResult.Value);

            Assert.Equal(currentLesson.Id, lesson.Id);
        }

        private LessonsController MakeConroller()
        {
            this._getLessonMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetCurrentLessonQuery>())
                )
                .ReturnsAsync(
                    new Lesson()
                );

            return new LessonsController(
                this._startLessonMock.Object,
                this._getLessonMock.Object
                );
        }
    }
}
