using English.BusinessLogic;
using English.WebApi.Controllers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.WebApi.Tests.Controllers
{
    public class LessonsControllerTests
    {
        private readonly Mock<ICommandService<StartLesson>> _startLessonMock;
        private readonly Mock<ICommandService<StopLesson>> _stopLessonMock;

        public LessonsControllerTests()
        {
            this._startLessonMock = new Mock<ICommandService<StartLesson>>();
            this._stopLessonMock = new Mock<ICommandService<StopLesson>>();
        }

        private LessonsController MakeConroller()
        {
            return new LessonsController(
                this._startLessonMock.Object,
                this._stopLessonMock.Object
                );
        }
    }
}
