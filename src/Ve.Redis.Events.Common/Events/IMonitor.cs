using System;
using StackExchange.Redis;

namespace Ve.Redis.Events.Common.Events
{
    public interface IMonitor
    {
        void Subscribe(string channel, Action<string, string> subscription);
    }
}