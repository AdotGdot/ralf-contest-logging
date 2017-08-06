using Prism.Commands;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Models
{
    public interface IDupeCheckViewModel : IBaseViewModel
    {
        event ResetDupeEventHandler onResetDupeView;
        string Callsign { get; set; }
        IList<Qso> DupeList { get; set; }
        DelegateCommand<object> EditQso_Command { get; set; }
        DelegateCommand<object> KeyUp_Command { get; set; }
        DelegateCommand<object> Reset_Command { get; set; }
    }
}

