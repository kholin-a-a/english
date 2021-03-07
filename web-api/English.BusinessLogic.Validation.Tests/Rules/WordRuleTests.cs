using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Validation.Tests
{
    public class WordRuleTests
    {
        private readonly WordRepoFake _wordRepoFake;

        public WordRuleTests()
        {
            this._wordRepoFake = new WordRepoFake();
        }

        [Fact]
        public async Task WordExists_Default_NoExceptions()
        {
            var rules = this.MakeRules();
            await rules.WordExists(1);
        }

        [Fact]
        public async Task WordExists_WordIsNull_NotFoundException()
        {
            this._wordRepoFake.Word = null;
            
            var rules = this.MakeRules();

            var ex = await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await rules.WordExists(1);
            });

            Assert.Contains("Word is not found", ex.Message);
        }

        private WordRules MakeRules(
            IWordRepository wordRepo = null
        )
        {
            return new WordRules(
                wordRepo ?? this._wordRepoFake
                );
        }
    }
}
