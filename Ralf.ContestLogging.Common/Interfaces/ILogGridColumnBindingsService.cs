using System.Collections.Generic;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface ILogGridColumnBindingsService
    {
        IList<DataGridTextColumn> Columns { get; }
    }
}
