using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Providers.Tests
{
    public class NextLessonNumberProviderTests
    {
        private readonly Mock<ILessonRepository> _repoMock;

        public NextLessonNumberProviderTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
        }

        [Fact]
        public async Task Get_Default_ReturnsCountPlusOne()
        {
            // Setup
            var provider = this.MakeProvider();
            var count = 19;

            this._repoMock.Setup(m =>
                    m.GetLessonCount()
                )
                .ReturnsAsync(count);

            // Action
            var number = await provider.Get();

            // Assert
            Assert.Equal(count + 1, number);
        }

        private NextLessonNumberProvider MakeProvider()
        {
            return new NextLessonNumberProvider(
                this._repoMock.Object
                );
        }
    }
}
