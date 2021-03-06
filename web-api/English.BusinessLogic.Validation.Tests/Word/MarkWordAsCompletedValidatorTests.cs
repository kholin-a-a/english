using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Validation.Tests
{
    public class MarkWordAsCompletedValidatorTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly UserRepoFake _userRepoFake;
        private readonly WordRepoFake _wordRepoFake;

        public MarkWordAsCompletedValidatorTests()
        {
            this._userContextFake = new UserContextFake();
            this._wordRepoFake = new WordRepoFake();
            this._userRepoFake = new UserRepoFake();
        }

        [Fact]
        public async Task Validate_Valid_NoExceptions()
        {
            // Setup
            var lessonId = 123;
            var wordId = 456;

            this._userRepoFake.User.Lessons.Add(
                new Lesson { Id = lessonId }
                );

            this._wordRepoFake.Word = new Word { Id = wordId };

            var validator = this.MakeValidator();

            // Action
            await validator.Validate(
                new MarkWordAsCompletedCommand(wordId, lessonId, "")
                );
        }

        [Fact]
        public async Task Validate_WordIsNull_ThrowsNotFoundException()
        {
            this._wordRepoFake.Word = null;
            var validator = this.MakeValidator();

            var ex = await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await validator.Validate(
                    new MarkWordAsCompletedCommand(1, 2, "")
                );
            });

            Assert.Contains("Word is not found", ex.Message);
        }

        [Fact]
        public async Task Validate_NoLesson_ThrowsNotFoundException()
        {
            this._userRepoFake.User.Lessons.Clear();
            var validator = this.MakeValidator();

            var ex = await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await validator.Validate(
                    new MarkWordAsCompletedCommand(1, 2, "")
                );
            });

            Assert.Contains("Lesson is not found", ex.Message);
        }

        private MarkWordAsCompletedValidator MakeValidator(
            IUserRepository userRepo = null,
            IWordRepository wordRepo = null,
            IUserContext userContext = null
        )
        {
            return new MarkWordAsCompletedValidator(
                userRepo ?? this._userRepoFake,
                wordRepo ?? this._wordRepoFake,
                userContext ?? this._userContextFake
                );
        }
    }
}
