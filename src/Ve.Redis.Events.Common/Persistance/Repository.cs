using System;
using Jil;
using StackExchange.Redis;

namespace Ve.Redis.Events.Common.Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IConnectionMultiplexer _connection;

        public Repository(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public T Get(string key)
        {
            var db = _connection.GetDatabase();
            var result = db.StringGet(BuildKey(key));

            if (result.HasValue)
            {
                return JSON.Deserialize<T>(result);
            }

            return null;
        }

        public void Set(string key, T entity)
        {
            var db = _connection.GetDatabase();
            db.StringSet(BuildKey(key), JSON.Serialize(entity), TimeSpan.FromSeconds(10));
        }

        private string BuildKey(string key)
        {
            return string.Format("{0}-{1}", typeof(T).Name, key);
        }
    }
}
