using Ralf.ContestLogging.Common.Models;
using Ralf.Multipliers.States.Types;

namespace Ralf.Multipliers.States.Models
{
    public interface IUsStatesViewModel : IBaseViewModel
    {
        UsStateList UsStateList { get; }
        string Title { get; }
    }
}
