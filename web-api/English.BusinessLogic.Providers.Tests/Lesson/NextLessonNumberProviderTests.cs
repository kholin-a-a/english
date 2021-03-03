using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Providers.Tests
{
    public class NextLessonNumberProviderTests
    {
        private readonly Mock<ILessonRepository> _repoMock;
        private readonly Mock<IUserContext> _userContextMock;

        public NextLessonNumberProviderTests()
        {
            this._repoMock = new Mock<ILessonRepository>();
            this._userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task Get_Default_ReturnsCountPlusOne()
        {
            // Setup
            var provider = this.MakeProvider();
            var count = 19;
            var userId = 1009;

            this._repoMock.Setup(m =>
                    m.GetLessonCount(
                            It.Is<int>(id => id == userId)
                        )
                )
                .ReturnsAsync(count);

            this._userContextMock.Setup(m =>
                    m.UserId
                )
                .Returns(userId);

            // Action
            var number = await provider.Get();

            // Assert
            Assert.Equal(count + 1, number);
        }

        private NextLessonNumberProvider MakeProvider()
        {
            return new NextLessonNumberProvider(
                this._repoMock.Object,
                this._userContextMock.Object
                );
        }
    }
}
