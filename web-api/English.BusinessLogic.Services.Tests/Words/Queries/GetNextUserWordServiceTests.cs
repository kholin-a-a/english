using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Services.Tests
{
    public class GetNextUserWordServiceTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;
        private readonly WordRepoFake _wordRepoFake;

        public GetNextUserWordServiceTests()
        {
            this._userContextFake = new UserContextFake();
            this._userRepoFake = new UserRepoFake();
            this._wordRepoFake = new WordRepoFake();
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
                    new GetNextUserWordQuery()
                );

            // Assert
            repoMock.Verify(m =>
                    m.Find(It.Is<int>(id => id == this._userContextFake.UserId)
                )
            );
        }

        [Fact]
        public async Task ExecuteAsync_Default_QueryWordFromRepo()
        {
            // Setup
            var repoMock = new Mock<IWordRepository>();

            var unknownIds = new int[] { 1, 2, 3 };
            var completedIds = new int[] { 4, 5, 6 };
            var allIds = unknownIds.Concat(completedIds);

            var lesson = new Lesson();

            lesson.Answers = completedIds
                .Select(id => new Answer { Kind = AnswerKind.Completed, Word = new Word { Id = id } })
                .Concat(
                    unknownIds.Select(id => new Answer { Kind = AnswerKind.Unknown, Word = new Word { Id = id } })
                )
                .ToList();

            this._userRepoFake.User.Lessons.Add(lesson);

            var service = this.MakeService(wordRepo: repoMock.Object);

            // Action
            await service.ExecuteAsync(
                    new GetNextUserWordQuery()
                );

            // Assert
            repoMock.Verify(m =>
                m.Query(
                        It.Is<int[]>(ids => allIds.Intersect(ids).Count() == allIds.Count()),
                        It.Is<int>(take => take == 1)
                    )
                );
        }

        [Fact]
        public async Task ExecuteAsync_Default_ReturnsFirstWord()
        {
            // Setup
            var service = this.MakeService();
            var first = this._wordRepoFake.Words.First();

            // Action
            var word = await service.ExecuteAsync(
                    new GetNextUserWordQuery()
                );

            // Assert
            Assert.Equal(first, word);
        }

        private GetNextUserWordService MakeService(
            IUserContext context = null,
            IUserRepository userRepo = null,
            IWordRepository wordRepo = null
        )
        {
            return new GetNextUserWordService(
                    context ?? this._userContextFake,
                    userRepo ?? this._userRepoFake,
                    wordRepo ?? this._wordRepoFake
                );
        }
    }
}
