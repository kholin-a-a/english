using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace English.BusinessLogic.Repositories.Tests
{
    public class WordCollectionFake : ILiteCollection<Word>
    {
        public WordCollectionFake()
        {
            this.WordById = new Word();
            this.Words = new List<Word>();
        }

        public Word WordById { get; set; }
        public Word FindById(BsonValue id)
        {
            return this.WordById;
        }

        public IEnumerable<Word> Words { get; set; }
        public IEnumerable<Word> Find(Expression<Func<Word, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            return this.Words;
        }

        public BsonValue Insert(Word entity)
        {
            return default;
        }

        #region NotIMplemented
        public string Name => throw new NotImplementedException();

        public BsonAutoId AutoId => throw new NotImplementedException();

        public EntityMapper EntityMapper => throw new NotImplementedException();

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public int Count(string predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Query query)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BsonValue id)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(string predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool DropIndex(string name)
        {
            throw new NotImplementedException();
        }

        public bool EnsureIndex(string name, BsonExpression expression, bool unique = false)
        {
            throw new NotImplementedException();
        }

        public bool EnsureIndex(BsonExpression expression, bool unique = false)
        {
            throw new NotImplementedException();
        }

        public bool EnsureIndex<K>(Expression<Func<Word, K>> keySelector, bool unique = false)
        {
            throw new NotImplementedException();
        }

        public bool EnsureIndex<K>(string name, Expression<Func<Word, K>> keySelector, bool unique = false)
        {
            throw new NotImplementedException();
        }

        public bool Exists(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Word> Find(BsonExpression predicate, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Word> Find(Query query, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Word> FindAll()
        {
            throw new NotImplementedException();
        }

        public Word FindOne(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public Word FindOne(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public Word FindOne(BsonExpression predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public Word FindOne(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Word FindOne(Query query)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<Word> Include<K>(Expression<Func<Word, K>> keySelector)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<Word> Include(BsonExpression keySelector)
        {
            throw new NotImplementedException();
        }

        public void Insert(BsonValue id, Word entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<Word> entities)
        {
            throw new NotImplementedException();
        }

        public int InsertBulk(IEnumerable<Word> entities, int batchSize = 5000)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public long LongCount(string predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount(Query query)
        {
            throw new NotImplementedException();
        }

        public BsonValue Max(BsonExpression keySelector)
        {
            throw new NotImplementedException();
        }

        public BsonValue Max()
        {
            throw new NotImplementedException();
        }

        public K Max<K>(Expression<Func<Word, K>> keySelector)
        {
            throw new NotImplementedException();
        }

        public BsonValue Min(BsonExpression keySelector)
        {
            throw new NotImplementedException();
        }

        public BsonValue Min()
        {
            throw new NotImplementedException();
        }

        public K Min<K>(Expression<Func<Word, K>> keySelector)
        {
            throw new NotImplementedException();
        }

        public ILiteQueryable<Word> Query()
        {
            throw new NotImplementedException();
        }

        public bool Update(Word entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(BsonValue id, Word entity)
        {
            throw new NotImplementedException();
        }

        public int Update(IEnumerable<Word> entities)
        {
            throw new NotImplementedException();
        }

        public int UpdateMany(BsonExpression transform, BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public int UpdateMany(Expression<Func<Word, Word>> extend, Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(Word entity)
        {
            throw new NotImplementedException();
        }

        public int Upsert(IEnumerable<Word> entities)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(BsonValue id, Word entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
