using LiteDB;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace English.BusinessLogic.Repositories.Tests
{
    public class WordRepositoryTests
    {
        private readonly WordCollectionFake _wordsFake;

        public WordRepositoryTests()
        {
            this._wordsFake = new WordCollectionFake();
        }

        [Fact]
        public async Task Find_Default_NoExceptions()
        {
            var service = this.MakeRepository();
            await service.Find(1);
        }

        [Fact]
        public async Task Find_Default_CallsFinById()
        {
            // Setup
            var id = 123;
            var mock = new Mock<ILiteCollection<Word>>();
            var repo = this.MakeRepository(words: mock.Object);

            // Action
            await repo.Find(id);

            // Assert
            mock.Verify(m =>
                    m.FindById(It.Is<BsonValue>(_id => _id == id)
                    )
                );
        }

        [Fact]
        public async Task Find_Default_ReturnsWordFromDb()
        {
            // Setup
            var repo = this.MakeRepository();
            var dbWord = this._wordsFake.WordById;

            // Action
            var word = await repo.Find(1);

            // Assert
            Assert.Equal(dbWord, word);
        }

        [Fact]
        public async Task Query_Default_NoExceptions()
        {
            var repo = this.MakeRepository();

            await repo.Query(
                    new int[] { },
                    10
                );
        }

        [Fact]
        public async Task Query_Default_CallsFind()
        {
            // Setup
            var mock = new Mock<ILiteCollection<Word>>();
            var repo = this.MakeRepository(words: mock.Object);
            var take = 10;

            // Action
            await repo.Query(
                    new int[] { },
                    take
                );

            // Assert
            mock.Verify(m =>
                m.Find(
                    It.IsAny<Expression<Func<Word, bool>>>(),
                    It.Is<int>(skip => skip == 0),
                    It.Is<int>(_take => _take == take)
                    )
                );
        }

        [Fact]
        public async Task Query_Default_ReturnsWordFromRepo()
        {
            // Setup
            var repo = this.MakeRepository();
            var words = this._wordsFake.Words;

            // Action
            var fact = await repo.Query(
                    new int[] { },
                    10
                );

            // Assert
            Assert.Equal(words, fact);
        }


        [Fact]
        public async Task Add_Default_NoExceptions()
        {
            var repo = this.MakeRepository();
            await repo.Add(new Word());
        }

        [Fact]
        public async Task Add_Default_CallsInsert()
        {
            // Setup
            var mock = new Mock<ILiteCollection<Word>>();
            var repo = this.MakeRepository(words: mock.Object);
            var word = new Word();

            // Action
            await repo.Add(word);

            // Assert
            mock.Verify(m =>
                m.Insert(
                    It.Is<Word>(w => w == word)
                    )
                );
        }

        private WordRepository MakeRepository(
            ILiteCollection<Word> words = null
        )
        {
            return new WordRepository(
                words ?? this._wordsFake
                );
        }
    }
}
