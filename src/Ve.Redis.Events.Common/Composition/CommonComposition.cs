using System;
using LightInject;
using StackExchange.Redis;
using Ve.Redis.Events.Common.Persistance;

namespace Ve.Redis.Events.Common.Composition
{
    public class CommonComposition : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            var redis = Environment.GetEnvironmentVariable("Ve.Redis.Events", EnvironmentVariableTarget.Machine);

            serviceRegistry.Register<IConnectionMultiplexer>(factory => ConnectionMultiplexer.Connect(redis));
            serviceRegistry.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
