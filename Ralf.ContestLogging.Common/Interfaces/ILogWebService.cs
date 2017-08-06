using Ralf.ContestLogging.Common.Types;
using System.Threading.Tasks;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface ILogWebService
    {
        Task<bool> Insert(Qso qso);
        Task<bool> Update(Qso qso);
    }
}
