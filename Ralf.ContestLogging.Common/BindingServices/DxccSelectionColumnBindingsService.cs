using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.BindingServices
{
    public class DxccSelectionColumnBindingsService : DataGridColumnWriter, IDxccSelectionColumnBindingsService
    {
        public DxccSelectionColumnBindingsService()
            : base()
        {
        }
        protected override void addColumns()
        {
            addDataGridColumn("Name", "DXCC Entity", 250);
            addDataGridColumn("Continent", "Continent");
        }
    }
}
