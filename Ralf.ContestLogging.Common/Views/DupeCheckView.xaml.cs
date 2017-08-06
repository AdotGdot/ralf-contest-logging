using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Views
{
    /// <summary>
    /// Interaction logic for DupeCheckView.xaml
    /// </summary>
    public partial class DupeCheckView : UserControl
    {
        public DupeCheckView(IDupeCheckViewModel viewModel, IDupeListColumnBindingsService columnBindings)
        {
            InitializeComponent();
            addDataGridColumns(columnBindings.Columns);
            this.DataContext = viewModel;
            viewModel.onResetDupeView += onResetDupeView;

            setCallsignTextBoxFocus();
        }

        private void onResetDupeView()
        {
            setCallsignTextBoxFocus();
        }

        private void addDataGridColumns(IList<DataGridTextColumn> columns)
        {
            dupeListDataGrid.Columns.Clear();
            foreach (DataGridTextColumn column in columns)
            {
                dupeListDataGrid.Columns.Add(column);
            }
        }

        private void setCallsignTextBoxFocus()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(
                   (a) =>
                   {
                       System.Threading.Thread.Sleep(300);
                       callsignTextBox.Dispatcher.Invoke(
                       new Action(() =>
                       {
                           callsignTextBox.Focus();
                       }));
                   });
        }
    }
}
