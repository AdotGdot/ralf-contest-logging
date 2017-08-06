using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.Multipliers.Zones.Models
{
    public interface IZonesViewModel : IBaseViewModel
    {
        ZoneList ZoneList { get; }
        string Title { get; }
    }
}