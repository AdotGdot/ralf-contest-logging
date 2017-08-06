using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.BindingServices
{
    public class ItuDxccSelectionColumnBindingsService : DataGridColumnWriter, IDxccSelectionColumnBindingsService
    {
        public ItuDxccSelectionColumnBindingsService()
            : base()
        {
        }
        protected override void addColumns()
        {
            addDataGridColumn("Name", "DXCC Entity", 250);
            addDataGridColumn("ItuZone", "ITU Zone");
            addDataGridColumn("Continent", "Continent");
        }
    }
}
