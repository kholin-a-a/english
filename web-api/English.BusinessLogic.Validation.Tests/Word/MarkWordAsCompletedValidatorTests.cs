using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Validation.Tests
{
    public class MarkWordAsCompletedValidatorTests
    {
        private readonly UserContextFake _userContextFake;
        private readonly WordRulesFake _wordRulesFake;
        private readonly UserRulesFake _userRulesFake;

        public MarkWordAsCompletedValidatorTests()
        {
            this._userContextFake = new UserContextFake();
            this._wordRulesFake = new WordRulesFake();
            this._userRulesFake = new UserRulesFake();
        }

        [Fact]
        public async Task Validate_Default_NoExceptions()
        {
            var validator = this.MakeValidator();
            var command = new MarkWordAsCompletedCommand(1, 2, "");

            await validator.Validate(command);
        }

        [Fact]
        public async Task Validate_Default_EnsuresWordExists()
        {
            // Setup
            var wordRulesMock = new Mock<IWordRules>();

            var validator = this.MakeValidator(
                wordRules: wordRulesMock.Object
                );

            var command = new MarkWordAsCompletedCommand(1, 2, "");

            // Action
            await validator.Validate(command);

            // Assert
            wordRulesMock.Verify(m =>
                    m.WordExists(It.Is<int>(id => id == command.WordId))
                );
        }

        [Fact]
        public async Task Validate_Default_EnsuresLessonExists()
        {
            // Setup
            var userRulesMock = new Mock<IUserRules>();

            var validator = this.MakeValidator(
                userRules: userRulesMock.Object
                );

            var command = new MarkWordAsCompletedCommand(1, 2, "");

            // Action
            await validator.Validate(command);

            // Assert
            userRulesMock.Verify(m =>
                    m.HasLesson(
                        It.Is<int>(id => id == this._userContextFake.UserId),
                        It.Is<int>(id => id == command.LessonId)
                        )
                );
        }

        private MarkWordAsCompletedValidator MakeValidator(
            IUserContext userContext = null,
            IWordRules wordRules = null,
            IUserRules userRules = null
        )
        {
            return new MarkWordAsCompletedValidator(
                userContext ?? this._userContextFake,
                userRules ?? this._userRulesFake,
                wordRules ?? this._wordRulesFake
                );
        }
    }
}
