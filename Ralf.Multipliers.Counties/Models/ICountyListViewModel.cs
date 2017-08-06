using Ralf.ContestLogging.Common.Models;
using Ralf.Multipliers.Counties.Types;

namespace Ralf.Multipliers.Counties.Models
{
    public interface ICountyListViewModel : IBaseViewModel
    {
        CountyList CountyList { get; }
        string Title { get; }
        int ColumnCount { get; }
    }
}