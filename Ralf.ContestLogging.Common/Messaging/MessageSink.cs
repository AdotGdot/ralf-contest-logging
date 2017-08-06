using Prism.Events;

namespace Ralf.ContestLogging.Common.Messaging
{
    public class MessageSink
    {
        public static EventAggregator MessageBus { get; private set; }
        static MessageSink()
        {
            MessageBus = new EventAggregator();
        }
    }
}
