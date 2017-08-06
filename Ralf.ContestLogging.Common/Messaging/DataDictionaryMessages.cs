
using Prism.Events;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Messaging
{
    public class DataDictionaryRequest : PubSubEvent<object> { }
    public class DataDictionaryResponse : PubSubEvent<DataDictionary> { }
}
