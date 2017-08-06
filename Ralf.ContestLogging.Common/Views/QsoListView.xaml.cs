using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Views
{
    /// <summary>
    /// Interaction logic for QsoListView.xaml
    /// </summary>
    public partial class QsoListView : UserControl
    {
        public QsoListView(IQsoListViewModel viewModel, ILogGridColumnBindingsService columns)
        {
            InitializeComponent();
            addDataGridColumns(columns.Columns);
            this.DataContext = viewModel;
            this.logDataGrid.Height = viewModel.LogPageSize * 30;
        }

        private void addDataGridColumns(IList<DataGridTextColumn> columns)
        {
            logDataGrid.Columns.Clear();
            foreach (DataGridTextColumn column in columns)
            {
                logDataGrid.Columns.Add(column);
            }
        }
    }
}