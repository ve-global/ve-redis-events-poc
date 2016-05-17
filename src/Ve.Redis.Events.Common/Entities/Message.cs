using System;

namespace Ve.Redis.Events.Common.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }

        public string Content { get; set; }
    }
}
