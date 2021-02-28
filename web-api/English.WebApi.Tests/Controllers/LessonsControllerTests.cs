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
        private readonly Mock<ICommandService<StartLesson>> _startLessonMock;
        private readonly Mock<ICommandService<StopLesson>> _stopLessonMock;
        private readonly Mock<IQueryService<GetCurrentLesson, Lesson>> _getLessonMock;

        public LessonsControllerTests()
        {
            this._startLessonMock = new Mock<ICommandService<StartLesson>>();
            this._stopLessonMock = new Mock<ICommandService<StopLesson>>();
            this._getLessonMock = new Mock<IQueryService<GetCurrentLesson, Lesson>>();
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
                    It.IsAny<StartLesson>()
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
                Id = 123,
                Number = 456
            };

            this._getLessonMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetCurrentLesson>())
                )
                .ReturnsAsync(currentLesson);

            // Action
            var actionResult = await controller.StartLesson();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var lesson = Assert.IsType<LessonOutputModel>(okResult.Value);

            Assert.Equal(currentLesson.Id, lesson.Id);
            Assert.Equal(currentLesson.Number, lesson.Number);
        }

        private LessonsController MakeConroller()
        {
            this._getLessonMock.Setup(m =>
                    m.ExecuteAsync(It.IsAny<GetCurrentLesson>())
                )
                .ReturnsAsync(
                    new Lesson()
                );

            return new LessonsController(
                this._startLessonMock.Object,
                this._stopLessonMock.Object,
                this._getLessonMock.Object
                );
        }
    }
}
