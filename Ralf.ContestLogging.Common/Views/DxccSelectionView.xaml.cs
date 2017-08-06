using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Views
{
    /// <summary>
    /// Interaction logic for DxccSelectionView.xaml
    /// </summary>
    public partial class DxccSelectionView : UserControl
    {
        public DxccSelectionView(IDxccSelectionViewModel viewModel, IDxccSelectionColumnBindingsService columnBindings)
        {
            InitializeComponent();
            addDataGridColumns(columnBindings.Columns);
            this.DataContext = viewModel;
        }

        private void addDataGridColumns(IList<DataGridTextColumn> columns)
        {
            dxccDataGrid.Columns.Clear();
            foreach (DataGridTextColumn column in columns)
            {
                dxccDataGrid.Columns.Add(column);
            }
        }
    }
}
