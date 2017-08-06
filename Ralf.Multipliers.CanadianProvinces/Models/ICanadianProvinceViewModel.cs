using Ralf.ContestLogging.Common.Models;
using Ralf.Multipliers.CanadianProvinces.Types;

namespace Ralf.Multipliers.CanadianProvinces.Models
{
    public interface ICanadianProvinceViewModel : IBaseViewModel
    {
        CanadianProvinceList ProvinceList { get; }
        string Title { get; }
    }
}