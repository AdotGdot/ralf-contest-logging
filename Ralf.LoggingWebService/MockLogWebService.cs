using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Threading.Tasks;

namespace Ralf.LoggingWebService
{
    class MockLogWebService : ILogWebService
    {
        public MockLogWebService(string serviceUrl) { }
        public async Task<bool> Insert(Qso qso)
        {
          return await Task.Run(() => false);
        }

        public async Task<bool> Update(Qso qso)
        {
            return await Task.Run(() => false);
        }
    }
}
