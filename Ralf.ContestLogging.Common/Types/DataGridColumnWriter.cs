using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ralf.ContestLogging.Common.Types
{
    public abstract class DataGridColumnWriter
    {
        protected abstract void addColumns();
        protected IList<DataGridTextColumn> columns;
        public IList<DataGridTextColumn> Columns { get { return columns; } }
        public DataGridColumnWriter()
        {
            columns = new List<DataGridTextColumn>();
            addColumns();
        }
        protected void addDataGridColumn(string bindingName, string headerText, int width)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = headerText;
            textColumn.Width = width;
            textColumn.IsReadOnly = true;
            textColumn.Binding = new Binding(bindingName);
            columns.Add(textColumn);
        }
        protected void addDataGridColumn(string bindingName, string headerText)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = headerText;
            textColumn.IsReadOnly = true;
            textColumn.Binding = new Binding(bindingName);
            columns.Add(textColumn);
        }
    }
}
