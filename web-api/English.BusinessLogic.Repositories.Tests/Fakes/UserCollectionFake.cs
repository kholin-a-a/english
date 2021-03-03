using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace English.BusinessLogic.Repositories.Tests
{
    public class UserCollectionFake : ILiteCollection<User>
    {
        public UserCollectionFake()
        {
            this.UserById = new User();
        }

        public User UserById { get; set; }
        public User FindById(BsonValue id)
        {
            return this.UserById;
        }

        public bool Update(User entity)
        {
            return true;
        }

        #region NotImplemented

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

        public int Count(Expression<Func<User, bool>> predicate)
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

        public int DeleteMany(Expression<Func<User, bool>> predicate)
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

        public bool EnsureIndex<K>(Expression<Func<User, K>> keySelector, bool unique = false)
        {
            throw new NotImplementedException();
        }

        public bool EnsureIndex<K>(string name, Expression<Func<User, K>> keySelector, bool unique = false)
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

        public bool Exists(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(BsonExpression predicate, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Query query, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User FindOne(BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public User FindOne(string predicate, BsonDocument parameters)
        {
            throw new NotImplementedException();
        }

        public User FindOne(BsonExpression predicate, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public User FindOne(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User FindOne(Query query)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<User> Include<K>(Expression<Func<User, K>> keySelector)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<User> Include(BsonExpression keySelector)
        {
            throw new NotImplementedException();
        }

        public BsonValue Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(BsonValue id, User entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public int InsertBulk(IEnumerable<User> entities, int batchSize = 5000)
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

        public long LongCount(Expression<Func<User, bool>> predicate)
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

        public K Max<K>(Expression<Func<User, K>> keySelector)
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

        public K Min<K>(Expression<Func<User, K>> keySelector)
        {
            throw new NotImplementedException();
        }

        public ILiteQueryable<User> Query()
        {
            throw new NotImplementedException();
        }

        public bool Update(BsonValue id, User entity)
        {
            throw new NotImplementedException();
        }

        public int Update(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public int UpdateMany(BsonExpression transform, BsonExpression predicate)
        {
            throw new NotImplementedException();
        }

        public int UpdateMany(Expression<Func<User, User>> extend, Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(User entity)
        {
            throw new NotImplementedException();
        }

        public int Upsert(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(BsonValue id, User entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
