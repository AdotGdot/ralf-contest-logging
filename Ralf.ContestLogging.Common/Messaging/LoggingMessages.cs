
using Prism.Events;
using System;

namespace Ralf.ContestLogging.Common.Messaging
{
    public class EditEntryNotification : PubSubEvent<Guid> { }
    public class EntryCompleteNotification : PubSubEvent<object> { }
    public class LogChangedNotification : PubSubEvent<object> { }
    public class NewEntryNotification : PubSubEvent<string> { }
    public class DupeResetNotification : PubSubEvent<object> { }
    public class DupeCallsignRequest : PubSubEvent<string> { }
    public class CallsignChangedNotification : PubSubEvent<string> { }
    public class GeographicAreaRequest : PubSubEvent<string> { }
    public class GeographicAreaResponse : PubSubEvent<object> { }
    public class GeographicAreaSelectionNotification : PubSubEvent<object> { }
}
