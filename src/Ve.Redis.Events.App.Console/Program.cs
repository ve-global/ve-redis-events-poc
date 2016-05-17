using System;
using LightInject;
using Ve.Redis.Events.Common.Composition;
using Ve.Redis.Events.Common.Entities;
using Ve.Redis.Events.Common.Persistance;

namespace Ve.Redis.Events.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.RegisterFrom<CommonComposition>();

            var repository = container.GetInstance<IRepository<Message>>();

            while (true)
            {
                var message = new Message()
                {
                    MessageId = Guid.NewGuid(),
                    Content = System.Console.ReadLine()
                };

                repository.Set(message.MessageId.ToString(), message);
            }
        }
    }
}
