using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.Multipliers.MexicanStates.Models
{
    public interface IMexicanStatesViewModel : IBaseViewModel
    {
        MexicanStateList MexicanStateList { get; }
        string Title { get; }
    }
}
