
using Prism.Events;

namespace Ralf.ContestLogging.Common.Messaging
{
    public class ShellClosingNotification : PubSubEvent<object> { }
    public class ShellClosingRcvdNotification : PubSubEvent<object> { }
}
