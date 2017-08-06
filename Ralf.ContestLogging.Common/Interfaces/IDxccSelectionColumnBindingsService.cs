using System.Collections.Generic;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IDxccSelectionColumnBindingsService
    {
        IList<DataGridTextColumn> Columns { get; }
    }
}
