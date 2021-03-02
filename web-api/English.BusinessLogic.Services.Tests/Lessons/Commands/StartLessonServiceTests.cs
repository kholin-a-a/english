using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class StartLessonServiceTests
    {
        private readonly Mock<ILessonRepository> _repoMock;

        public StartLessonServiceTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
        }

        [Fact]
        public async Task ExecuteAsync_NullCommand_ThrowsException()
        {
            var service = this.MakeService();

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_RepositoryMethodCalled()
        {
            var service = this.MakeService();

            await service.ExecuteAsync(
                new StartLesson()
                );

            this._repoMock.Verify(m =>
                    m.Create()
                );
        }

        private StartLessonService MakeService()
        {
            return new StartLessonService(
                this._repoMock.Object
                );
        }
    }
}
