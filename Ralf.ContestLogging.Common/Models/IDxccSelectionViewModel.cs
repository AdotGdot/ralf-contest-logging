using Prism.Commands;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Models
{
    public interface IDxccSelectionViewModel : IBaseViewModel
    {
        IList<DxccEntitySelection> DxccEntities { get; }
        DelegateCommand<object> DxccSelected_Command { get; set; }
    }
}
