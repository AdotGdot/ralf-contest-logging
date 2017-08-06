using Prism.Commands;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Models
{
    public interface IQsoListViewModel : IBaseViewModel
    {
        int LogPageSize { get; }
        IList<Qso> QsoList { get; set; }
        DelegateCommand<object> EditQso_Command { get; set; }
        DelegateCommand<object> NextPage_Command { get; set; }
        DelegateCommand<object> PreviousPage_Command { get; set; }
        DelegateCommand<object> EarliestPage_Command { get; set; }
        DelegateCommand<object> LatestPage_Command { get; set; }

        bool CanNavigateToLatestPage { get; set; }
        bool CanNavigateToEarliestPage { get; set; }
        bool CanNavigateToNextPage { get; set; }
        bool CanNavigateToPreviousPage { get; set; }
        int CurrentPage { get; set; }
        int PagesAvailable { get; set; }
    }
}
