using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class MarkWordAsCompletedServiceTests
    {
        private readonly Mock<ICompletedWordRepository> _completedWordRepo;

        public MarkWordAsCompletedServiceTests()
        {
            this._completedWordRepo = new Mock<ICompletedWordRepository>();
        }

        [Fact]
        public async Task ExecuteAsync_CommandNull_ThrowsException()
        {
            var service = this.MakeService();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_WordRepoMethodCalled()
        {
            // Setup
            var service = this.MakeService();
            
            var command = new MarkWordAsCompleted
            {
                LessonId = 456,
                Text = "Some spoken text",
                WordId = 789
            };

            // Action
            await service.ExecuteAsync(command);

            // Assert
            this._completedWordRepo.Verify(m =>
                m.Add(
                    It.Is<CompletedWord>(w =>
                        w.LessonId == command.LessonId
                        &&
                        w.WordId == command.WordId
                        &&
                        w.Text == command.Text
                    )
                )
            );
        }

        private MarkWordAsCompletedService MakeService()
        {
            return new MarkWordAsCompletedService(
                this._completedWordRepo.Object
                );
        }
    }
}
