using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Services
{
    public class USCallsignLookupService : IUSCallsignLookupService
    {
        private IUSCallsignLookupRepository repository;

        public USCallsignLookupService(IUSCallsignLookupRepository repository)
        {
            this.repository = repository;
        }

        public CallsignData LookupCallsign(string callsign)
        {
            return repository.LookupCallsign(callsign);
        }
    }
}
