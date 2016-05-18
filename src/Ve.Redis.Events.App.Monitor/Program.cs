using System;
using System.Threading;
using LightInject;
using Ve.Redis.Events.Common.Composition;
using Ve.Redis.Events.Common.Events;

namespace Ve.Redis.Events.App.Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.RegisterFrom<CommonComposition>();

            var monitor = container.GetInstance<IMonitor>();
            monitor.Subscribe("__keyspace@0__:*", (channel, value) =>
            {
                Console.WriteLine("channel: {0} | value: {1}", channel, value);
            });

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
