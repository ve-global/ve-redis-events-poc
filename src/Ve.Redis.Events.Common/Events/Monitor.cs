using System;
using StackExchange.Redis;

namespace Ve.Redis.Events.Common.Events
{
    public class Monitor : IMonitor
    {
        private readonly IConnectionMultiplexer _connection;

        public Monitor(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public void Subscribe(string channel, Action<string, string> subscription)
        {
            var subscriber = _connection.GetSubscriber();

            subscriber.Subscribe(channel, (redisChannel, value) => subscription(redisChannel.ToString(), value.ToString()));
        }
    }
}
