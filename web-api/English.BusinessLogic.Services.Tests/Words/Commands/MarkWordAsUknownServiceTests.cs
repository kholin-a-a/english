using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class MarkWordAsUknownServiceTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;
        private readonly WordRepoFake _wordRepoFake;

        public MarkWordAsUknownServiceTests()
        {
            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
            this._wordRepoFake = new WordRepoFake();
        }

        [Fact]
        public async Task ExecuteAsync_Default_NoExceptions()
        {
            var service = this.MakeService();

            await service.ExecuteAsync(
                new MarkWordAsUknownCommand()
                );
        }

        [Fact]
        public async Task ExecuteAsync_CommandNull_ThrowsException()
        {
            var service = this.MakeService();
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteAsync(null));
        }

        [Fact]
        public async Task ExecuteAsync_Default_FindsUserInRepo()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            repoMock.SetReturnsDefault(
                Task.FromResult(new User())
                );

            var service = this.MakeService(userRepo: repoMock.Object);

            // Action
            await service.ExecuteAsync(
                    new MarkWordAsUknownCommand()
                );

            // Assert
            repoMock.Verify(m =>
                    m.Find(It.Is<int>(id => id == this._userContextFake.UserId)
                )
            );
        }

        [Fact]
        public async Task ExecuteAsync_Default_FindsWordInRepo()
        {
            // Setup
            var repoMock = new Mock<IWordRepository>();

            repoMock.SetReturnsDefault(
                Task.FromResult(new Word())
                );

            var service = this.MakeService(wordRepo: repoMock.Object);

            var command = new MarkWordAsUknownCommand { WordId = 123 };

            // Action
            await service.ExecuteAsync(command);

            // Assert
            repoMock.Verify(m =>
                    m.Find(It.Is<int>(id => id == command.WordId)
                )
            );
        }

        [Fact]
        public async Task ExecuteAsync_Default_AddsAnswer()
        {
            // Setup
            var lessonId = 123;
            var wordId = 456;

            var user = new User();
            user.Lessons.Add(
                    new Lesson { Id = lessonId }
                );

            this._userRepoFake.User = user;

            var word = new Word { Id = wordId };

            this._wordRepoFake.Word = word;

            var service = this.MakeService();

            var command = new MarkWordAsUknownCommand
            {
                WordId = wordId,
                LessonId = lessonId,
            };

            // Action
            await service.ExecuteAsync(command);

            // Assert
            Assert.Single(
                user.Lessons.Single(l => l.Id == lessonId).Answers,
                a =>
                    a.Word == word
                    &&
                    a.Kind == AnswerKind.Unknown
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_UpdateMethodCalled()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            var user = new User();
            user.Lessons.Add(new Lesson());

            repoMock.SetReturnsDefault(
                    Task.FromResult(user)
                );

            var service = this.MakeService(userRepo: repoMock.Object);

            // Action
            await service.ExecuteAsync(
                    new MarkWordAsUknownCommand()
                );

            // Assert
            repoMock.Verify(m =>
                m.Update(
                    It.IsAny<User>()
                    )
                );
        }

        private MarkWordAsUknownService MakeService(
            IUserContext userContext = null,
            IUserRepository userRepo = null,
            IWordRepository wordRepo = null
        )
        {
            return new MarkWordAsUknownService(
                    userContext ?? this._userContextFake,
                    userRepo ?? this._userRepoFake,
                    wordRepo ?? this._wordRepoFake
                );
        }
    }
}
