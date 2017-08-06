using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Threading.Tasks;

namespace Ralf.WebServiceLogging
{
    public class MockLogWebService : ILogWebService
    {
        public MockLogWebService(string serviceUrl) { }

        public async Task<bool> Insert(Qso qso)
        {
            return false;
        }

        public async Task<bool> Update(Qso qso)
        {
            return false;
        }
    }
}
