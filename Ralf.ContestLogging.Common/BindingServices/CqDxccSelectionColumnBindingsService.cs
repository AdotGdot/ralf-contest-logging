using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.BindingServices
{
    public class CqDxccSelectionColumnBindingsService : DataGridColumnWriter, IDxccSelectionColumnBindingsService
    {
        public CqDxccSelectionColumnBindingsService()
            : base()
        {
        }
        protected override void addColumns()
        {
            addDataGridColumn("Name", "DXCC Entity", 250);
            addDataGridColumn("CqZone", "CQ Zone");
            addDataGridColumn("Continent", "Continent");
        }
    }
}
