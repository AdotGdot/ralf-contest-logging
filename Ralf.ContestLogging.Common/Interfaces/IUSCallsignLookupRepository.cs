using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IUSCallsignLookupRepository
    {
        CallsignData LookupCallsign(string callsign);
    }
}
