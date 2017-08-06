using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IUSCallsignLookupService
    {
        CallsignData LookupCallsign(string callsign);
    }
}
