using Prism.Events;
using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Messaging
{
    public class TransceiverStateRequest : PubSubEvent<object> { }
    public class TransceiverSetFrequencyRequest : PubSubEvent<double> { }
    public class TransceiverSetModeRequest : PubSubEvent<Mode> { }
    public class TransceiverMatchVFOsRequest : PubSubEvent<object> { }
    public class TransceiverModeDownRequest : PubSubEvent<object> { }
    public class TransceiverModeUpRequest : PubSubEvent<object> { }
    public class TransceiverToggleSplitRequest : PubSubEvent<object> { }
    public class TransceiverToggleVFOsRequest : PubSubEvent<object> { }
    public class TransceiverStateResponse : PubSubEvent<TransceiverState> { }
    public class ModeChangedNotification : PubSubEvent<Mode> { }
    public class BandChangedNotification : PubSubEvent<Band> { }
    public class CancelMessageNotification : PubSubEvent<object> { }
    public class SendMessageNotification : PubSubEvent<int> { }
    public class SendFreeformMessageNotification : PubSubEvent<object> { }
    public class SetFocusToFreeFormEntryNotification : PubSubEvent<object> { }
}
