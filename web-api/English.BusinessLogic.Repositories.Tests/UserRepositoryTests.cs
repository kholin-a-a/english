using LiteDB;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Repositories.Tests
{
    public class UserRepositoryTests
    {
        private readonly UserCollectionFake _userCollectionFake;

        public UserRepositoryTests()
        {
            this._userCollectionFake = new UserCollectionFake();
        }

        [Fact]
        public async Task Find_Default_NoExceptions()
        {
            var repo = this.MakeRepository();
            await repo.Find(1);
        }

        [Fact]
        public async Task Find_Default_CallsFinById()
        {
            // Setup
            var id = 123;
            var mock = new Mock<ILiteCollection<User>>();
            var repo = this.MakeRepository(users: mock.Object);

            // Action
            await repo.Find(id);

            // Assert
            mock.Verify(m =>
                    m.FindById(It.Is<BsonValue>(_id => _id == id)
                    )
                );
        }

        [Fact]
        public async Task Find_Default_ReturnsUserFromDb()
        {
            // Setup
            var repo = this.MakeRepository();
            var dbUser = this._userCollectionFake.UserById;

            // Action
            var user = await repo.Find(1);

            // Assert
            Assert.Equal(dbUser, user);
        }

        [Fact]
        public async Task Update_Default_NoExceptions()
        {
            var repo = this.MakeRepository();
            await repo.Update(new User());
        }

        [Fact]
        public async Task Update_Default_CallsCollectionUpdate()
        {
            // Setup
            var mock = new Mock<ILiteCollection<User>>();
            var repo = this.MakeRepository(users: mock.Object);
            var user = new User();

            // Action
            await repo.Update(user);

            // Assert
            mock.Verify(m =>
                m.Update(
                    It.Is<User>(u => u == user)
                    )
                );
        }

        private UserRepository MakeRepository(
            ILiteCollection<User> users = null)
        {
            return new UserRepository(
                users ?? this._userCollectionFake
                );
        }
    }
}
