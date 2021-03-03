using Moq;
using System;
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
        public async Task ExecuteAsync_Default_AddsToUknonwn()
        {
            // Setup
            var service = this.MakeService();
            var user = this._userRepoFake.User;
            var word = this._wordRepoFake.Word;

            // Action
            await service.ExecuteAsync(
                    new MarkWordAsUknownCommand()
                );

            // Assert
            Assert.Collection(
                user.UnknownWords,
                w =>
                {
                    Assert.Equal(word, w);
                });
        }

        [Fact]
        public async Task ExecuteAsync_Default_UpdateMethodCalled()
        {
            // Setup
            var repoMock = new Mock<IUserRepository>();

            var user = new User();

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
